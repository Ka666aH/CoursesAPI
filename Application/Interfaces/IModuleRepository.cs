using Domain.Entities;
namespace Application.Interfaces
{
    public interface IModuleRepository
    {
        Task<Module> AddModuleAsync(Module module, Course course, CancellationToken ct = default);
        Task<Module?> GetModuleByIdAsync(Guid moduleId, CancellationToken ct = default);
        Task<List<Module>> GetModulesByCourseIdAsync(Guid courseId, CancellationToken ct = default);
        Task UpdateModuleAsync(Module module, CancellationToken ct = default);
        Task<bool> DeleteModuleByIdAsync(Guid moduleId, CancellationToken ct = default);
    }
}