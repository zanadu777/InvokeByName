using System.Collections.Generic;
using System.Reflection;
using FluentAssertions;
using Invoker;
using InvokerTests.ReflectionTestClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Invoker.Extensions;
namespace InvokerTests
{
    [TestClass]
    public class MethodInfoExtensionsTests
    {

        [TestMethod]
        public void NoParams_MergedParameterSignatures()
        {
            var basic = new BasicActionClass();
            basic.FirstMethodOfName("NoParamAction").MergedParameterSignatures().Should().Be("");
        }

        [TestMethod]
        public void OneParam_MergedParameterSignatures()
        {
            var basic = new BasicActionClass();
            var methods = basic.GetType().GetMethods();

            methods.FirstMethodOfName("StringParamAction").MergedParameterSignatures().Should().Be("String");
            methods.FirstMethodOfName("StringParamAction2").MergedParameterSignatures().Should().Be("String");
            methods.FirstMethodOfName("IntParamAction").MergedParameterSignatures().Should().Be("Int32");
            methods.FirstMethodOfName("ObjectParamAction").MergedParameterSignatures().Should().Be("Object");
        }

        [TestMethod]
        public void TwoParams_MergedParameterSignatures()
        {
            var basic = new BasicActionClass();
            var methods = basic.GetType().GetMethods();

            methods.FirstMethodOfName("IntIntParamAction").MergedParameterSignatures().Should().Be("Int32_Int32");
        }

        [TestMethod]
        public void Signature_Test()
        {
            var basic = new MethodClass();
            var methods = basic.GetType().GetMethods();

            var methodInfo = methods.FirstMethodOfName("ReturnInputString");
            {
                var converter = methodInfo.ParameterConversionMethod();
                var converted = converter(new List<string> { "test" });
                converted[0].GetType().Should().Be(typeof(string));
            }

            methodInfo = methods.FirstMethodOfName("ReturnInputInt");
            {
                var converter = methodInfo.ParameterConversionMethod();
                var converted = converter(new List<string> { "3" });
                converted[0].GetType().Should().Be(typeof(int));
            }
        }
    }
}
