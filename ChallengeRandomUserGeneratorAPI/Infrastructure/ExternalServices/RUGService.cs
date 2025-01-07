using Microsoft.EntityFrameworkCore;
using ChallengeRandomUserGeneratorAPI.Application.Interfaces;
using ChallengeRandomUserGeneratorAPI.Domain.Entities;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace ChallengeRandomUserGeneratorAPI.Infrastructure.ExternalServices
{
    public class RUGService : IRandomUserGeneratorService
    {
        private readonly HttpClient _httpClient;

        public RUGService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<User>> GetRandomUserAsync(int count)
        {
            var response = await _httpClient.GetStringAsync($"https://randomuser.me/api/?nat=br&results={count}");
            var apiResponse = JsonSerializer.Deserialize<ApiResponse>(response);
            
            return apiResponse.Results;
        }

        private class ApiResponse
        {
            [JsonPropertyName("results")]
            public List<User> Results { get; set; }

            [JsonPropertyName("info")]
            public Info Info { get; set; }
        }
    }
}
