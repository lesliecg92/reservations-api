using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.Web.Api.ViewModel
{
    public class ReservationModel
    {
        public string Destination { get; set; }
        public string Description { get; set; }
        public int Ranking { get; set; }
        public bool IsFavorite { get; set; }
    }
}
