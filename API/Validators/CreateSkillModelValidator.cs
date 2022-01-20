using API.RequestModels;
using FluentValidation;

namespace API.Validators
{
    public class CreateSkillModelValidator : AbstractValidator<CreateSkillModel>
    {
        public CreateSkillModelValidator()
        {
            RuleFor(a => a.Name)
                .NotEmpty()
                .MaximumLength(100);
        }
    }
}
