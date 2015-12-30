using System;


namespace ExceptionWrapper
{
    internal static class WrapperHelper
    {
        public static Action<TException> GetDefaultExceptionWrapper<TException>(Action methodOnException)
            where TException : Exception
        {
            Action<TException> methodOnError = e => { };
            if (methodOnException != null)
            {
                methodOnError = e => methodOnException();
            }
            return methodOnError;
        }
    }
}