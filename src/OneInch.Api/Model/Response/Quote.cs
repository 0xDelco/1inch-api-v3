using System.Collections.Generic;

namespace OneInch.Api
{
    public class Quote
    {
        public Token fromToken {get;set;}
        public Token toToken {get;set;}            
        public List<List<List<SelectedProtocol>>> protocols {get;set;}             
        public string fromTokenAmount {get;set;}
        public string toTokenAmount {get;set;}
        public int estimatedGas {get;set;}
    }
}