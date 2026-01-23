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

        public async Task<bool> DeleteUserByIdAsync(Guid userId, CancellationToken ct = default)
        {
            var rowAffected = await _db.Users
                .Where(u => u.Id == userId)
                .ExecuteDeleteAsync(ct);
            return rowAffected > 0;
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
                .AsNoTracking()
                .FirstOrDefaultAsync(u => u.Id == userId, ct);
        }
        public async Task<bool> UpdateUserAsync(User user, CancellationToken ct = default)
        {
            //await _db.Users.Where(u => u.Id == user.Id).ExecuteUpdateAsync(u =>
            //{
            //    u.SetProperty(p => p.Name, user.Name);
            //    u.SetProperty(p => p.Email, user.Email);
            //    u.SetProperty(p => p.Profile, user.Profile); //не работает?
            //}, ct);
            var exitstingUser = await _db.Users.FindAsync(user.Id, ct);
            if (exitstingUser == null) return false;

            exitstingUser.Name = user.Name;
            exitstingUser.Email = user.Email;
            exitstingUser.Profile = user.Profile;

            return true;
        }
    }
}