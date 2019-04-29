using Stone.Charging.Messages;
using Stone.Framework.Result.Abstractions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Rate.Domain.Abstractions.TaskService
{
    public interface IRatingTaskService
    {
        Task<IDomainResult<List<ChargeMessage>>> DoRateAsync();
    }
}
