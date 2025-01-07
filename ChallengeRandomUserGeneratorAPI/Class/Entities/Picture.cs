using System.Text.Json.Serialization;

namespace ChallengeRandomUserGeneratorAPI.Domain.Entities
{
    public class Picture
    {
        [JsonPropertyName("large")]
        public string? Large { get; set; }

        [JsonPropertyName("medium")]
        public string? Medium { get; set; }

        [JsonPropertyName("thumbnail")]
        public string? Thumbnail { get; set; }
    }
}
