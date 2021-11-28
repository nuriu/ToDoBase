using System.Text.Json.Serialization;

namespace ToDoBase.Core.Entities
{
    public class ToDoItem : BaseEntity
    {
        [JsonPropertyName("title")]
        public string Title { get; set; }

        [JsonPropertyName("description")]
        public string Description { get; set; }

        [JsonPropertyName("isDone")]
        public bool IsDone { get; set; }

        [JsonPropertyName("creator")]
        public User Creator { get; set; }

        [JsonPropertyName("type")]
        public string Type => "todoitem";
    }
}
