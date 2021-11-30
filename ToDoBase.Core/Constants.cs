using System;
using ToDoBase.Core.Extensions;

namespace ToDoBase.Core
{
    public static class Constants
    {
        public static string JWTSecret = "ToDoBase.Api.Development";

        public static string CB_HOST = Environment.GetEnvironmentVariable("CB_HOST").DefaultIfEmpty("localhost");
        public static string CB_USER = Environment.GetEnvironmentVariable("CB_USER").DefaultIfEmpty("todoadmin");
        public static string CB_PASS = Environment.GetEnvironmentVariable("CB_PASS").DefaultIfEmpty("todoadmin");
        public static string CB_BUCKET = Environment.GetEnvironmentVariable("CB_BUCKET").DefaultIfEmpty("todos");
        public static string CB_USERS_COLLECTION = Environment.GetEnvironmentVariable("CB_USERS_COLLECTION").DefaultIfEmpty("users");
        public static string CB_TODO_ITEMS_COLLECTION = Environment.GetEnvironmentVariable("CB_TODO_ITEMS_COLLECTION").DefaultIfEmpty("todoitems");
    }
}
