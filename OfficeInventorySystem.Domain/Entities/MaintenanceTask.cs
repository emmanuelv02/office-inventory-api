using OfficeInventorySystem.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeInventorySystem.Domain.Entities
{
    [Table("MaintenanceTask")]
    public class MaintenanceTask : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<EquipmentMaintenance> EquipmentMaintenances { get; set; } = [];
    }
}
