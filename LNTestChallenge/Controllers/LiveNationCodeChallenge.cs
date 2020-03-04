using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace LNTestChallenge.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LiveNationCodeChallenge : ControllerBase
    {
        private readonly ILogger<LiveNationCodeChallenge> _logger;

        public LiveNationCodeChallenge(ILogger<LiveNationCodeChallenge> logger)
        {
            _logger = logger;
        }

        [HttpPost]
        [Route("GetResult")]
        public ResultDto GetResult([FromBody]RuleSet ruleSet, int rangeStart, int rangeEnd)
        {            
            Console.WriteLine($"RangeStart = {rangeStart}; RangeEnd = {rangeEnd};");
            return ChallengeOutput.GetResult(ruleSet, rangeStart, rangeEnd);
        }
        
        // Example Data for an easy JSON Object.
        [HttpGet]
        [Route("RuleSet")]
        public RuleSet Get()
        {            
            var rs = new RuleSet();
            rs.Rules = new Rule[]{ new Rule(){Dividers = new int[]{ 3 }, Phrase = "Live"} ,
             new Rule(){Dividers = new int[]{ 5 }, Phrase = "Nation"} ,
             new Rule(){Dividers = new int[]{ 3,5 }, Phrase = "LiveNation" }};
            return rs;
        }
    }
}