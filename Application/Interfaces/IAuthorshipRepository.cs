using Domain.Entities;
namespace Application.Interfaces
{
    public interface IAuthorshipRepository
    {
        Task<Authorship> AddAuthorshipAsync(Authorship authorship, CancellationToken ct = default);
        Task<Authorship?> GetAuthorshipByIdAsync(Guid authorshipId, CancellationToken ct = default);
        Task<List<Authorship>> GetAuthorshipByUserIdAsync(Guid userId, CancellationToken ct = default);
        Task<int> DeleteAuthorshipByIdAsync(Guid authorshipId, CancellationToken ct = default);
    }
}