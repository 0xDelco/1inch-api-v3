
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Reflection;

namespace OneInch.Http
{
  public class OneInchRequestBuilder : IRequestBuilder
    {
        string _path;
        Dictionary<string, string> _parameters = new Dictionary<string, string>();

        public static string GetParameters(object request)
        {
            Type t = request.GetType();
            var props = t.GetProperties(BindingFlags.Public|BindingFlags.Instance);
            string query = String.Empty;
            foreach(var prop in props)
            {
                var atts = prop.GetCustomAttributes(false);
                foreach(var a in atts)
                {
                    if(a is OneInchParameterAttribute)
                    {   
                        var atty = (OneInchParameterAttribute)a;
                        var oipValue = (String.IsNullOrEmpty(atty.Name)) ? prop.Name : atty.Name;                         
                        var propValue = prop.GetValue(request);
                        
                        if(propValue is null) continue;

                        if(propValue.GetType().IsGenericType
                            && propValue.GetType().GetGenericTypeDefinition() == typeof(List<>)) 
                        {
                            var propValues = String.Empty;
                            var propList = (IList)propValue;
                            
                            if(propList.Count == 0) continue;
                            
                            foreach(var i in propList)
                            {
                                if(!String.IsNullOrEmpty(propValues)) propValues += ","; 
                                propValues += i.ToString();
                            }
                            propValue = propValues;
                        } 
                        if(!String.IsNullOrEmpty(query)) query += "&"; 
                        query += oipValue + "=" + propValue;
                    }
                }
            }


            return GetRoute(request) + ((query.Length > 1) ? ("?" + query) :  "/") ;
        }

        static string GetRoute(object request)
        {
            var attr = (OneInchRouteAttribute)Attribute.GetCustomAttribute(request.GetType(), typeof (OneInchRouteAttribute));
            if(attr != null)
                return "/" + attr.Route;
            else
            {
                return String.Empty;
            }
        }
    }
}