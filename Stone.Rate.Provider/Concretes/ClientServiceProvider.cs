using Microsoft.Extensions.Options;
using Stone.Clients.Messages;
using Stone.Framework.Http.Abstractions;
using Stone.Framework.Result.Abstractions;
using Stone.Rate.ServiceProvider.Abstractions;
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

        public async Task<List<ClientMessage>> GetAsync()
        {
            IApplicationResult<ClientMessage[]> result = await HttpConnector.GetAsync<ClientMessage[]>(Options.GetUri);
            return null; // result.Data;
        }
    }
}
