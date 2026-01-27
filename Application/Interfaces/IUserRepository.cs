using Domain.Entities;
namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task AddUserAsync(User user, CancellationToken ct = default);
        Task<User?> GetUserByIdAsync(Guid userId, CancellationToken ct = default);
        Task<List<User>> GetAllUsersAsync(CancellationToken ct = default);
        Task UpdateUserAsync(User user, UserProfile profile, CancellationToken ct = default);
        Task DeleteUserByIdAsync(User user, CancellationToken ct = default);
    }
}