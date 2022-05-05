using FluentValidation;
using SecondWebAPI.ViewModels;

namespace SecondWebAPI.DBOperations.Validations
{
    public class UpdateProductValidator : AbstractValidator<UpdateProductCommand>
    {
        public UpdateProductValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Uygulama tarafından 0 ve negatif değerli ID'ler kullanılmamaktadır!");

            RuleFor(x => x.Name).NotNull().WithMessage("Uygulamamız isim alanını null bırakamanıza izin vermemektedir!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Uygulamamız isim alanını boş geçmenize izin vermemektedir!");

            RuleFor(x => x.Brand).NotEmpty().WithMessage("Uygulamamız marka alanını boş geçmenize izin vermemektedir!");
            RuleFor(x => x.Name).NotNull().WithMessage("Uygulamamız marka alanını null geçmenize izin vermemektedir!");

            RuleFor(x => x.Price).GreaterThanOrEqualTo(1);
            RuleFor(x => x.Stock).GreaterThanOrEqualTo(0);
            RuleFor(x => x.CategoryId).GreaterThanOrEqualTo(1);
        }
    }
}
