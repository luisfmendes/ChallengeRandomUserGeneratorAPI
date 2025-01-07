using System;
using System.Text.Json.Serialization;

namespace ChallengeRandomUserGeneratorAPI.Domain.Entities
{
    public class Location
    {
        [JsonPropertyName("street")]
        public Street Street { get; set; }

        [JsonPropertyName("city")]
        public string City { get; set; }

        [JsonPropertyName("state")]
        public string State { get; set; }

        [JsonPropertyName("country")]
        public string Country { get; set; }

        [JsonPropertyName("postcode")]
        public int Postcode { get; set; }

        [JsonPropertyName("coordinates")]
        public Coordinates Coordinates { get; set; }

        [JsonPropertyName("timezone")]
        public Timezone Timezone { get; set; }
    }
}
