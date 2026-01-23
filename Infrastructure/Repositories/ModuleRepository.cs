using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class ModuleRepository : IModuleRepository
    {
        private readonly PostgreDBContext _db;
        public ModuleRepository(PostgreDBContext db) => _db = db;

        public async Task<bool> AddModuleAsync(Module module, Guid courseId, CancellationToken ct = default)
        {
            var course = await _db.Courses.FindAsync(courseId, ct);
            if (course == null) return false;

            await _db.Modules.AddAsync(module, ct);
            return true;
        }

        public async Task<bool> DeleteModuleByIdAsync(Guid moduleId, CancellationToken ct = default)
        {
            var rowAffected = await _db.Modules.Where(m => m.Id == moduleId).ExecuteDeleteAsync(ct);
            return rowAffected > 0;
        }

        public async Task<Module?> GetModuleByIdAsync(Guid moduleId, CancellationToken ct = default)
        {
            return await _db.Modules.AsNoTracking().FirstOrDefaultAsync(m => m.Id == moduleId, ct);
        }

        public async Task<List<Module>> GetModulesByCourseIdAsync(Guid courseId, CancellationToken ct = default)
        {
            return await _db.Modules.AsNoTracking().Where(m => m.CourseId == courseId).ToListAsync(ct);
        }

        public async Task<bool> UpdateModuleTitleAsync(Guid moduleId, string newTitle, CancellationToken ct = default)
        {
            var rowAffected = await _db.Modules
                .Where(m => m.Id == moduleId)
                .ExecuteUpdateAsync(m => m.SetProperty(p => p.Title, newTitle), ct);
            return rowAffected > 0;
        }
    }
}