using NSubstitute;
using Stone.Rate.Domain.Abstractions.TaskService;
using Stone.Rate.Domain.Concretes.TaskService;
using Stone.Rate.ServiceProvider.Abstractions;

namespace Stone.Rate.UnitTest.Helpers
{
    internal static class RateTaskServiceHelper
    {
        internal static IRateTaskService GetMock()
        {
            IClientServiceProvider clientProvider = ClientServiceProviderHelper.GetMock();
            IChargingServiceProvider chargingProvider = ChargingServiceProviderHelper.GetMock();

            IRateTaskService taskService = Substitute.For<RateTaskService>(clientProvider, chargingProvider);

            return taskService;
        }
    }
}
