
using FluentValidation;

namespace OfficeInventorySystem.Application.DTOs
{
    public class EquipmentDto
    {
        public int Id { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int EquipmentTypeId { get; set; }
        public string? EquipmentTypeDescription { get; set; }
        public DateTime PurchaseDate { get; set; }
        public string? SerialNumber { get; set; }
    }

    public class EquipmentDtoValidator : AbstractValidator<EquipmentDto>
    {
        public EquipmentDtoValidator()
        {
            RuleFor(p => p.EquipmentTypeId)
               .NotEmpty();

            RuleFor(p => p.Brand)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(p => p.Model)
                .MaximumLength(100)
                .NotEmpty();

            RuleFor(p => p.PurchaseDate)
               .NotEmpty();

            RuleFor(p => p.SerialNumber)
                .MaximumLength(100);
        }
    }
}
