using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly PostgreDBContext _db;
        public UserRepository(PostgreDBContext db) => _db = db;
        public async Task AddUserAsync(User user, CancellationToken ct = default)
        {
            await _db.Users.AddAsync(user, ct);
        }

        public void DeleteUser(User user)
        {
            _db.Users.Remove(user);
        }

        public async Task<List<User>> GetAllUsersAsync(CancellationToken ct = default)
        {
            return await _db.Users
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<User?> GetUserByIdAsync(Guid userId, CancellationToken ct = default)
        {
            return await _db.Users
                //.AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId, ct);
        }
        public async Task UpdateUserAsync(User user, UserProfile profile, CancellationToken ct = default)
        {
            user.Profile = profile;
        }
    }
}