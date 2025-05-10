using OfficeInventorySystem.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeInventorySystem.Domain.Entities
{
    [Table("EquipmentMaintenance")]
    public class EquipmentMaintenance : IEntity
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Equipment")]
        public int EquipmentId { get; set; }

        [ForeignKey("MaintenanceTask")]
        public int MaintenanceTaskId { get; set; }

        public Equipment Equipment { get; set; }
        public MaintenanceTask MaintenanceTask { get; set; }
    }
}
