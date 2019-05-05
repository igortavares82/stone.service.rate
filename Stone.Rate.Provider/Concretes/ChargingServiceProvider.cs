using Microsoft.Extensions.Options;
using Stone.Charging.Messages;
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
    public class ChargingServiceProvider : IChargingServiceProvider
    {
        private IHttpConnector HttpConnector { get; }
        private ServiceChargeOptions Options { get; }

        public ChargingServiceProvider(IHttpConnector httpConnector, IOptions<ServiceChargeOptions> options)
        {
            HttpConnector = httpConnector;
            Options = options?.Value;

            HttpConnector.SetAddress(Options?.Address);
        }

        public async Task<bool> RegisterAsync(List<ChargeDto> chargeMessages)
        {
            IApplicationResult<bool> result = await HttpConnector.PostAsync<List<ChargeMessage>, bool>(Options?.RegisterUri, ChargeMapper.MapTo(chargeMessages));
            return result.Data;
        }
    }
}
