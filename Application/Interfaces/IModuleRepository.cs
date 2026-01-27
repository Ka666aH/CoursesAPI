using Domain.Entities;
namespace Application.Interfaces
{
    public interface IModuleRepository
    {
        Task<bool> AddModuleAsync(Module module, Guid courseId, CancellationToken ct = default);
        Task<Module?> GetModuleByIdAsync(Guid moduleId, CancellationToken ct = default);
        Task<List<Module>> GetModulesByCourseIdAsync(Guid courseId, CancellationToken ct = default);
        Task UpdateModuleTitleAsync(Guid moduleId, string newTitle, CancellationToken ct = default);
        Task DeleteModuleByIdAsync(Module module, CancellationToken ct = default);
    }
}