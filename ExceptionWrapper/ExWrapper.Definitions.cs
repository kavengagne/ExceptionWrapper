using System;
using JetBrains.Annotations;


namespace ExceptionWrapper
{
    public static partial class ExWrapper
    {
        /// <summary>
        /// Executes "methodToExecute" and catches all exceptions of type TException it may throw.
        /// If an exception is thrown, "methodOnException" is executed.
        /// </summary>
        /// <typeparam name="TException">The type of Exception to catch.</typeparam>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <param name="methodOnException">The method to execute when an exception is thrown.</param>
        /// <returns>True if no exception has been thrown.</returns>
        public static bool Try<TException>([NotNull] Action methodToExecute,
                                           [CanBeNull] Action<TException> methodOnException)
            where TException : Exception
        {
            if (methodToExecute == null)
            {
                throw new ArgumentNullException(nameof(methodToExecute), "Method to execute cannot be null.");
            }
            try
            {
                methodToExecute.Invoke();
                return true;
            }
            catch (TException ex)
            {
                methodOnException?.Invoke(ex);
                return false;
            }
        }

        /// <summary>
        /// Executes "methodToExecute" and catches all exceptions of type TException it may throw.
        /// If an exception is thrown, "methodOnException" is executed.
        /// </summary>
        /// <typeparam name="TException">The type of Exception to catch.</typeparam>
        /// <typeparam name="TReturn">The type of the return value.</typeparam>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <param name="methodOnException">The method to execute when an exception is thrown.</param>
        /// <returns>True if no exception has been thrown.</returns>
        public static TReturn Try<TException, TReturn>([NotNull] Func<TReturn> methodToExecute,
                                                       [CanBeNull] Action<TException> methodOnException)
            where TException : Exception
        {
            if (methodToExecute == null)
            {
                throw new ArgumentNullException(nameof(methodToExecute), "Method to execute cannot be null.");
            }
            try
            {
                return methodToExecute.Invoke();
            }
            catch (TException ex)
            {
                if (methodOnException != null)
                {
                    methodOnException.Invoke(ex);
                    return default(TReturn);
                }
                return default(TReturn);
            }
        }
    }
}
