using OfficeInventorySystem.Domain.Interfaces;
using System.ComponentModel.DataAnnotations.Schema;

namespace OfficeInventorySystem.Domain.Entities
{
    [Table("EquipmentType")]
    public class EquipmentType : IEntity
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public ICollection<Equipment> Equipments { get; set; }
    }
}
