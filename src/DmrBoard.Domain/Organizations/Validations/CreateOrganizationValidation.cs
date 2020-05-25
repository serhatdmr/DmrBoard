using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Domain.Organizations.Validations
{

    public class CreateOrganizationValidation : OrganizationValidation<CreateOrganizationCommand>
    {
        public CreateOrganizationValidation()
        {
            ValidateName();
        }
    }
}
