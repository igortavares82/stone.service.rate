using Microsoft.Extensions.Options;
using Stone.Charging.Messages;
using Stone.Framework.Http.Abstractions;
using Stone.Framework.Result.Abstractions;
using Stone.Rate.ServiceProvider.Abstractions;
using Stone.Rate.ServiceProvider.Options;
using System;
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
            Options = options.Value;

            HttpConnector.SetAddress(Options.Address);
        }

        public async Task<bool> RegisterAsync(List<ChargeMessage> chargeMessages)
        {
            IApplicationResult<bool> result = await HttpConnector.PostAsync<List<ChargeMessage>, bool>(Options.RegisterUri, chargeMessages);
            return result.Data;
        }
    }
}
