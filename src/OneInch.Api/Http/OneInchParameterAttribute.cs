using System;

namespace OneInch.Api
{

    public class OneInchParameterAttribute : System.Attribute
    {
        public OneInchParameterAttribute(string name = null)
        {
            this.Name = name;
        }

        public string Name {get;set;}
    }
}