using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Reservations.Web.Api.ViewModel
{
    public class ContactModel
    {
        public DateTime BirthDate { get; set; }
        public string Name { get; set; }
        public Guid ContactTypeId { get; set; }
        public ICollection<ReservationModel> Reservations { get; set; }
        public string PhoneNumber { get; set; }
    }
}
