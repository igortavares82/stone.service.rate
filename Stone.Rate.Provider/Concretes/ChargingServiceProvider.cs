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
        private ServiceCharginOptions Options { get; }

        public ChargingServiceProvider(IHttpConnector httpConnector, IOptions<ServiceCharginOptions> options)
        {
            HttpConnector = httpConnector;
            Options = options.Value;
        }

        public async Task<bool> RegisterAsync(List<ChargeMessage> chargeMessage)
        {
            IApplicationResult<bool> result = await HttpConnector.PostAsync<List<ChargeMessage>, bool>("", chargeMessage);
            return result.Data;
        }
    }
}
