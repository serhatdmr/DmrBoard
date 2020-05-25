using FluentValidation;

namespace DmrBoard.Domain.Organizations.Validations
{
    public abstract class OrganizationValidation<T> : AbstractValidator<T> where T : OrganizationCommand
    {
        protected void ValidateName()
        {
            RuleFor(n => n.Name).NotEmpty().Length(2, 100);
        }
    }
}
