using Application.Interfaces;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public class CoursesRepository : ICourseRepository
    {
        private readonly PostgreDBContext _db;
        public CoursesRepository(PostgreDBContext db) => _db = db;

        public async Task AddCourseAsync(Course course, CancellationToken ct = default)
        {
            await _db.Courses.AddAsync(course, ct);
        }

        public void DeleteCourse(Course course)
        {
            _db.Courses.Remove(course);
        }

        public async Task<List<Course>> GetAllCoursesAsync(CancellationToken ct = default)
        {
            return await _db.Courses
                .AsNoTracking()
                .ToListAsync(ct);
        }

        public async Task<Course?> GetCourseByIdAsync(Guid courseId, CancellationToken ct = default)
        {
            return await _db.Courses
                .AsNoTracking()
                .FirstOrDefaultAsync(c => c.Id == courseId, ct);
        }

        public async Task<List<Course>> GetCoursesByAuthorIdAsync(Guid authorId, CancellationToken ct = default)
        {
            return await _db.Courses
                .AsNoTracking()
                .Where(c => c.Authors.Any(a => a.Id == authorId))
                .ToListAsync(ct);
        }

        public async Task UpdateCourseTitleAsync(Guid courseId, string newTitle, CancellationToken ct = default)
        {
            await _db.Courses.Where(c => c.Id == courseId).ExecuteUpdateAsync(c => c.SetProperty(p => p.Title, newTitle), ct);
        }
    }
}