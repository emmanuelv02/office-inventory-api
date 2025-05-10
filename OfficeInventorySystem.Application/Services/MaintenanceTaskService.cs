using OfficeInventorySystem.Application.DTOs;
using OfficeInventorySystem.Application.Interfaces;
using OfficeInventorySystem.Application.Mappers;
using OfficeInventorySystem.Domain.Entities;
using OfficeInventorySystem.Domain.Interfaces;

namespace OfficeInventorySystem.Application.Services
{
    public class MaintenanceTaskService(IRepository<MaintenanceTask> maintenanceTaskRepository) : IMaintenanceTaskService
    {
        public async Task<MaintenanceTaskDto?> GetMaintenanceTaskByIdAsync(int id)
        {
            var maintenanceTask = await maintenanceTaskRepository.GetByIdAsync(id, i => i.EquipmentMaintenances);
            return maintenanceTask == null ? null : MaintenanceTaskMaintenanceTaskDtoMapper.Map(maintenanceTask);
        }

        public async Task<IEnumerable<MaintenanceTaskDto>> GetAllMaintenanceTaskAsync()
        {
            var maintenanceTask = await maintenanceTaskRepository.GetAllAsync([i => i.EquipmentMaintenances]);

            return maintenanceTask.Select(MaintenanceTaskMaintenanceTaskDtoMapper.Map);
        }

        public async Task<MaintenanceTaskDto> CreateMaintenanceTaskAsync(MaintenanceTaskDto maintenanceTaskDto)
        {
            var maintenanceTask = MaintenanceTaskMaintenanceTaskDtoMapper.Map(maintenanceTaskDto);
            await maintenanceTaskRepository.AddAsync(maintenanceTask);
            return MaintenanceTaskMaintenanceTaskDtoMapper.Map(maintenanceTask);
        }

        public async Task UpdateMaintenanceTaskAsync(int id, MaintenanceTaskDto maintenanceTaskDto)
        {
            var existingMaintenanceTask = await GetMaintenanceTaskOrFail(id);

            MaintenanceTaskMaintenanceTaskDtoMapper.Map(maintenanceTaskDto, existingMaintenanceTask);
            await maintenanceTaskRepository.UpdateAsync(existingMaintenanceTask);
        }

        public async Task DeleteMaintenanceTaskAsync(int id)
        {
            var existingMaintenanceTask = await GetMaintenanceTaskOrFail(id);
            await maintenanceTaskRepository.DeleteAsync(id);
        }

        private async Task<MaintenanceTask> GetMaintenanceTaskOrFail(int id)
        {
            var existingMaintenanceTask = await maintenanceTaskRepository.GetByIdAsync(id);
            if (existingMaintenanceTask == null)
            {
                throw new KeyNotFoundException($"MaintenanceTask with ID {id} not found");
            }

            return existingMaintenanceTask;
        }
    }
}