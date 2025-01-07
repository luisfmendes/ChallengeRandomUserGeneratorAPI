using System.Text.Json.Serialization;

namespace ChallengeRandomUserGeneratorAPI.Domain.Entities
{
    public class Dob
    {
        [JsonPropertyName("date")]
        public string Date { get; set; }

        [JsonPropertyName("age")]
        public int Age { get; set; }
    }
}
