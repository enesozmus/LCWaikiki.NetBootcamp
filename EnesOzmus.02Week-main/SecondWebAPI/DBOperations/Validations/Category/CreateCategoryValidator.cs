using FluentValidation;
using SecondWebAPI.ViewModels;

namespace SecondWebAPI.DBOperations.Validations
{
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name).NotNull().WithMessage("Uygulamamız isim alanını null bırakamanıza izin vermemektedir!");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Uygulamamız isim alanını boş geçmenize izin vermemektedir!");

            RuleFor(x => x.Description).NotNull().WithMessage("Uygulamamız isim alanını null bırakamanıza izin vermemektedir!");
            RuleFor(x => x.Description).NotEmpty().WithMessage("Uygulamamız isim alanını boş geçmenize izin vermemektedir!");
        }
    }
}
