using System;
using System.Text.Json.Serialization;

namespace ToDoBase.Core.Entities
{
    public class BaseEntity
    {
        [JsonPropertyName("id")]
        public Guid Id { get; set; }

        [JsonPropertyName("createdAt")]
        public DateTime CreatedAt { get; set; }

        [JsonPropertyName("updatedAt")]
        public DateTime UpdatedAt { get; set; }
    }
}
