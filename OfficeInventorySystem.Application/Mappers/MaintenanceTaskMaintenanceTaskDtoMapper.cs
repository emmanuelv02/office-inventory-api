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
                Description = maintenanceTask.Description
            };
        }

        public static MaintenanceTask Map(MaintenanceTaskDto maintenanceTaskDto)
        {
            return new MaintenanceTask
            {
                Description = maintenanceTaskDto.Description
            };
        }

        public static void Map(MaintenanceTaskDto maintenanceTaskDto, MaintenanceTask maintenanceTask)
        {
            maintenanceTask.Description = maintenanceTaskDto.Description;
        }
    }
}
