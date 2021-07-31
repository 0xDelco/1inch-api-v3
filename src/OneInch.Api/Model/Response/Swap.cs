using System.Collections.Generic;

namespace OneInch.Api
{    
     public class Swap
    {
             public Token fromToken {get;set;}
             public Token toToken {get;set;}            
             public List<List<List<SelectedProtocol>>> protocols {get;set;}             
             public string fromTokenAmount {get;set;}
             public string toTokenAmount {get;set;}
             public Transaction tx {get;set;}
    }
}