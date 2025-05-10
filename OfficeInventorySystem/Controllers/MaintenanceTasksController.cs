using Microsoft.AspNetCore.Mvc;
using OfficeInventorySystem.Application.DTOs;
using OfficeInventorySystem.Application.Interfaces;

namespace OfficeInventorySystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaintenanceTasksController(IMaintenanceTaskService maintenanceTaskService) : ControllerBase
    {
        [HttpGet()]
        public async Task<ActionResult> GetAll()
        {
            var maintenances = await maintenanceTaskService.GetAllMaintenanceTaskAsync();
            return Ok(maintenances);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult> GetById(int id)
        {
            var maintenance = await maintenanceTaskService.GetMaintenanceTaskByIdAsync(id);
            if (maintenance == null)
            {
                return NotFound();
            }

            return Ok(maintenance);
        }

        [HttpPost()]
        public async Task<ActionResult> Create([FromBody] MaintenanceTaskDto maintenanceDto)
        {
            var maintenance = await maintenanceTaskService.CreateMaintenanceTaskAsync(maintenanceDto);
            return Ok(maintenance);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, [FromBody] MaintenanceTaskDto maintenanceDto)
        {
            try
            {
                await maintenanceTaskService.UpdateMaintenanceTaskAsync(id, maintenanceDto);
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
                await maintenanceTaskService.DeleteMaintenanceTaskAsync(id);
                return NoContent();
            }
            catch (KeyNotFoundException)
            {
                return NotFound();
            }
        }
    }
}
