using FluentValidation;
using SecondWebAPI.ViewModels;

namespace SecondWebAPI.DBOperations.Validations
{
    public class CreateCustomerValidator : AbstractValidator<CreateCustomerCommand>
    {
        public CreateCustomerValidator()
        {
            RuleFor(x => x.FullName).NotNull().NotEmpty().WithMessage("Uygulamamız isim alanını bilinmez bırakamanıza izin vermemektedir!");
            RuleFor(x => x.FullName).MinimumLength(2);
            RuleFor(x => x.EMail).EmailAddress();

            RuleFor(x => x.PhoneNumber).Matches("(05|5)[0-9][0-9][ ][1-9]([0-9]){2}[ ]([0-9]){4}").WithMessage("Lütfen 05xx xxx xxxx formatını kullanınız.");
            RuleFor(x => x.PhoneNumber).MaximumLength(13).MinimumLength(13);
        }
    }
}
