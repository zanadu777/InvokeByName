using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using FluentAssertions;
using Invoker;
using Invoker.Extensions;
using InvokerTests.ReflectionTestClasses;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace InvokerTests
{
    [TestClass]
    public class ObjectExtensionTests
    {
        [TestMethod]
        public void Invoke_NoParams()
        {
            var basic = new MethodClass();
            basic.InvokeFirstMethod("NoParamMethod").Should().Be(42);

            basic.InvokeFirstMethod("NoParamAction").Should().Be(null);
        }


        [TestMethod]
        public void Invoke_OneParam()
        {
            var basic = new MethodClass();
            basic.InvokeFirstMethod("ReturnInputInt", new List<string>{"42"}).Should().Be(42);

            basic.InvokeFirstMethod("IncrementDate", new List<string> { "02/3/2109" }).Should().Be(DateTime.Parse("02/4/2109"));
        }

        [TestMethod]
        public void Invoke_TwoParam()
        {
            var basic = new MethodClass();
            basic.InvokeFirstMethod("Sum", new List<string> { "1", "2" }).Should().Be(3);
        }
    }
}
