using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace Invoker.Extensions
{
    public static class TypeExtensions
    {
        /// <summary>
        /// Returns the first method in the type with the searched for name. This does not take into account method overloading. 
        /// </summary>
        /// <param name="type">type to be tested</param>
        /// <param name="name">name of method (case sensitive)</param>
        /// <returns></returns>
        public static MethodInfo FirstMethodOfName(this Type type, string name)
        {
            var methods = type.GetMethods();
            foreach (var methodInfo in methods)
       
                if (methodInfo.Name == name)
                    return methodInfo;

            throw  new Exception($"Method {name} not found in type {type}");
        }
    }
}
