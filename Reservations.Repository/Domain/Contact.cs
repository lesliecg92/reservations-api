using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Reservations.Repository.Domain
{
    public class Contact
    {
        [Key]
        public Guid ContactId { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public ContactType ContactType { get; set; }
        public virtual Guid ContactTypeId { get; set; }
        public ICollection<Reservation> Reservations { get; set; }

        public Contact()
        {
            Reservations = new List<Reservation>();
        }
    }
}
