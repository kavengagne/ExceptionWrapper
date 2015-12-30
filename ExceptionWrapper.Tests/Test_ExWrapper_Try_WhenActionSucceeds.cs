using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionWrapper.Tests
{
    [TestClass]
    public class Test_ExWrapper_Try_WhenActionSucceeds
    {
        [TestMethod]
        public void WhenActionSucceeds_ShouldNotRunOnErrorAndReturnTrue()
        {
            var isOnErrorExecuted = false;

            var returnValue = ExWrapper.Try(
                () => { },
                () => { isOnErrorExecuted = true; });

            Assert.IsTrue(returnValue);
            Assert.IsFalse(isOnErrorExecuted);
        }

        [TestMethod]
        public void WhenActionSucceeds_ShouldNotRunOnErrorAndReturnTwo()
        {
            var isOnErrorExecuted = false;

            var returnValue = ExWrapper.Try<Exception, object>(
                () => 1 + 1,
                ex => { isOnErrorExecuted = true; });

            Assert.AreEqual(1, returnValue);
            Assert.IsFalse(isOnErrorExecuted);
        }
    }
}
