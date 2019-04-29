using Stone.Framework.Result.Abstractions;
using Stone.Rate.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Rate.Application.Abstractions
{
    public interface IRatingApplication
    {
        Task<IApplicationResult<List<RateMessage>>> DoRateAsync();
    }
}
