using OfficeInventorySystem.Application.DTOs;
using OfficeInventorySystem.Application.Interfaces;
using OfficeInventorySystem.Application.Mappers;
using OfficeInventorySystem.Domain.Entities;
using OfficeInventorySystem.Domain.Interfaces;

namespace OfficeInventorySystem.Application.Services
{
    public class EquipmentTypeService(IRepository<EquipmentType> equipmentTypeRepository) : IEquipmentTypeService
    {
        public async Task<IEnumerable<EquipmentTypeDto>> GetAllAsync()
        {
            var equipment = await equipmentTypeRepository.GetAllAsync();
            return equipment.Select(EquipmentTypeEquipmentTypeDtoMapper.Map);
        }
    }
}
