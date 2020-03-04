using System;
using Xunit;
using LNTestChallenge;
using LNTestChallenge.Model;
namespace LNTestChallenge.Tests
{
    public class ChallengeOutputTest
    {
        [Fact]
        public void GetResult()
        {
            var ruleSetTest = new RuleSet();
            ruleSetTest.Rules = new Rule[]{ 
                new Rule(){Dividers = new int[]{ 3,5 }, Phrase = "LiveNation" },
                new Rule(){Dividers = new int[]{ 3 }, Phrase = "Live"} ,
                new Rule(){Dividers = new int[]{ 5 }, Phrase = "Nation"} };
             
            var resultDto = ChallengeOutput.GetResult(ruleSetTest,1,20);
            Console.WriteLine(resultDto.Result.ToString());
            Assert.True(
                string.Equals(resultDto.Result, "1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 LiveNation 16 17 Live 19 Nation"));
        }

        [Fact]
        public void GetResultDifferentRuleOrder()
        {
            var ruleSetTest = new RuleSet();
            ruleSetTest.Rules = new Rule[]{ 
                new Rule(){Dividers = new int[]{ 3 }, Phrase = "Live"} ,
                new Rule(){Dividers = new int[]{ 5 }, Phrase = "Nation"},
                new Rule(){Dividers = new int[]{ 3,5 }, Phrase = "LiveNation" } };             
            var resultDto = ChallengeOutput.GetResult(ruleSetTest,1,20);
            Console.WriteLine(resultDto.Result.ToString());
            Assert.True(
                string.Equals(resultDto.Result, "1 2 Live 4 Nation Live 7 8 Live Nation 11 Live 13 14 Live 16 17 Live 19 Nation"));
        }

        [Fact]
        public void GetResultSinglePhrase()
        {
            var ruleSetTest = new RuleSet();
            ruleSetTest.Rules = new Rule[]{ 
                new Rule(){Dividers = new int[]{ 3 }, Phrase = "Live"} ,
                new Rule(){Dividers = new int[]{ 5 }, Phrase = "Nation"},
                new Rule(){Dividers = new int[]{ 3,5 }, Phrase = "LiveNation" } };             
            var resultDto = ChallengeOutput.GetResult(ruleSetTest,3,3);
            Console.WriteLine(resultDto.Result.ToString());
            Assert.True(
                string.Equals(resultDto.Result, "Live"));
        }
        
        [Fact]
        public void GetResultSingleInteger()
        {
            var ruleSetTest = new RuleSet();
            ruleSetTest.Rules = new Rule[]{};             
            var resultDto = ChallengeOutput.GetResult(ruleSetTest,1,1);
            Console.WriteLine(resultDto.Result.ToString());
            Assert.True(
                string.Equals(resultDto.Result, "1"));
        }
        
        [Fact]
        public void GetResultNoRules()
        {
            var ruleSetTest = new RuleSet();
            ruleSetTest.Rules = new Rule[]{};             
            var resultDto = ChallengeOutput.GetResult(ruleSetTest,1,10);
            Console.WriteLine(resultDto.Result.ToString());
            Assert.True(
                string.Equals(resultDto.Result, "1 2 3 4 5 6 7 8 9 10"));
        }

        [Fact]
        public void GetResultReverse()
        {
            var ruleSetTest = new RuleSet();
            ruleSetTest.Rules = new Rule[]{};             
            var resultDto = ChallengeOutput.GetResult(ruleSetTest,10,1);
            Console.WriteLine(resultDto.Result.ToString());
            Assert.True(
                string.Equals(resultDto.Result, ""));
        }
    }
}
