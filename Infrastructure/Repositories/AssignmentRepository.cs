using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class AssignmentRepository : IAssignmentRepository
    {
        private readonly PostgreDBContext _db;
        public AssignmentRepository(PostgreDBContext db) => _db = db;
        public async Task<bool> AddAssignmentAsync(Assignment assignment, Guid moduleId, CancellationToken ct = default)
        {
            var module = await _db.Modules.FindAsync(moduleId, ct);
            if (module == null) return false;

            await _db.Assignments.AddAsync(assignment, ct);

            return true;
        }

        public void DeleteAssignment(Assignment assignment)
        {
            _db.Assignments.Remove(assignment);
        }

        public async Task<Assignment?> GetAssignmentByIdAsync(Guid assignmentId, CancellationToken ct = default)
        {
            return await _db.Assignments.AsNoTracking().FirstOrDefaultAsync(a => a.Id == assignmentId, ct);
        }

        public async Task<List<Assignment>> GetAssignmentsByModuleIdAsync(Guid moduleId, CancellationToken ct = default)
        {
            return await _db.Assignments.AsNoTracking().Where(a => a.ModuleId == moduleId).ToListAsync(ct);
        }

        public async Task UpdateAssignmentTitleAsync(Guid assignmentId, string newTitle, CancellationToken ct = default)
        {
            await _db.Assignments.Where(a => a.Id == assignmentId).ExecuteUpdateAsync(a => a.SetProperty(p => p.Title, newTitle), ct);
        }
    }
}