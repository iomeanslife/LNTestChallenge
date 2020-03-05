using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using LNTestChallenge;

namespace LNTestChallenge.Model
{
    public class Request
    {
        public RuleSet RuleSet {get;}
        public int RangeStart {get;}
        public int RangeEnd {get;}

        public  Request(RuleSet ruleSet, int rangeStart, int rangeEnd)
        {
            if (ruleSet == null)
            {
                throw new ArgumentNullException();
            }

            if (rangeEnd < rangeStart )
            {
                throw new Exception($"The Range Start \"{ rangeStart }\" can not exceed the Range End \"{ rangeEnd }\".");
            }
            
            RuleSet = ruleSet;
            RangeStart = rangeStart;
            RangeEnd = rangeEnd;
        }
    }
}