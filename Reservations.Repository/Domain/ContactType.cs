using System;
using System.ComponentModel.DataAnnotations;

namespace Reservations.Repository.Domain
{
    public class ContactType
    {
        [Key]
        public Guid ContactTypeId { get; set; }
        public string Name { get; set; }
    }

}
