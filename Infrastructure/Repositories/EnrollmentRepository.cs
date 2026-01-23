using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class EnrollmentRepository : IEnrollmentRepository
    {
        private readonly PostgreDBContext _db;
        public EnrollmentRepository(PostgreDBContext db) => _db = db;
        public async Task AddEnrollmentAsync(Enrollment enrollment, CancellationToken ct = default)
        {
            await _db.Enrollments.AddAsync(enrollment, ct);
        }

        public async Task<bool> DeleteEnrollmentByIdAsync(Guid userId, Guid courseId, CancellationToken ct = default)
        {
            var rowAffected = await _db.Enrollments.Where(e => e.UserId == userId && e.CourseId == courseId).ExecuteDeleteAsync(ct);
            return rowAffected > 0;
        }

        public async Task<List<Enrollment>> GetEnrollmentByCourseIdAsync(Guid courseId, CancellationToken ct = default)
        {
            return await _db.Enrollments.AsNoTracking().Where(e => e.CourseId == courseId).ToListAsync(ct);
        }

        public async Task<List<Enrollment>> GetEnrollmentByUserIdAsync(Guid userId, CancellationToken ct = default)
        {
            return await _db.Enrollments.AsNoTracking().Where(e => e.UserId == userId).ToListAsync(ct);
        }
    }
}