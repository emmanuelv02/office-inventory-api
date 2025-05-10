using OfficeInventorySystem.Application.DTOs;
using OfficeInventorySystem.Application.Interfaces;
using OfficeInventorySystem.Application.Mappers;
using OfficeInventorySystem.Domain.Entities;
using OfficeInventorySystem.Domain.Interfaces;
using System.Linq.Expressions;


namespace OfficeInventorySystem.Application.Services
{
    public class EquipmentService(IRepository<Equipment> equipmentRepository,
        IRepository<EquipmentMaintenance> equipmentMaintenanceRepository) : IEquipmentService
    {
        public async Task<IEnumerable<MaintenanceTaskDto>> GetEquipmentMaintenanceTasksAsync(int equipmentId)
        {
            var equipmentMaintenances = await equipmentMaintenanceRepository.WhereAsync(x => x.EquipmentId == equipmentId, i => i.MaintenanceTask);
            return equipmentMaintenances.Select(x => MaintenanceTaskMaintenanceTaskDtoMapper.Map(x.MaintenanceTask)) ?? [];
        }

        public async Task<EquipmentDto?> GetEquipmentByIdAsync(int id)
        {
            var equipment = await equipmentRepository.GetByIdAsync(id, i => i.EquipmentType);
            return equipment == null ? null : EquipmentEquipmentDtoMapper.Map(equipment);
        }

        public async Task<IEnumerable<EquipmentDto>> GetAllEquipmentAsync()
        {
            var equipment = await equipmentRepository.GetAllAsync([i => i.EquipmentType]);
            return equipment.Select(EquipmentEquipmentDtoMapper.Map);
        }

        public async Task<EquipmentDto> CreateEquipmentAsync(EquipmentDto equipmentDto)
        {
            var equipment = EquipmentEquipmentDtoMapper.Map(equipmentDto);
            await equipmentRepository.AddAsync(equipment);
            return EquipmentEquipmentDtoMapper.Map(equipment);
        }

        public async Task UpdateEquipmentAsync(int id, EquipmentDto equipmentDto)
        {
            var existingEquipment = await GetEquipmentOrFail(id);

            EquipmentEquipmentDtoMapper.Map(equipmentDto, existingEquipment);
            await equipmentRepository.UpdateAsync(existingEquipment);
        }

        public async Task DeleteEquipmentAsync(int id)
        {
            var existingEquipment = await GetEquipmentOrFail(id);

            await equipmentRepository.DeleteAsync(id);
        }

        public async Task<IEnumerable<EquipmentDto>> GetEquipmentsByMaintenanceTasksAsync(int maintenanceTaskId)
        {
            var equipmentMaintenances = await equipmentMaintenanceRepository.WhereAsync(x => x.MaintenanceTaskId == maintenanceTaskId, i => i.Equipment);
            return equipmentMaintenances.Select(x => EquipmentEquipmentDtoMapper.Map(x.Equipment)) ?? [];
        }

        public Task AssignMaintenanceTaskToEquipmentAsync(int equipmentId, int maintenanceTaskId)
            => equipmentMaintenanceRepository.AddAsync(new EquipmentMaintenance { EquipmentId = equipmentId, MaintenanceTaskId = maintenanceTaskId });

        public async Task DeleteEquipmentMaintenanceAsync(int equipmentId, int maintenanceTaskId)
        {
            var equipmentMaintenance = (await equipmentMaintenanceRepository
                .WhereAsync(x => x.EquipmentId == equipmentId && x.MaintenanceTaskId == maintenanceTaskId))
                .FirstOrDefault();

            if (equipmentMaintenance == null)
            {
                throw new KeyNotFoundException($"Equipment maintenance not found");
            }

            await equipmentMaintenanceRepository.DeleteAsync(equipmentMaintenance.Id);
        }

        private async Task<Equipment> GetEquipmentOrFail(int id)
        {
            var existingEquipment = await equipmentRepository.GetByIdAsync(id);
            if (existingEquipment == null)
            {
                throw new KeyNotFoundException($"Equipment with ID {id} not found");
            }

            return existingEquipment;
        }
    }
}
