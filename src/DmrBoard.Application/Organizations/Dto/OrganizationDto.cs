using System;
using System.ComponentModel.DataAnnotations;

namespace DmrBoard.Application.Organizations.Dto
{
    public class OrganizationDto
    {
        public Guid? Id { get; set; }
        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
