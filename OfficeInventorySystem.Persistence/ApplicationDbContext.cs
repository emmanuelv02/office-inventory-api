namespace OfficeInventorySystem.Persistence
{
    using Microsoft.EntityFrameworkCore;
    using OfficeInventorySystem.Domain.Entities;

    public class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : DbContext(options)
    {
        public DbSet<EquipmentType> EquipmentTypes { get; set; }
        public DbSet<Equipment> Equipment { get; set; }
        public DbSet<MaintenanceTask> MaintenanceTasks { get; set; }
        public DbSet<EquipmentMaintenance> EquipmentMaintenances { get; set; }
    }
}
