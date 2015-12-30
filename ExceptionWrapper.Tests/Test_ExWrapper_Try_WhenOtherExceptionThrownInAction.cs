using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionWrapper.Tests
{
    [TestClass]
    public class Test_ExWrapper_Try_WhenOtherExceptionThrownInAction
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenOtherExceptionThrownInAction_ShouldThrowOtherException()
        {
            ExWrapper.Try<ArgumentNullException>(
                () => { throw new ArgumentException(); });
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void WhenOtherExceptionThrownInAction_ShouldThrowOtherException2()
        {
            ExWrapper.Try<ArgumentNullException, object>(
                () => { throw new ArgumentException(); });
        }
    }
}
