using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class SubmissionsRepository : ISubmissionRepository
    {
        private readonly PostgreDBContext _db;
        public SubmissionsRepository(PostgreDBContext db) => _db = db;
        public async Task AddSubmissionAsync(Submission submission, CancellationToken ct = default)
        {
            await _db.Submissions.AddAsync(submission, ct);
        }

        public async Task<bool> DeleteSubmissionByIdAsync(Guid submissionId, CancellationToken ct = default)
        {
            var rowAffected = await _db.Submissions.Where(s => s.Id == submissionId).ExecuteDeleteAsync(ct);
            return rowAffected > 0;
        }

        public async Task<Submission?> GetSubmissionByIdAsync(Guid submissionId, CancellationToken ct = default)
        {
            return await _db.Submissions.AsNoTracking().FirstOrDefaultAsync(s => s.Id == submissionId, ct);
        }

        public async Task<List<Submission>> GetSubmissionsByAssignmentIdAndUserIdAsync(Guid assignmentId, Guid userId, CancellationToken ct = default)
        {
            return await _db.Submissions.AsNoTracking().Where(s => s.AssignmentId == assignmentId && s.UserId == userId).ToListAsync(ct);
        }

        public async Task<List<Submission>> GetSubmissionsByAssignmentIdAsync(Guid assignmentId, CancellationToken ct = default)
        {
            return await _db.Submissions.AsNoTracking().Where(s => s.AssignmentId == assignmentId).ToListAsync(ct);
        }

        public async Task<List<Submission>> GetSubmissionsByUserIdAsync(Guid userId, CancellationToken ct = default)
        {
            return await _db.Submissions.AsNoTracking().Where(s => s.UserId == userId).ToListAsync(ct);
        }
    }
}