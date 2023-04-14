using FluentValidation;
using LaborProtection.Database.Enums;

namespace LaborProtection.Services.LampServices.Models
{
    public class CreateLampPostModel
    {
        public string Name { get; set; }
        public int Type { get; set; }
        public float Price { get; set; }
        public ushort BulbCount { get; set; }
        public float Height { get; set; }
        public FileInfo Image { get; set; }
    }

    public class CreateLampPostModelValidator : AbstractValidator<CreateLampPostModel>
    {
        public CreateLampPostModelValidator()
        {
            RuleFor(x => x.Name)
                .NotEmpty()
                .NotNull()
                .MaximumLength(63);

            RuleFor(x => x.Type)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(1)
                .LessThan(Enum.GetNames(typeof(LampType)).Length);

            RuleFor(x => x.Price)
                .NotEmpty()
                .NotNull()
                .GreaterThan(0);

            RuleFor(x => (int)x.BulbCount)
                .NotNull()
                .NotEmpty()
                .GreaterThan(0)
                .LessThan(ushort.MaxValue);

            RuleFor(x => x.Height)
                .NotEmpty()
                .NotNull()
                .GreaterThanOrEqualTo(0);
        }
    }
}