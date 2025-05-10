
using OfficeInventorySystem.Application.DTOs;

namespace OfficeInventorySystem.Application.Interfaces
{
    public interface IEquipmentTypeService
    {
        Task<IEnumerable<EquipmentTypeDto>> GetAllAsync();
    }
}
