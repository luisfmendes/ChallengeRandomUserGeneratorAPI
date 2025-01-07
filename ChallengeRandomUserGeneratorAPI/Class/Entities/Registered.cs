using System.Text.Json.Serialization;

namespace ChallengeRandomUserGeneratorAPI.Domain.Entities
{
    public class Registered
    {
        [JsonPropertyName("dateRegistered")]
        public string? DateRegistered { get; set; }

        [JsonPropertyName("ageRegistered")]
        public int AgeRegistered { get; set; }
    }
}
