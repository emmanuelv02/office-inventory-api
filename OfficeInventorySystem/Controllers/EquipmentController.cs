using Microsoft.AspNetCore.Mvc;
using OfficeInventorySystem.Application.DTOs;
using OfficeInventorySystem.Application.Interfaces;

namespace OfficeInventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EquipmentController(IEquipmentService equipmentService) : ControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult> GetAll()
        {
            var equipments = await equipmentService.GetAllEquipmentAsync();
            return Ok(equipments);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var equipment = await equipmentService.GetEquipmentByIdAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            return Ok(equipment);
        }

        [HttpPost()]
        public async Task<ActionResult> Create([FromBody] EquipmentDto equipmentDto)
        {
            var equipment = await equipmentService.CreateEquipmentAsync(equipmentDto);
            return Ok(equipment);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] EquipmentDto equipmentDto)
        {
            try
            {
                await equipmentService.UpdateEquipmentAsync(id, equipmentDto);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                await equipmentService.DeleteEquipmentAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpGet("{id}/maintenances")]
        public async Task<ActionResult> GetMaintenanceTasks(int id)
        {
            var equipment = await equipmentService.GetEquipmentByIdAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            var tasks = await equipmentService.GetEquipmentMaintenanceTasksAsync(id);
            return Ok(tasks);
        }

        [HttpGet("maintenances/{id}")]
        public async Task<ActionResult> GetEquipmentsByMaintenanceTasks(int id)
        {
            var equipments = await equipmentService.GetEquipmentsByMaintenanceTasksAsync(id);
            return Ok(equipments);
        }

        [HttpDelete("{equipmentId}/maintenances/{maintenanceTaskId}")]
        public async Task<IActionResult> DeleteMaintenance(int equipmentId, int maintenanceTaskId)
        {
            try
            {
                await equipmentService.DeleteEquipmentMaintenanceAsync(equipmentId, maintenanceTaskId);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }

        [HttpPost("{id}/maintenances")]
        public async Task<ActionResult> CreateMaintenance(int id, [FromBody] MaintenanceDto maintenanceDto)
        {
            var equipment = await equipmentService.GetEquipmentByIdAsync(id);
            if (equipment == null)
            {
                return NotFound();
            }

            await equipmentService.AssignMaintenanceTaskToEquipmentAsync(id, maintenanceDto.MaintenanceId);
            return NoContent();
        }

    }
}
