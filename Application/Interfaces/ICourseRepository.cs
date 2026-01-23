using Domain.Entities;
namespace Application.Interfaces
{
    public interface ICourseRepository
    {
        Task AddCourseAsync(Course course, CancellationToken ct = default);
        Task<Course?> GetCourseByIdAsync(Guid courseId, CancellationToken ct = default);
        Task<List<Course>> GetAllCoursesAsync(CancellationToken ct = default);
        Task<List<Course>> GetCoursesByAuthorIdAsync(Guid authorId, CancellationToken ct = default);
        Task<bool> UpdateCourseTitleAsync(Guid courseId, string newTitle, CancellationToken ct = default);
        Task<bool> DeleteCourseByIdAsync(Guid courseId, CancellationToken ct = default);
    }
}