using Domain.Entities;
namespace Application.Interfaces
{
    public interface IAssignmentRepository
    {
        Task<bool> AddAssignmentAsync(Assignment assignment, Guid moduleId, CancellationToken ct = default);
        Task<Assignment?> GetAssignmentByIdAsync(Guid assignmentId, CancellationToken ct = default);
        Task<List<Assignment>> GetAssignmentsByModuleIdAsync(Guid moduleId, CancellationToken ct = default);
        Task UpdateAssignmentTitleAsync(Guid assignmentId,string newTitle, CancellationToken ct = default);
        void DeleteAssignment(Assignment assignment);
    }
}