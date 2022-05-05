using FirstWebAPI.ViewModels;
using FluentValidation;

namespace FirstWebAPI.Validations
{
    public class CreateProductValidator : AbstractValidator<VM_Create_Product>
    {
        public CreateProductValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Uygulamamız isim alanını null geçmenize izin vermemektedir!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Uygulamamız isim alanını boş geçmenize izin vermemektedir!");

            RuleFor(x => x.CreatedDate).MaximumLength(10);
            RuleFor(x => x.CreatedDate).NotNull();
            RuleFor(x => x.CreatedDate).Matches("^(3[01]|[12][0-9]|0[1-9]).(1[0-2]|0[1-9]).[0-9]{4}$").WithMessage("Lütfen dd.mm.yyyy formatını kullanınız!");

            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue);
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue);
        }
    }
}
