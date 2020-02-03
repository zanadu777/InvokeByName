using System;
using System.Collections.Generic;
using System.Text;

namespace InvokerTests.ReflectionTestClasses
{
    class MethodClass
    {
        public int NoParamMethod()
        {
            return 42;
        }

        public void NoParamAction()
        {
            
        }

        public int ReturnInputInt(int i)
        {
            return i;
        }

        public string ReturnInputString(string i)
        {
            return i;
        }


        public int Sum(int i, int j)
        {
            return i +j;
        }

        public DateTime IncrementDate(DateTime date)
        {
            return date.AddDays(1);
        }
    }
}
