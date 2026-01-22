using Domain.Entities;
namespace Application.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task<Enrollment> AddEnrollmentAsync(Enrollment enrollment, CancellationToken ct = default);
        Task<Enrollment?> GetEnrollmentByIdAsync(Guid enrollmentId, CancellationToken ct = default);
        Task<int> DeleteEnrollmentByIdAsync(Guid enrollmentId, CancellationToken ct = default);
    }
}