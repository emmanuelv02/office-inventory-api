using FluentValidation;

namespace OfficeInventorySystem.Application.DTOs
{
    public class MaintenanceTaskDto
    {
        public int Id { get; set; }
        public string Description { get; set; }
    }

    public class MaintenanceTaskDtoValidator : AbstractValidator<MaintenanceTaskDto>
    {
        public MaintenanceTaskDtoValidator()
        {
            RuleFor(p => p.Description)
               .NotEmpty();
        }
    }
}
