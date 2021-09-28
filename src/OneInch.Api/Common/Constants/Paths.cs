using System;

namespace OneInch.Api
{
    public class Paths
    {
        /// <summary>
        /// Paths that define locations for API end points.
        /// </summary>
        public class API
        {
            public static readonly string HealthCheck = "healthcheck";
            public static readonly string Protocols = "protocols";
            public static readonly string ApproveSpender = "approve/spender";
            public static readonly string ApproveCalldata = "approve/calldata"; 
            public static readonly string DefaultPresets = "presets";
            public static readonly string ProtocolNames = "protocols";
            public static readonly string ProtocolImages = "protocols/images";
            public static readonly string Tokens = "tokens";
            public static readonly string Swap = "swap";
        }
    } 
}
