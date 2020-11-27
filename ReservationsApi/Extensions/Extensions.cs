using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Reservations.Repository.Domain;
using Reservations.Web.Api.ViewModel;

namespace Reservations.Web.Api.Extensions
{
    public static class Extensions
    {

        public static Reservation ToReservation(this ReservationModel reservationModel)
        {
            return new Reservation
            {
                Description = reservationModel.Description,
                Destination = reservationModel.Destination,
                IsFavorite = reservationModel.IsFavorite,
                Ranking = reservationModel.Ranking,
                CreationDate = DateTime.Now
            };
        }

        public static Contact ToContact(this ContactModel contactModel)
        {
            return new Contact
            {
                BirthDate = contactModel.BirthDate,
                ContactTypeId = contactModel.ContactTypeId,
                Name = contactModel.Name,
                PhoneNumber = contactModel.PhoneNumber,
                Reservations = contactModel.Reservations.Select(ToReservation).ToList()
                
            };
        }
    }
}
