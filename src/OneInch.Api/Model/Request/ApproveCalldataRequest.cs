
using System.Collections.Generic;
using System;

namespace OneInch.Api
{   
    [OneInchRoute("approve/calldata")]
    public class ApproveCalldataRequest
    {
        [OneInchParameter]
        public string tokenAddress {get;set;}

        [OneInchParameter]
        public string amount {get;set;}

        [OneInchParameter]
        public bool infinity {get;set;}
    }
}