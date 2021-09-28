using System.Reflection;
using System;
using System.Collections;
using System.Collections.Generic;

namespace OneInch.Api
{
    public interface IOneInchRequest
    {
        string GetParameters();
    }

    public abstract class OneInchRequestBase : IOneInchRequest
    {
        Dictionary<string, string> _parameters = new Dictionary<string, string>();

        PropertyInfo[] GetProperties()
        {
            Type t = GetType();
            return t.GetProperties(BindingFlags.Public|BindingFlags.Instance);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="info"></param>
        /// <param name="attribute"></param>
        /// <returns></returns>
        (string, object) ExtractProperty(PropertyInfo info, object attribute)
        {
            var atty = (OneInchParameterAttribute)attribute;
            var oipValue = (String.IsNullOrEmpty(atty.Name)) ? info.Name : atty.Name;                         
            var propValue = info.GetValue(this);
            return (oipValue, propValue);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        Boolean IsPropertyList(object value)
        {
            return (value.GetType().IsGenericType && value.GetType().GetGenericTypeDefinition() == typeof(List<>));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
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

        string FinalizeCriteria(string criteria)
        {
            return GetRoute() + ((criteria.Length > 1) ? ("?" + criteria) :  "/") ;
        }

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