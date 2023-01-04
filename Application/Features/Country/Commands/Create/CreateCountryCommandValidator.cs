using FluentValidation;

namespace Application.Features.Country.Commands.Create
{
    public class CreateCountryCommandValidator : AbstractValidator<CreateCountryCommand>
    {
        public CreateCountryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.NameA).NotEmpty().WithMessage("ادخل البلد")
       .MaximumLength((int)100).WithMessage("Maximum length is 100 letter");

        }


    }
}
