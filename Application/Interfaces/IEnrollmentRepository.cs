using Domain.Entities;
namespace Application.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task AddEnrollmentAsync(Enrollment enrollment, CancellationToken ct = default);
        Task<List<Enrollment>> GetEnrollmentByUserIdAsync(Guid userId, CancellationToken ct = default);
        Task<List<Enrollment>> GetEnrollmentByCourseIdAsync(Guid courseId, CancellationToken ct = default);
        Task<bool> DeleteEnrollmentByIdAsync(Guid userId, Guid courseId, CancellationToken ct = default);
    }
}