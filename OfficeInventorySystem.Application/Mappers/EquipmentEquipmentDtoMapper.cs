using OfficeInventorySystem.Application.DTOs;
using OfficeInventorySystem.Domain.Entities;

namespace OfficeInventorySystem.Application.Mappers
{
    public static class EquipmentEquipmentDtoMapper
    {
        public static EquipmentDto Map(Equipment equipment)
        {
            return new EquipmentDto
            {
                Id = equipment.Id,
                Brand = equipment.Brand,
                Model = equipment.Model,
                EquipmentTypeId = equipment.EquipmentTypeId,
                PurchaseDate = equipment.PurchaseDate,
                SerialNumber = equipment.SerialNumber,
                EquipmentTypeDescription = equipment.EquipmentType?.Description,
            };
        }

        public static Equipment Map(EquipmentDto equipmentDto)
        {
            return new Equipment
            {
                Brand = equipmentDto.Brand,
                Model = equipmentDto.Model,
                EquipmentTypeId = equipmentDto.EquipmentTypeId,
                PurchaseDate = equipmentDto.PurchaseDate,
                SerialNumber = equipmentDto.SerialNumber
            };
        }

        public static void Map(EquipmentDto equipmentDto, Equipment equipment)
        {
            equipment.Brand = equipmentDto.Brand;
            equipment.Model = equipmentDto.Model;
            equipment.EquipmentTypeId = equipmentDto.EquipmentTypeId;
            equipment.PurchaseDate = equipmentDto.PurchaseDate;
            equipment.SerialNumber = equipmentDto.SerialNumber;
        }
    }
}
