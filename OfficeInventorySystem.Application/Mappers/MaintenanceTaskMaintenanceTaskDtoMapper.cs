using OfficeInventorySystem.Application.DTOs;
using OfficeInventorySystem.Domain.Entities;

namespace OfficeInventorySystem.Application.Mappers
{
    public static class MaintenanceTaskMaintenanceTaskDtoMapper
    {
        public static MaintenanceTaskDto Map(MaintenanceTask maintenanceTask)
        {
            return new MaintenanceTaskDto
            {
                Id = maintenanceTask.Id,
                Description = maintenanceTask.Description,
                EquipmentIds = maintenanceTask.EquipmentMaintenances.Select(x => x.EquipmentId).ToList(),
            };
        }

        public static MaintenanceTask Map(MaintenanceTaskDto maintenanceTaskDto)
        {
            var result = new MaintenanceTask
            {
                Description = maintenanceTaskDto.Description,
            };

            foreach (var item in maintenanceTaskDto.EquipmentIds.Select(x => new EquipmentMaintenance { EquipmentId = x }))
            {
                result.EquipmentMaintenances.Add(item);
            }

            return result;
        }

        public static void Map(MaintenanceTaskDto maintenanceTaskDto, MaintenanceTask maintenanceTask)
        {
            maintenanceTask.Description = maintenanceTaskDto.Description;
        }
    }
}
