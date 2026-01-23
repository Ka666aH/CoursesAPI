using Domain.Entities;
namespace Application.Interfaces
{
    public interface IModuleRepository
    {
        Task AddModuleAsync(Module module, Course course, CancellationToken ct = default);
        Task<Module?> GetModuleByIdAsync(Guid moduleId, CancellationToken ct = default);
        Task<List<Module>> GetModulesByCourseIdAsync(Guid courseId, CancellationToken ct = default);
        Task<bool> UpdateModuleTitleAsync(Guid moduleId, string newTitle, CancellationToken ct = default);
        Task<bool> DeleteModuleByIdAsync(Guid moduleId, CancellationToken ct = default);
    }
}