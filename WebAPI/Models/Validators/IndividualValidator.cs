using FluentValidation;
using InSharpAssessment.WebAPI.Models.ViewModels;

namespace InSharpAssessment.WebAPI.Models.Validators
{
    public class IndividualCreateValidator : AbstractValidator<IndividualCreateVM>
    {
        // Can add all the model validations here
        public IndividualCreateValidator()
        {
            RuleFor(x => x.FirstName)
                .NotEmpty()
                .WithMessage("First Name is required");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("Phone number is required");
        }
    }
}
