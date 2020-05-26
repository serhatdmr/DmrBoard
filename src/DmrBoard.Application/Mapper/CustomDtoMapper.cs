using AutoMapper;
using DmrBoard.Application.Organizations.Dto;
using DmrBoard.Core.Organizations;
using System;
using System.Collections.Generic;
using System.Text;

namespace DmrBoard.Application.Mapper
{
    public class CustomDtoMapper : Profile
    {
        public CustomDtoMapper()
        {
            CreateMap<Organization, OrganizationDto>().ReverseMap();
        }
    }
}
