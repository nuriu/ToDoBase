using System;
using System.Runtime.Serialization;

namespace ToDoBase.Core.Exceptions
{
    public abstract class ToDoBaseException : Exception
    {
        protected ToDoBaseException() : base()
        {
        }

        protected ToDoBaseException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected ToDoBaseException(string message) : base(message)
        {
        }

        protected ToDoBaseException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
