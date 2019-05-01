using Microsoft.Extensions.Options;
using Stone.Clients.Messages;
using Stone.Framework.Http.Abstractions;
using Stone.Framework.Result.Abstractions;
using Stone.Rate.Models.Dto;
using Stone.Rate.ServiceProvider.Abstractions;
using Stone.Rate.ServiceProvider.Mappers;
using Stone.Rate.ServiceProvider.Options;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Rate.ServiceProvider.Concretes
{
    public class ClientServiceProvider : IClientServiceProvider
    {
        private IHttpConnector HttpConnector { get; }
        private ServiceClientOptions Options { get; }

        public ClientServiceProvider(IHttpConnector httpConnector, IOptions<ServiceClientOptions> options)
        {
            HttpConnector = httpConnector;
            Options = options.Value;

            HttpConnector.SetAddress(Options.Address);
        }

        public async Task<List<ClientDto>> GetAsync()
        {
            IApplicationResult<List<ClientMessage>> result = await HttpConnector.GetAsync<List<ClientMessage>>(Options.GetUri);
            return ClientMapper.MapTo(result.Data);
        }
    }
}
