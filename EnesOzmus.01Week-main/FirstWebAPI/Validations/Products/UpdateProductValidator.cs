using FirstWebAPI.ViewModels;
using FluentValidation;

namespace FirstWebAPI.Validations
{
    public class UpdateProductValidator : AbstractValidator<VM_Update_Product>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Uygulama tarafından 0 ve negatif değerli ID'ler kullanılmamaktadır!");

            RuleFor(x => x.Name).NotNull().WithMessage("Uygulamamız isim alanını null bırakamanıza izin vermemektedir!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Uygulamamız isim alanını boş geçmenize izin vermemektedir!");

            RuleFor(x => x.UpdatedDate).MaximumLength(10);
            RuleFor(x => x.UpdatedDate).NotNull();
            RuleFor(x => x.UpdatedDate).Matches("^(3[01]|[12][0-9]|0[1-9]).(1[0-2]|0[1-9]).[0-9]{4}$").WithMessage("Lütfen dd.mm.yyyy formatını kullanınız!");

            RuleFor(x => x.CreatedDate).MaximumLength(10);
            RuleFor(x => x.CreatedDate).NotNull();
            RuleFor(x => x.CreatedDate).Matches("^(3[01]|[12][0-9]|0[1-9]).(1[0-2]|0[1-9]).[0-9]{4}$").WithMessage("Lütfen dd.mm.yyyy formatını kullanınız!");

            RuleFor(x => x.Price).InclusiveBetween(1, int.MaxValue);
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryId).InclusiveBetween(1, int.MaxValue);
        }
    }
}
