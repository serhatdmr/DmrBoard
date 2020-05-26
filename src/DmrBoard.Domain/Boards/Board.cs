using DmrBoard.Core.Domain.Entities;
using DmrBoard.Core.Organizations;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace DmrBoard.Domain.Boards
{
    public class Board : Entity<Guid>
    {
        public string Name { get; set; }

        [Required]
        public virtual Organization Organization { get; set; }

        public Guid OrganizationId { get; set; }

        public Board()
        {
            Id = Guid.NewGuid();
        }

        public Board(Organization organization, string name)
        {
            Organization = organization;
            Name = name;
        }
    }
}
