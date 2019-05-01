using Stone.Charging.Messages;
using Stone.Framework.Result.Abstractions;
using Stone.Framework.Result.Mappers;
using Stone.Rate.Application.Abstractions;
using Stone.Rate.Application.Mappers;
using Stone.Rate.Domain.Abstractions.TaskService;
using Stone.Rate.Messages;
using Stone.Rate.Models.Dto;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Rate.Application.Concretes
{
    public class RatingApplication : IRatingApplication
    {
        private IRatingTaskService RatingTaskService { get; }

        public RatingApplication(IRatingTaskService ratingTaskService)
        {
            RatingTaskService = ratingTaskService;
        }

        public async Task<IApplicationResult<List<RateMessage>>> DoRateAsync()
        {
            IDomainResult<List<ChargeDto>> domainResult = await RatingTaskService.DoRateAsync();
            return ResultMapper.MapFromDomainResult(domainResult, (domain) => RateMapper.MapTo(domain));
        }
    }
}
