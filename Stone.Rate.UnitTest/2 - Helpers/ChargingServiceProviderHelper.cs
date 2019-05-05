using NSubstitute;
using NSubstitute.Core;
using Stone.Rate.Models.Dto;
using Stone.Rate.ServiceProvider.Abstractions;
using System.Collections.Generic;

namespace Stone.Rate.UnitTest.Helpers
{
    internal static class ChargingServiceProviderHelper
    {
        internal static IChargingServiceProvider GetMock()
        {
            IChargingServiceProvider provider = Substitute.For<IChargingServiceProvider>();
            provider.RegisterAsync(Arg.Any<List<ChargeDto>>()).Returns(RegisterAsyncReturn);

            return provider;
        }

        public static bool RegisterAsyncReturn(CallInfo info)
        {
            return true;
        }
    }
}
