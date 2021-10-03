using System;

namespace OneInch.Api
{  
      /// <summary>
      /// Guard clause enforcement class as part of an overall utility.
      /// </summary>
      public class Guard
      {
          /// <summary>
          /// Verify arguments provided are not null. If any are null, exception will be thrown.
          /// </summary>
          /// <param name="arguments">Arguments to verify.</param>
          public static void ArgumentsAreNotNull(params object[] arguments)
          {
              foreach (var arg in arguments)
                  ArgumentIsNotNull(arg, nameof(arg));
          }

          /// <summary>
          /// Verifies argument provided is not null. If so, throw exception including the included message.
          /// </summary>            
          public static void ArgumentIsNotNull(object argument, string argumentName)
          {
              if (argument == null)
                  throw new ArgumentNullException(argumentName);
          }
     }
}
