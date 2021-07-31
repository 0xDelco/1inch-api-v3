namespace OneInch.Api
{
    public class Transaction
    {
        public string from {get;set;}
        public string to {get;set;}            
        public string data {get;set;}             
        public string value {get;set;}
        public string gasPrice {get;set;}
        public int gas {get;set;}
    }
}