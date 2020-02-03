using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace InvokerTests.ReflectionTestClasses
{
    class BasicActionClass
    {
        #region no Param
        public void NoParamAction()
        {

        }
        #endregion


        #region one Param
        public void StringParamAction(string test)
        {

        }

        public void StringParamAction2(System.String test)
        {

        }

        public void IntParamAction(int test)
        {

        }

        public void ObjectParamAction(object test)
        {

        }
        #endregion

        #region two params
        public void IntIntParamAction(int test, int test2)
        {

        }

        #endregion
    }
}
