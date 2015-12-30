using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ExceptionWrapper.Tests
{
    [TestClass]
    public class Test_ExWrapper_Try_WhenExceptionThrownInError
    {
        [TestMethod]
        [ExpectedException(typeof(Exception), "Thrown from OnError.")]
        public void WhenExceptionThrownInError_ShouldThrowException()
        {
            ExWrapper.Try(
                () => { throw new Exception("Forces call to OnError."); },
                () => { throw new Exception("Thrown from OnError."); });
        }

        [TestMethod]
        [ExpectedException(typeof(Exception), "Thrown from OnError.")]
        public void WhenExceptionThrownInError_ShouldThrowException2()
        {
            ExWrapper.Try<Exception, object>(
                () => { throw new Exception("Forces call to OnError."); },
                () => { throw new Exception("Thrown from OnError."); });
        }
    }
}