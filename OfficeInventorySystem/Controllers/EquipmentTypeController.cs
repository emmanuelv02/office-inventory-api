using Microsoft.AspNetCore.Mvc;
using OfficeInventorySystem.Application.Interfaces;

namespace OfficeInventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentTypeController(IEquipmentTypeService equipmentTypeService) : ControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult> GetAll()
        {
            var equipments = await equipmentTypeService.GetAllAsync();
            return Ok(equipments);
        }
    }
}
