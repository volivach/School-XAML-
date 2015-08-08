using System;

namespace StudentsGroup_XAML_
{
    internal class ErrorCredentialsException : Exception
    {
        public ErrorCredentialsException()
        {
        }

        public ErrorCredentialsException(string message) : base(message)
        {
        }

        public ErrorCredentialsException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}