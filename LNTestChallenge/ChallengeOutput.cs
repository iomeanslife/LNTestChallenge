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
using LNTestChallenge.Model;

namespace LNTestChallenge
{
    public class ChallengeOutput
    {
        private static bool Divisionable(int index, int[] dividers)
        {
            foreach (var divider in dividers)
            {
                if (index % divider != 0)
                {
                    return false;
                }
            }    
            
            return true;
        }

        public static ResultDto GetResult(RuleSet ruleSet,int rangeStart,int rangeEnd)
        {
            var summaryDictionary = new Dictionary<string,int>();
            var resultStringBuilder = new StringBuilder();

            summaryDictionary["Integer"] = 0;

            for (int i = rangeStart; i <= rangeEnd; i++)
            {
                bool matched = false;

                foreach (var rule in ruleSet.Rules)
                {   
                    if (ChallengeOutput.Divisionable(i, rule.Dividers))
                    {
                        matched = true;
                        resultStringBuilder.Append(rule.Phrase);
                        
                        int summaryValue = 0; 
                        summaryDictionary.TryGetValue(rule.Phrase, out summaryValue);
                        summaryDictionary[rule.Phrase] = ++summaryValue; 
                        break;
                    }
                }

                if (!matched)
                {
                    resultStringBuilder.Append(i);
                    summaryDictionary["Integer"] = summaryDictionary["Integer"] + 1;
                }

                if (i < rangeEnd)
                {
                    resultStringBuilder.Append(' ');
                }
            }
             
            var result = new ResultDto() 
            {
                Result = resultStringBuilder.ToString(),
                Summary = summaryDictionary
            };

            return result;
        }
    }
}