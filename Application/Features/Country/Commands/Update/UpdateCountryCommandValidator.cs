using FluentValidation;

namespace Application.Features.Country.Commands.Update
{
    public class UpdateCountryCommandValidator : AbstractValidator<UpdateCountryCommand>
    {

        public UpdateCountryCommandValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.NameA).NotEmpty().WithMessage("Please specify a Country Name")
       .MaximumLength((int)100).WithMessage("Maximum length is 100 letter");

        }

    }
}
