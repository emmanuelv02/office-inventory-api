using OfficeInventorySystem.Application.DTOs;

namespace OfficeInventorySystem.Application.Interfaces
{
    public interface IEquipmentService
    {
        Task<IEnumerable<MaintenanceTaskDto>> GetEquipmentMaintenanceTasksAsync(int equipmentId);
        Task<EquipmentDto?> GetEquipmentByIdAsync(int id);
        Task<IEnumerable<EquipmentDto>> GetAllEquipmentAsync();
        Task<EquipmentDto> CreateEquipmentAsync(EquipmentDto createEquipmentDto);
        Task UpdateEquipmentAsync(int id, EquipmentDto updateEquipmentDto);
        Task DeleteEquipmentAsync(int id);
        Task DeleteEquipmentMaintenanceAsync(int equipmentId, int maintenanceId);
        Task AssignMaintenanceTaskToEquipmentAsync(int equipmentId, int maintenanceTaskId);
    }
}
