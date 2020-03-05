using System;
using Xunit;
using LNTestChallenge;
using LNTestChallenge.Model;

namespace LNTestChallenge.Tests
{
    public class RequestTest
    {
        [Fact]
        public void CreateInstance()
        {
            var request = new Request(new RuleSet(),1,20);
            Assert.NotNull(request);   
        }

        [Fact]
        public void CreateInstanceBadRange()
        {
            Assert.Throws<Exception>(()=>{
                var request = new Request(new RuleSet(),20,1);
            } );
        }
    }
}
