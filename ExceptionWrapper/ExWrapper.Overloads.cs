using System;
using JetBrains.Annotations;


namespace ExceptionWrapper
{
    public static partial class ExWrapper
    {
        /// <summary>
        /// Executes "methodToExecute" and catches all exceptions it may throw.
        /// Exception details are not available to the caller.
        /// </summary>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <returns>True if no exception has been thrown.</returns>
        public static bool Try([NotNull] Action methodToExecute)
        {
            return Try<Exception>(methodToExecute);
        }

        /// <summary>
        /// Executes "methodToExecute" and catches all exceptions it may throw.
        /// If an exception is thrown, "methodOnException" is executed.
        /// </summary>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <param name="methodOnException">The method to execute when an exception is thrown.</param>
        /// <returns>True if no exception has been thrown.</returns>
        public static bool Try([NotNull] Action methodToExecute, [CanBeNull] Action methodOnException)
        {
            return Try<Exception>(methodToExecute, methodOnException);
        }

        /// <summary>
        /// Executes "methodToExecute" and catches all exceptions it may throw.
        /// If an exception is thrown, "methodOnException" is executed.
        /// </summary>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <param name="methodOnException">The method to execute when an exception is thrown.</param>
        /// <returns>True if no exception has been thrown.</returns>
        public static bool Try([NotNull] Action methodToExecute, [CanBeNull] Action<Exception> methodOnException)
        {
            return Try<Exception>(methodToExecute, methodOnException);
        }

        /// <summary>
        /// Executes "methodToExecute" and catches all exceptions of type TException it may throw.
        /// Exception details are not available to the caller.
        /// </summary>
        /// <typeparam name="TException">The type of Exception to catch.</typeparam>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <returns>True if no exception has been thrown.</returns>
        public static bool Try<TException>([NotNull] Action methodToExecute)
            where TException : Exception
        {
            return Try<TException>(methodToExecute, (Action)null);
        }

        /// <summary>
        /// Executes "methodToExecute" and catches all exceptions of type TException it may throw.
        /// If an exception is thrown, "methodOnException" is executed.
        /// </summary>
        /// <typeparam name="TException">The type of Exception to catch.</typeparam>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <param name="methodOnException">The method to execute when an exception is thrown.</param>
        /// <returns>True if no exception has been thrown.</returns>
        public static bool Try<TException>([NotNull] Action methodToExecute, [CanBeNull] Action methodOnException)
            where TException : Exception
        {
            var methodOnError = WrapperHelper.GetDefaultExceptionWrapper<TException>(methodOnException);
            return Try(methodToExecute, methodOnError);
        }

        /// <summary>
        /// Executes "methodToExecute" and catches all exceptions of type TException it may throw.
        /// Exception details are not available to the caller.
        /// </summary>
        /// <typeparam name="TException">The type of Exception to catch.</typeparam>
        /// <typeparam name="TReturn">The type of the return value.</typeparam>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <returns>
        /// The value returned by "methodToExecute" if it succeeds.
        /// In case of failure, it returns the default value of TReturn.
        /// </returns>
        public static TReturn Try<TException, TReturn>([NotNull] Func<TReturn> methodToExecute)
            where TException : Exception
        {
            return Try<TException, TReturn>(methodToExecute, (Action)null);
        }

        /// <summary>
        /// Executes "methodToExecute" and catches all exceptions of type TException it may throw.
        /// If an exception is thrown, "methodOnException" is executed.
        /// </summary>
        /// <typeparam name="TException">The type of Exception to catch.</typeparam>
        /// <typeparam name="TReturn">The type of the return value.</typeparam>
        /// <param name="methodToExecute">The method to execute.</param>
        /// <param name="methodOnException">The method to execute when an exception is thrown.</param>
        /// <returns>
        /// The value returned by "methodToExecute" if it succeeds.
        /// In case of failure, it returns the default value of TReturn.
        /// </returns>
        public static TReturn Try<TException, TReturn>([NotNull] Func<TReturn> methodToExecute,
                                                       [CanBeNull] Action methodOnException)
            where TException : Exception
        {
            var methodOnError = WrapperHelper.GetDefaultExceptionWrapper<TException>(methodOnException);
            return Try(methodToExecute, methodOnError);
        }
    }
}
