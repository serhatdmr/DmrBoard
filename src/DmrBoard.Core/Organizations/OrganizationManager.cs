using DmrBoard.Core.Service;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Core.Organizations
{

    public class OrganizationManager : DomainServiceBase<OrganizationManager>, IOrganizationManager
    {
        public OrganizationManager(ILogger<OrganizationManager> logger) : base(logger)
        {
        }

        public void Get()
        {
            _logger.LogInformation("Organizasyon getirildi.");
        }
    }
}
