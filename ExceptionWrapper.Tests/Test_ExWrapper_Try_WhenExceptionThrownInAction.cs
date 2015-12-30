using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;


namespace ExceptionWrapper.Tests
{
    [TestClass]
    public class Test_ExWrapper_Try_WhenExceptionThrownInAction
    {
        [TestMethod]
        public void WhenExceptionThrownInAction_ShouldNotThrowExceptionAndReturnFalse()
        {
            var returnValue = false;
            try
            {
                returnValue = ExWrapper.Try(
                    () => { throw new Exception("Throw that!"); });
            }
            catch (Exception)
            {
                Assert.Fail("Should not throw Exception.");
            }
            finally
            {
                Assert.IsFalse(returnValue);
            }
        }

        [TestMethod]
        public void WhenExceptionThrownInAction_ShouldNotThrowExceptionAndReturnDefault()
        {
            var returnValue = new object();
            try
            {
                returnValue = ExWrapper.Try<Exception, object>(
                    () => { throw new Exception("Throw that!"); });
            }
            catch (Exception)
            {
                Assert.Fail("Should not throw Exception.");
            }
            finally
            {
                Assert.AreEqual(default(object), returnValue);
            }
        }

        [TestMethod]
        public void WhenExceptionThrownInAction_ShouldRunOnErrorAndReturnFalse()
        {
            var isOnErrorExecuted = false;

            var returnValue = ExWrapper.Try(
                () => { throw new Exception("Crash, MOFO!."); },
                () => { isOnErrorExecuted = true; });

            Assert.IsFalse(returnValue);
            Assert.IsTrue(isOnErrorExecuted);
        }

        [TestMethod]
        public void WhenExceptionThrownInAction_ShouldRunOnErrorAndReturnDefault()
        {
            var isOnErrorExecuted = false;

            var returnValue = ExWrapper.Try<Exception, object>(
                () => { throw new Exception("Crash, MOFO!."); },
                () => { isOnErrorExecuted = true; });

            Assert.AreEqual(default(object), returnValue);
            Assert.IsTrue(isOnErrorExecuted);
        }

        [TestMethod]
        public void WhenExceptionThrownInAction_ShouldRunOnErrorWithExceptionAndReturnFalse()
        {
            Exception receivedException = null;
            Exception thrownException = null;

            ExWrapper.Try(
                () =>
                {
                    thrownException = new Exception("Get that!");
                    throw thrownException;
                },
                ex => { receivedException = ex; });

            Assert.AreEqual(thrownException, receivedException);
            Assert.AreEqual(thrownException.Message, receivedException.Message);
        }

        [TestMethod]
        public void WhenExceptionThrownInAction_ShouldRunOnErrorWithExceptionAndReturnDefault()
        {
            Exception receivedException = null;
            Exception thrownException = null;

            var returnValue = ExWrapper.Try<Exception, object>(
                () =>
                {
                    thrownException = new Exception("Get that!");
                    throw thrownException;
                },
                ex => { receivedException = ex; });

            Assert.AreEqual(thrownException, receivedException);
            Assert.AreEqual(thrownException.Message, receivedException.Message);
            Assert.AreEqual(default(object), returnValue);
        }
    }
}