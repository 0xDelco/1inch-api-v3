
using System;
using System.Collections.Generic;
using System.Collections;
using System.Text.Json.Serialization;
using System.Net.Http;
using System.Reflection;

namespace OneInch.Api
{
  public class OneInchRequestBuilder //: IRequestBuilder
    {
        //      string _path;
        Dictionary<string, string> _parameters = new Dictionary<string, string>();

        public static PropertyInfo[] GetProperties(object request)
        {
            Type t = request.GetType();
            return t.GetProperties(BindingFlags.Public|BindingFlags.Instance);
        }

        public static (string, object) ExtractProperty(PropertyInfo info, object attribute, object target)
        {
            var atty = (OneInchParameterAttribute)attribute;
            var oipValue = (String.IsNullOrEmpty(atty.Name)) ? info.Name : atty.Name;                         
            var propValue = info.GetValue(target);

            return (oipValue, propValue);
        }

        private static Boolean IsPropertyList(object value)
        {
            return (value.GetType().IsGenericType && value.GetType().GetGenericTypeDefinition() == typeof(List<>));
        }

        public static string GetCriteria(object request)
        {
            var props = GetProperties(request);
            string query = String.Empty;
            
            foreach(var prop in props)
            {
                var atts = prop.GetCustomAttributes(false);
                foreach(var a in atts)
                {   
                    if(a is OneInchParameterAttribute)
                    {   
                        (string oipValue, object propValue) = ExtractProperty(prop, a, request);
                        
                        if(propValue is null) continue;

                        if(IsPropertyList(propValue)) 
                            propValue = FlattenPropertyList(propValue);

                        if(!String.IsNullOrEmpty(query)) query += "&"; 
                        query += oipValue + "=" + propValue;
                    }
                }
            }
            return FinalizeCriteria(request, query);
        }

        static string FinalizeCriteria(object request, string criteria)
        {
            return GetRoute(request) + ((criteria.Length > 1) ? ("?" + criteria) :  "/") ;
        }

        static string FlattenPropertyList(object list)
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

        public static string GetRoute(object request)
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