using System;

namespace OneInch.Api
{

    /// <summary>
    /// Attribute class to decorate API model properties.
    /// </summary>
    internal class OneInchParameterAttribute : System.Attribute
    {
        /// <summary>
        /// Constructs attribute to identify and name model property.
        /// </summary>
        /// <param name="name">Optional alias for decorated property.</param>
        /// <remarks></remarks>
        public OneInchParameterAttribute(string name = null)
        {
            this.Name = name;
        }

        /// <summary>
        /// Name for the decorated property. 
        /// </summary>
        /// <value>Name string value</value>
        public string Name {get;set;}
    }
}