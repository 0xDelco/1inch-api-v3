
using System.Collections.Generic;
using System;



namespace OneInch.Web
{   
    [OneInchRoute("swap")]
    public class SwapRequest
    {
        public SwapRequest()
        {
            protocols = new List<string>();
            connectorTokens = new List<string>();
        }

        [OneInchParameter]
        public string fromTokenAddress {get;set;}

        [OneInchParameter]
        public string toTokenAddress {get;set;}

        [OneInchParameter]
        public long amount {get;set;}

        [OneInchParameter]
        public string fromAddress {get;set;}
        
        [OneInchParameter]
        public int slippage {get;set;}

        [OneInchParameter]
        public List<string> protocols {get;set;}

        [OneInchParameter]
        public string destReceiver {get;set;}

        [OneInchParameter]
        public string referrerAddress {get;set;}

        [OneInchParameter]
        public int? fee {get;set;}

        [OneInchParameter]
        public int? gasPrice {get;set;}

        [OneInchParameter]
        public bool? disableEstimate {get;set;} 

        [OneInchParameter]
        public bool? burnChi {get;set;}

        [OneInchParameter]
        public bool? allowPartialFill {get;set;}

        [OneInchParameter]
        public int? mainRouteParts {get;set;}

        [OneInchParameter]
        public int? virtualParts {get;set;}

        [OneInchParameter]
        public int? parts {get;set;}

        [OneInchParameter]
        public List<string> connectorTokens {get;set;} 
        
        [OneInchParameter]
        public int? complexityLevel {get;set;} 

        [OneInchParameter]
        public int? gasLimit {get;set;}                  

    }
}