using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AuthorshipRepository : IAuthorshipRepository
    {
        private readonly PostgreDBContext _db;
        public AuthorshipRepository(PostgreDBContext db) => _db = db;
        public async Task AddAuthorshipAsync(Authorship authorship, CancellationToken ct = default)
        {
            await _db.Authorships.AddAsync(authorship, ct);
        }

        public void DeleteAuthorship(Authorship authorship)
        {
            _db.Authorships.Remove(authorship);
        }

        public async Task<Authorship?> GetAuthorshipByIdAsync(Guid authorshipId, CancellationToken ct = default)
        {
            return await _db.Authorships.AsNoTracking().FirstOrDefaultAsync(a => a.Id == authorshipId, ct);
        }

        public async Task<List<Authorship>> GetAuthorshipByUserIdAsync(Guid userId, CancellationToken ct = default)
        {
            return await _db.Authorships.AsNoTracking().Where(a => a.UserId == userId).ToListAsync(ct);
        }
    }
}