using API.RequestModels;
using FluentValidation;

namespace API.Validators
{
    public class CreateCandidateModelValidator : AbstractValidator<CreateCandidateModel>
    {
        public CreateCandidateModelValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(100);

            RuleFor(a => a.Email)
                .NotEmpty()
                .MaximumLength(300);
        }
    }
}
