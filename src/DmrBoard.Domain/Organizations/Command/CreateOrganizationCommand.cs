using DmrBoard.Domain.Organizations.Validations;
using System;
using System.Collections.Generic;
using System.Text;

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
