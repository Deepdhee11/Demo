using System;
using System.Text.Json.Serialization;
using Newtonsoft.Json;

namespace DemoApplication.Model
{
	public class UsersDto
	{
        [JsonPropertyName("page")]
        public int Page { get; set; }

        [JsonPropertyName("per_page")]
        public int Per_page { get; set; }

        [JsonPropertyName("total")]
        public int Total { get; set; }

        [JsonPropertyName("total_pages")]
        public int Total_pages { get; set; }

        [JsonPropertyName("data")]
        public IEnumerable<UserDto> Data { get; set; }
        [JsonPropertyName("support")]
        public SupportDto Support { get; set; }
    }
    public class SupportDto
    {
        [JsonPropertyName("url")]
        public string url { get; set; }
        [JsonPropertyName("text")]
        public string text { get; set; }
    }
}

