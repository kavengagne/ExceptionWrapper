using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ExceptionWrapper.Tests
{
    [TestClass]
    public class Test_ExWrapper_Try_WhenActionIsNull
    {
        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenActionIsNull_ShouldThrowArgumentNullException()
        {
            ExWrapper.Try(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void WhenActionIsNull_ShouldThrowArgumentNullException2()
        {
            ExWrapper.Try<Exception, object>(null);
        }
    }
}
