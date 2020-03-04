using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Collections;

namespace LNTestChallenge.Model
{
    public class ResultDto
    {
        public string Result{get;set;}
        public Dictionary<string,int> Summary{get;set;}    
    }
}