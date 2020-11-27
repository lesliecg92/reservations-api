using System;
using System.ComponentModel.DataAnnotations;

namespace Reservations.Repository.Domain
{
    public class Reservation
    {
        [Key]
        public Guid ReservationId { get; set; }
        public string Destination { get; set; }
        public string Image { get; set; }
        public string Description { get; set; }
        public DateTime CreationDate { get; set; }
        public int Ranking { get; set; }
        public bool IsFavorite { get; set; }
        public Guid ContactId { get; set; }
        public virtual Contact Contact { get; set; }

        public Reservation()
        {
            CreationDate = DateTime.Now;
        }
    }
}
