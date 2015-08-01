using System;
using System.Runtime.Serialization;

namespace StudentsGroup
{
    internal class ClassFullException : Exception
    {
        public ClassFullException()
        {
        }

        public ClassFullException(string message) : base(message)
        {
        }

        public ClassFullException(string message, Exception innerException) : base(message, innerException)
        {
        }

    }
}