using System;

namespace ToDoBase.Core.Exceptions
{
    public class UserNotFoundException : ToDoBaseNotFoundException
    {
        public UserNotFoundException(string username) : base($"User '{username}' not found.")
        {
        }

        public UserNotFoundException(string username, Exception innerException) : base($"User '{username}' not found.", innerException)
        {
        }
    }
}
