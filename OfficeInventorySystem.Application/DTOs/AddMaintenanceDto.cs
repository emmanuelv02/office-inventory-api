using FluentValidation;

namespace OfficeInventorySystem.Application.DTOs
{
    public class MaintenanceDto
    {
        public int MaintenanceId { get; set; }
    }

    public class MaintenanceValidator : AbstractValidator<MaintenanceDto>
    {
        public MaintenanceValidator()
        {
            RuleFor(p => p.MaintenanceId)
               .NotEmpty();
        }
    }
}
