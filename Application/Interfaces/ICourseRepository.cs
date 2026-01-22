using Domain.Entities;
namespace Application.Interfaces
{
    public interface ICourseRepository
    {
        Task<Course> AddCourseAsync(Course course, CancellationToken ct = default);
        Task<Course?> GetCourseByIdAsync(Guid courseId, CancellationToken ct = default);
        Task<List<Course>> GetAllCoursesAsync(CancellationToken ct = default);
        Task<List<Course>> GetCoursesByAuthorIdAsync(Guid authorId, CancellationToken ct = default);
        Task UpdateCourseAsync(Course course, CancellationToken ct = default);
        Task<int> DeleteCourseByIdAsync(Guid courseId, CancellationToken ct = default);
    }
}