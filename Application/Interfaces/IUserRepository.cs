using Domain.Entities;
namespace Application.Interfaces
{
    public interface IUserRepository
    {
        Task<User> AddUserAsync(User user, CancellationToken ct = default);
        Task<User?> GetUserByIdAsync(Guid userId, CancellationToken ct = default);
        Task<List<User>> GetAllUsersAsync(CancellationToken ct = default);
        Task UpdateUserAsync(User user, CancellationToken ct = default);
        Task<int> DeleteUserByIdAsync(Guid userId, CancellationToken ct = default);
    }
}