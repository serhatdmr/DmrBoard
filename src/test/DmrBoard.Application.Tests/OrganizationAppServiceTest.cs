using AutoMapper;
using DmrBoard.Application.Mapper;
using DmrBoard.Application.Organizations;
using DmrBoard.Application.Organizations.Dto;
using DmrBoard.Core.Bus;
using DmrBoard.Core.Domain.Interfaces;
using DmrBoard.Core.Interfaces;
using DmrBoard.Core.Notifications;
using DmrBoard.Core.Organizations;
using DmrBoard.IoC;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace DmrBoard.Application.Tests
{
    public class OrganizationAppServiceTest
    {
        private readonly IOrganizationAppService _organizationAppService;

        private List<Organization> organizations;

        public OrganizationAppServiceTest()
        {
            var mockMediatorHandler = new Mock<IMediatorHandler>();
            var mockCurrentUserService = new Mock<ICurrentUserService>();
            var mockOrganizationRepo = new Mock<IRepository<Organization, Guid>>();

            //auto mapper configuration
            var _mockMapper = new MapperConfiguration(cfg =>
                {
                    cfg.AddProfile(new CustomDtoMapper());
                });
            var mapper = _mockMapper.CreateMapper();

            organizations = new List<Organization>
            {
                new Organization{  Name="1. Organizasyon",Id=Guid.NewGuid()},
                new Organization { Name="2. Organizasyon",Id=Guid.NewGuid()}
            };
            mockOrganizationRepo.Setup(s => s.GetAll()).Returns(organizations.AsQueryable());


            _organizationAppService = new OrganizationAppService(mockMediatorHandler.Object, mapper,
mockCurrentUserService.Object, mockOrganizationRepo.Object);
        }
        [Fact]
        public void Should_All_Organizations()
        {
            var data = _organizationAppService.GetAll(new GetAllInput());
            Assert.Equal(2, data.TotalCount);
        }

    }
}
