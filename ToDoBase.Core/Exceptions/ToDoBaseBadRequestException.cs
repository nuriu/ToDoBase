using System;
using System.Runtime.Serialization;

namespace ToDoBase.Core.Exceptions
{
    public abstract class ToDoBaseBadRequestException : Exception
    {
        protected ToDoBaseBadRequestException() : base()
        {
        }

        protected ToDoBaseBadRequestException(SerializationInfo info, StreamingContext context) : base(info, context)
        {
        }

        protected ToDoBaseBadRequestException(string message) : base(message)
        {
        }

        protected ToDoBaseBadRequestException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
