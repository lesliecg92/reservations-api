using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservations.Repository.Domain;

namespace Reservations.Business
{
    public interface IReservationBusiness
    {
        Task<(IEnumerable<Reservation>, int)> GetReservationsList(int pageSize, int page, string orderBy, string sortOrder);
        Task<(IEnumerable<Contact>, int)> GetContactsList(int pageSize, int page, string orderBy, string sortOrder);
        Task<IEnumerable<ContactType>> GetContactTypes();
        Task<Reservation> GetReservation(Guid id);
        void AddReservation(Reservation reservation);
        Task<Contact> GetContactByName(string name);
        void AddContact(Contact contact);
        void UpdateContact(Contact contact);
        void DeleteContact(Guid contactId);
        void UpdateReservation(Reservation reservation);
        void DeleteReservation(Guid reservationId);

    }
}
