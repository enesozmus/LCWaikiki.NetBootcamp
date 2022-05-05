using FluentValidation;
using SecondWebAPI.ViewModels;

namespace SecondWebAPI.DBOperations.Validations
{
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id).GreaterThan(0).WithMessage("Uygulama tarafından 0 ve negatif değerli ID'ler kullanılmamaktadır!");

            RuleFor(x => x.Name).NotNull().WithMessage("Uygulamamız isim alanını null bırakamanıza izin vermemektedir!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Uygulamamız isim alanını boş geçmenize izin vermemektedir!");

            RuleFor(x => x.Description).NotNull().WithMessage("Uygulamamız isim alanını null bırakamanıza izin vermemektedir!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Uygulamamız isim alanını boş geçmenize izin vermemektedir!");
        }
    }
}
