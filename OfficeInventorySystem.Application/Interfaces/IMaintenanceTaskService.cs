using OfficeInventorySystem.Application.DTOs;

namespace OfficeInventorySystem.Application.Interfaces
{
    public interface IMaintenanceTaskService
    { 
        Task<MaintenanceTaskDto?> GetMaintenanceTaskByIdAsync(int id);
        Task<IEnumerable<MaintenanceTaskDto>> GetAllMaintenanceTaskAsync();
        Task<MaintenanceTaskDto> CreateMaintenanceTaskAsync(MaintenanceTaskDto createMaintenanceTaskDto);
        Task UpdateMaintenanceTaskAsync(int id, MaintenanceTaskDto updateMaintenanceTaskDto);
        Task DeleteMaintenanceTaskAsync(int id);
    }
}
