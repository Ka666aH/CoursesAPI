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

        public void DeleteEnrollment(Enrollment enrollment)
        {
            _db.Enrollments.Remove(enrollment);
        }
        public async Task<List<Enrollment>> GetEnrollmentByCourseIdAsync(Guid courseId, CancellationToken ct = default)
        {
            return await _db.Enrollments.AsNoTracking().Where(e => e.CourseId == courseId).ToListAsync(ct);
        }

        public Task<Enrollment> GetEnrollmentByUserIdAndCourseIdAsync(Guid userId, Guid courseId, CancellationToken ct = default)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Enrollment>> GetEnrollmentByUserIdAsync(Guid userId, CancellationToken ct = default)
        {
            return await _db.Enrollments.AsNoTracking().Where(e => e.UserId == userId).ToListAsync(ct);
        }
    }
}