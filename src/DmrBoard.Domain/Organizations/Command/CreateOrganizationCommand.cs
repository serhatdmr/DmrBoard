using DmrBoard.Domain.Organizations.Validations;

namespace DmrBoard.Domain.Organizations
{
    public class CreateOrganizationCommand : OrganizationCommand
    {
        public CreateOrganizationCommand(string name)
        {
            Name = name;
        }

        public override bool IsValid()
        {
            ValidationResult = new CreateOrganizationValidation().Validate(this);
            return ValidationResult.IsValid;
        }
    }
}
