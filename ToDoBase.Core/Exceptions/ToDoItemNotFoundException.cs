using System;

namespace ToDoBase.Core.Exceptions
{
    public class ToDoItemNotFoundException : ToDoBaseNotFoundException
    {
        public ToDoItemNotFoundException(Guid itemId) : base($"Couldn't find any to do item associated with given id.")
        {
        }

        public ToDoItemNotFoundException(Guid itemId, Exception innerException) : base($"Couldn't find any to do item associated with given id.", innerException)
        {
        }
    }
}
