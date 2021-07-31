
using System.Collections.Generic;
using System;

namespace OneInch.Api
{   
    [OneInchRoute("quote")]
    public class QuoteRequest : OneInchRequestBase
    {
        public QuoteRequest()
        {
            connectorTokens = new List<string>();
            protocols = new List<string>();
        }

        /// <summary>
        /// Contract token address being sold.
        /// </summary>
        /// <value></value>
        [OneInchParameter]
        public string fromTokenAddress {get;set;}
        
        /// <summary>
        /// Contract token address being bought.
        /// </summary>
        /// <value></value>
        [OneInchParameter]
        public string toTokenAddress {get;set;}
        
        /// <summary>
        /// Amount of a token to sell, set in minimal divisible units.
        /// </summary>
        /// <value></value>
        [OneInchParameter]
        public long amount {get;set;}

        /// <summary>
        /// Token connectors to assist exchange with routing if a pool with default connectors cannot be found.
        /// </summary>
        /// <value></value>
        [OneInchParameter]
        public List<string> connectorTokens {get;set;}
        
        /// <summary>
        /// Allowable fee percentage limit (min: 0; max: 3; default: 0;).
        /// </summary>
        /// <value></value>
        [OneInchParameter]
        public int fee {get;set;}
        
        /// <summary>
        /// 
        /// </summary>
        /// <value></value>
        [OneInchParameter]
        public int gasPrice {get;set;}
        
        /// <summary>
        /// List of liquidity protocol names to use. If not set, all liquidity protocols will be used.
        /// </summary>
        /// <value></value>
        [OneInchParameter]
        public List<string> protocols {get;set;}
        
        /// <summary>
        /// Maximum number of token-connectors to be used in a transaction.
        /// </summary>
        /// <value></value>
        [OneInchParameter]
        public int complexityLevel {get;set;}
        
        /// <summary>
        /// Limit maximum number of main route parts.
        /// </summary>
        /// <value></value>
        [OneInchParameter]
        public int mainRouteParts {get;set;}

        /// <summary>
        /// Limit maximum number of route parts.
        /// </summary>
        /// <value></value>
        [OneInchParameter]
        public int parts {get;set;}
        
        /// <summary>
        /// Maximum amount of gas for a swap.
        /// </summary>
        /// <value></value>
        [OneInchParameter]
        public int gasLimit {get;set;}


        /// <summary>
        /// Limit maximum number of virtual parts.
        /// </summary>
        /// <value></value>
        [OneInchParameter]
        public int virtualParts {get;set;}

        /// <summary>
        /// Extracts addresses from Token objects and adds them to the connectorTokens list.
        /// </summary>
        /// <param name="tokens"></param>
        public void AddConnectorTokens(List<Token> tokens)
        {
            tokens.ForEach(x => {
                this.connectorTokens.Add(x.address);
            });
        }

        /// <summary>       
        /// Extracts address from Token object and adds it to the connectorTokens list.
        /// </summary>
        /// <param name="tokens"></param>
        public void AddConnectorToken(Token token)
        {
            this.connectorTokens.Add(token.address);
        }

        /// <summary>
        /// Clears connectorToken list.
        /// </summary>
        public void ClearConnectorTokens()
        {
            this.connectorTokens.Clear();
        }

        /// <summary>
        /// Sets toToken address from provided token.
        /// </summary>
        /// <param name="token"></param>
        public void SetToToken(Token token)
        {
            this.toTokenAddress = token.address;
        }

        /// <summary>
        /// Sets fromToken address from provided token.
        /// </summary>
        /// <param name="token"></param>
        public void SetFromToken(Token token)
        {
            this.fromTokenAddress = token.address;
        }
    }
}