using System.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;

namespace OneInch.Api
{
    /// <summary>
    /// Base class each request model should inherit from.
    /// </summary>
    public abstract class OneInchRequestBase : IOneInchRequest
    {
        Dictionary<string, string> _parameters = new Dictionary<string, string>();


        /// <summary>
        /// Retrieves public properties for the invoking class type.
        /// </summary>
        /// <returns>PropertyInfo array.</returns>
        PropertyInfo[] GetProperties()
        {
            Type t = GetType();
            return t.GetProperties(BindingFlags.Public|BindingFlags.Instance);
        }

        /// <summary>
        /// Extracts property name and value from a OneInchParameterAttribute decorated property.
        /// </summary>
        /// <param name="info">PropertyInfo metadata.</param>
        /// <param name="attribute">object containing property attribute.</param>
        /// <returns>string/object tuple of property name and value.</returns>
        (string, object) ExtractProperty(PropertyInfo info, object attribute)
        {
            var atty = (OneInchParameterAttribute)attribute;
            var oipValue = (String.IsNullOrEmpty(atty.Name)) ? info.Name : atty.Name;                         
            var propValue = info.GetValue(this);
            return (oipValue, propValue);
        }

        /// <summary>
        /// Determines if object is a property type of List.
        /// </summary>
        /// <param name="value">Property value object.</param>
        /// <returns>Boolean</returns>
        Boolean IsPropertyList(object value)
        {
            return (value.GetType().IsGenericType && value.GetType().GetGenericTypeDefinition() == typeof(List<>));
        }

        /// <summary>
        /// Iterates to child class and returns decorated properties into a structured URL parameter set.
        /// </summary>
        /// <returns>String of concatenated parameters.</returns>
        public string GetParameters()
        {
            var props = GetProperties();
            string query = String.Empty;
            
            foreach(var prop in props)
            {
                var atts = prop.GetCustomAttributes(false);
                foreach(var a in atts)
                {   
                    if(a is OneInchParameterAttribute)
                    {   
                        (string oipValue, object propValue) = ExtractProperty(prop, a);
                        
                        if(propValue is null) continue;

                        if(IsPropertyList(propValue)) 
                            propValue = FlattenPropertyList(propValue);
                        
                        var propValueCheck =  propValue.ToString();
                        
                        if(String.IsNullOrEmpty(propValueCheck) || propValueCheck == "0") continue;

                        if(!String.IsNullOrEmpty(query)) query += "&"; 
                        query += oipValue + "=" + propValue;
                    }
                }
            }
            return FinalizeCriteria(query);
        }

        /// <summary>
        /// Appends parameter criteria to child class route.
        /// </summary>
        /// <param name="criteria"></param>
        /// <returns>String of criteria.</returns>
        string FinalizeCriteria(string criteria)
        {
            return GetRoute() + ((criteria.Length > 1) ? ("?" + criteria) :  "/") ;
        }

        /// <summary>
        /// Iterates through a property List and concatenates values in a comma seperated list.
        /// </summary>
        /// <param name="list">Object of IList to be iterated through.</param>
        /// <returns>String of comma seperated values, if supplied list is populated.</returns>
        string FlattenPropertyList(object list)
        {
            var propValues = String.Empty;
            var propList = (IList)list;
            if(propList.Count == 0) return String.Empty;
            
            foreach(var i in propList)
            {
                if(!String.IsNullOrEmpty(propValues)) propValues += ","; 
                propValues += i.ToString();
            }
                return propValues;
        }

        /// <summary>
        /// Retrieves route value if child class is decorated with the necessary attribute.
        /// </summary>
        /// <returns>String route value.</returns>
        string GetRoute()
        {
            var attr = (OneInchRouteAttribute)Attribute.GetCustomAttribute(this.GetType(), typeof (OneInchRouteAttribute));
            if(attr != null)
                return attr.Route;
            else
            {
                return String.Empty;
            }
        }
    }
}