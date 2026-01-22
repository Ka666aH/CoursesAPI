using Domain.Entities;
namespace Application.Interfaces
{
    public interface ISubmissionRepository
    {
        Task<Submission> AddSubmissionAsync(Submission submission, CancellationToken ct = default);
        Task<Submission?> GetSubmissionByIdAsync(Guid submissionId, CancellationToken ct = default);
        Task<List<Submission>> GetSubmissionsByAssignmentIdAsync(Guid assignmentId, CancellationToken ct = default);
        Task<List<Submission>> GetSubmissionsByUserIdAsync(Guid userId, CancellationToken ct = default);
        Task<List<Submission>> GetSubmissionsByAssignmentIdAndUserIdAsync(Guid assignmentId, Guid userId, CancellationToken ct = default);
        Task<int> DeleteSubmissionByIdAsync(Guid submissionId, CancellationToken ct = default);
    }
}