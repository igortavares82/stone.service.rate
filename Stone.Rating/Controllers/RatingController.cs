﻿using Microsoft.AspNetCore.Mvc;
using Stone.Framework.Result.Abstractions;
using Stone.Rate.Application.Abstractions;
using Stone.Rate.Messages;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Stone.Rate.WebApi.Controllers
{
    [Route("api/rating")]
    [ApiController]
    public class RatingController : ControllerBase
    {
        private IRatingApplication RateApplication { get; }

        public RatingController(IRatingApplication rateApplication)
        {
            RateApplication = rateApplication;
        }

        [HttpGet("wellcome"), Produces("text/plain", Type = typeof(string))]
        public string GetWellcome() => "Wellcome to charging service!";

        [HttpGet, Produces("application/json", Type = typeof(IApplicationResult<List<RateMessage>>))]
        public async Task<IActionResult> Get()
        {
            return await RateApplication.DoRateAsync();
        }
    }
}