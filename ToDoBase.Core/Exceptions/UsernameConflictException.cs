using System;

namespace ToDoBase.Core.Exceptions
{
    public class UsernameConflictException : ToDoBaseBadRequestException
    {
        public UsernameConflictException(string username) : base($"Username '{username}' already taken.")
        {
        }

        public UsernameConflictException(string username, Exception innerException) : base($"Username '{username}' already taken.", innerException)
        {
        }
    }
}
