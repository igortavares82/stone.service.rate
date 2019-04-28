using Stone.Framework.Result.Abstractions;
using Stone.Rate.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Rate.Domain.Abstractions.TaskService
{
    public interface IRatingTaskService
    {
        Task<IDomainResult<List<RatingDto>>> DoRateAsync();
    }
}
