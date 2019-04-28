using Stone.Charging.Messages;
using Stone.Rate.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Rate.ServiceProvider.Abstractions
{
    public interface IChargingServiceProvider
    {
        Task<bool> RegisterAsync(List<ChargeMessage> chargeMessage);
    }
}
