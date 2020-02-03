using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Invoker.Extensions
{
    public static class MethodInfoExtensions
    {
        public static string MergedParameterSignatures(this MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();
            if (parameters.Length == 0)
                return "";

            StringBuilder sb = new StringBuilder();
            List<string> typeNames = new List<string>();

            foreach (var param in parameters)
                typeNames.Add(param.ParameterType.Name);

            return string.Join("_", typeNames);
        }

        public static TypeConverter[] MethodTypeConverters(this MethodInfo methodInfo)
        {
            var parameters = methodInfo.GetParameters();
            var converters = from p in parameters
                             select TypeDescriptor.GetConverter(p.ParameterType);
            return converters.ToArray();
        }

        public static Func<IEnumerable<string>, object[]> ParameterConversionMethod(this MethodInfo methodInfo)
        {

            var converters = methodInfo.MethodTypeConverters();
            return s =>
            {
                if (s == null)
                    return new object[] { };

                var stringParamArray = s.ToArray();

                List<object> convertedObjectParameters = new List<object>();
                for (int i = 0; i < stringParamArray.Length; i++)
                    convertedObjectParameters.Add(converters[i].ConvertFromString(stringParamArray[i]));

                return convertedObjectParameters.ToArray();
            };
        }

        public static Func<object, IEnumerable<string>, object > CreateInvokeMethodDelegate(this MethodInfo methodInfo)
        {
            var converters = methodInfo.MethodTypeConverters();
            return ( o, s) =>
            {
                if (s == null)
                    return methodInfo.Invoke(o, new object[] { });

                var stringParamArray = s.ToArray();

                List<object> convertedObjectParameters = new List<object>();
                for (int i = 0; i < stringParamArray.Length; i++)
                    convertedObjectParameters.Add(converters[i].ConvertFromString(stringParamArray[i]));

                return methodInfo.Invoke(o, convertedObjectParameters.ToArray());
            };
        }


        public static MethodInfo FirstMethodOfName(this IEnumerable<MethodInfo> methods, string name)
        {
            foreach (var methodInfo in methods)

                if (methodInfo.Name == name)
                    return methodInfo;

            throw new Exception($"Method {name} not found");
        }
    }
}
