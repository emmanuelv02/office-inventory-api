using OfficeInventorySystem.Domain.Interfaces;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeInventorySystem.Domain.Entities
{
    [Table("Equipment")]
    public class Equipment : IEntity
    {
        [Key]
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int EquipmentTypeId { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string? SerialNumber { get; set; }

        public EquipmentType EquipmentType { get; set; }
        public ICollection<EquipmentMaintenance> EquipmentMaintenances { get; set; }
    }
}
