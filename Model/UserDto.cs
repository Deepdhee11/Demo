using System.Text.Json.Serialization;

namespace DemoApplication.Model
{
    public class UserDto
    {
        [JsonPropertyName("id")]
        public int id { get; set; }

        [JsonPropertyName("email")]
        public string Email { get; set; }

        [JsonPropertyName("first_name")]
        public string FirstName { get; set; }

        [JsonPropertyName("Last_name")]
        public string last_name { get; set; }

        [JsonPropertyName("avatar")]
        public string? Avatar { get; set; }
    }
}
