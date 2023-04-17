using FluentValidation;
using LaborProtection.Common;
using LaborProtection.Database.Enums;

namespace LaborProtection.Services.BulbServices.Models
{
    public class CreateBulbPostModel
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public short Voltage { get; set; }
        public short Power { get; set; }
        public int LightFlux { get; set; }
        public float Price { get; set; }
    }

    public class CreateBulbPostModelValidator : AbstractValidator<CreateBulbPostModel>
    {
        public CreateBulbPostModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MinimumLength(4)
                .MaximumLength(63);

            RuleFor(x => x.Type)
                .NotEmpty()
                .NotNull()
                .LessThan(Enum.GetNames(typeof(BulbType)).Length)
                .GreaterThanOrEqualTo(1)
                .WithMessage(Errors.VALUE_MUST_BE_SELECTED_ERROR);

            RuleFor(x => (int)x.Voltage)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => (int)x.Power)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.LightFlux)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);
        }
    }
}