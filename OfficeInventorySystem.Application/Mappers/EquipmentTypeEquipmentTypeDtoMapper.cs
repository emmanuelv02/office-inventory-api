using OfficeInventorySystem.Application.DTOs;
using OfficeInventorySystem.Domain.Entities;

namespace OfficeInventorySystem.Application.Mappers
{
    public static class EquipmentTypeEquipmentTypeDtoMapper
    {
        public static EquipmentTypeDto Map(EquipmentType equipmentType)
        {
            return new EquipmentTypeDto
            {
                Id = equipmentType.Id,
                Description = equipmentType.Description
            };
        }
    }
}
