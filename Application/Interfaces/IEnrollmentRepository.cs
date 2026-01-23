using Domain.Entities;
namespace Application.Interfaces
{
    public interface IEnrollmentRepository
    {
        Task AddEnrollmentAsync(Enrollment enrollment, CancellationToken ct = default);
        Task<Enrollment?> GetEnrollmentByIdAsync(Guid enrollmentId, CancellationToken ct = default);
        Task<bool> DeleteEnrollmentByIdAsync(Guid enrollmentId, CancellationToken ct = default);
    }
}