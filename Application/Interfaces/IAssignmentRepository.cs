using Domain.Entities;
namespace Application.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<Assignment> AddAssignmentAsync(Assignment assignment, Module module, CancellationToken ct = default);
        Task<Assignment?> GetAssignmentByIdAsync(Guid assignmentId, CancellationToken ct = default);
        Task<List<Assignment>> GetAssignmentsByModuleIdAsync(Guid moduleId, CancellationToken ct = default);
        Task UpdateAssignmentAsync(Assignment assignment, CancellationToken ct = default);
        Task<bool> DeleteAssignmentByIdAsync(Guid assignmentId, CancellationToken ct = default);
    }
}