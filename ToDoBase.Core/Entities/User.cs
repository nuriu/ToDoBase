using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace ToDoBase.Core.Entities
{
    public class User : BaseEntity
    {
        [JsonPropertyName("username")]
        public string Username { get; set; }

        [JsonPropertyName("password")]
        public string Password { get; set; }

        [JsonPropertyName("toDoItems")]
        public List<ToDoItem> ToDoItems { get; set; }

        [JsonPropertyName("type")]
        public string Type => "user";
    }
}
