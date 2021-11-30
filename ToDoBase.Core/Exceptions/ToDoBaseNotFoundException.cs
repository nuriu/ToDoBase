using System;

namespace ToDoBase.Core.Exceptions
{
    public abstract class ToDoBaseNotFoundException : Exception
    {
        protected ToDoBaseNotFoundException(string message) : base(message)
        {
        }

        protected ToDoBaseNotFoundException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
