using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservations.Repository.Domain;

namespace Reservations.Web.Api.ViewModel
{
    public class ReservationsViewModel
    {
        public ICollection<Reservation> Reservations { get; set; }

        public int Total { get; set; }
    }
}
