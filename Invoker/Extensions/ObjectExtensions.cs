using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Invoker.Extensions;

namespace Invoker
{
    public static class ObjectExtensions
    {

        public static object InvokeFirstMethod(this Object obj, string methodName, IEnumerable<string> parameter = null)
        {
            object[] objectParams;

            var methodInfo = obj.FirstMethodOfName(methodName);

            var del = methodInfo.CreateInvokeMethodDelegate();
            return del(obj, parameter);

            //var converter = methodInfo.ParameterConversionMethod();
            //objectParams = converter(parameter);
            //return methodInfo.Invoke(obj, objectParams);
        }


        public static MethodInfo FirstMethodOfName(this Object obj, string name)
        {
            var type = obj.GetType();
            var methods = type.GetMethods();
            foreach (var methodInfo in methods)

                if (methodInfo.Name == name)
                    return methodInfo;

            throw new Exception($"Method {name} not found in type {type}");
        }


    }
}
