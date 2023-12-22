using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace Front.Entities
{
    public class Todo
    {
        [Required]
        [JsonPropertyName("id")]
        public int Id { get; set; }

        [Required]
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [Required]
        [JsonPropertyName("isDone")]
        public bool IsDone { get; set; }

    }

    public class TodoCreate
    {
        public required string Text { get; set; }
        public bool IsDone { get; set; }
    }
}
