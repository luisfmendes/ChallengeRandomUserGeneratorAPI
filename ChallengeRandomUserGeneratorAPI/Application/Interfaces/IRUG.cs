using ChallengeRandomUserGeneratorAPI.Domain.Entities;

namespace ChallengeRandomUserGeneratorAPI.Application.Interfaces
{
    public interface IRandomUserGeneratorService
    {
        Task<List<User>> GetRandomUserAsync(int count);
    }
}
