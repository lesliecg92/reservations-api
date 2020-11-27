using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reservations.Repository.Domain;
using Reservations.Repository.Repository;

namespace Reservations.Business
{
    public class ReservationBusiness : IReservationBusiness
    {
        private static IReservationRepository _reservationRepository;
        private static IContactRepository _contactRepository;
        private static IContactTypeRepository _contactTypeRepository;

        public ReservationBusiness(IReservationRepository reservationRepository, IContactRepository contactRepository,
            IContactTypeRepository contactTypeRepository)
        {
            _reservationRepository = reservationRepository;
            _contactRepository = contactRepository;
            _contactTypeRepository = contactTypeRepository;
        }

        public async Task<(IEnumerable<Reservation>, int)> GetReservationsList(int pageSize, int page, string orderBy, string sortOrder)
        {
            var query = _reservationRepository.Find();

            if (pageSize == 0)
            {
                pageSize = 15;
            }

            if (page == 0)
            {
                page = 1;
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = "description";
            }

            if (string.IsNullOrWhiteSpace(sortOrder))
            {
                sortOrder = "asc";
            }

            query = QueryHelper<Reservation>.ApplyOrder(query, orderBy, sortOrder);
            return await QueryHelper<Reservation>.ApplyPagination(query, pageSize, page);
        }

        public async Task<Reservation> GetReservation(Guid id)
        {
            return await _reservationRepository.FindById(id);
        }

        public void AddReservation(Reservation reservation)
        {
            _reservationRepository.Insert(reservation);
        }

        public async Task<(IEnumerable<Contact>, int)> GetContactsList(int pageSize, int page, string orderBy, string sortOrder)
        {
            var query = _contactRepository.Find();

            if (pageSize == 0)
            {
                pageSize = 15;
            }

            if (page == 0)
            {
                page = 1;
            }

            if (string.IsNullOrWhiteSpace(orderBy))
            {
                orderBy = "name";
            }

            if (string.IsNullOrWhiteSpace(sortOrder))
            {
                orderBy = "asc";
            }

            query = QueryHelper<Contact>.ApplyOrder(query, orderBy, sortOrder);
            return await QueryHelper<Contact>.ApplyPagination(query, pageSize, page);
        }

        public async Task<IEnumerable<ContactType>> GetContactTypes()
        {
            return await _contactTypeRepository.FindAll();
        }

        public void DeleteReservation(Guid reservationId)
        {
            _reservationRepository.Remove(reservationId);
        }

        public async Task<Contact> GetContactByName(string name)
        {
            return await _contactRepository.FindByName(name);
        }

        public void AddContact(Contact contact)
        {
            _contactRepository.Insert(contact);

            //if (contact.Reservations != null && contact.Reservations.Any())
            //{
            //    foreach (var reservation in contact.Reservations)
            //    {
            //        reservation.ContactId = id;
            //        reservation.CreationDate = DateTime.Now;
            //        _reservationRepository.Insert(reservation);
            //    }
            //}
        }

        public void UpdateContact(Contact contact)
        {
            _contactRepository.Update(contact);
            if (contact.Reservations != null && contact.Reservations.Any())
            {
                foreach (var reservation in contact.Reservations)
                {
                    reservation.ContactId = contact.ContactId;
                    reservation.CreationDate = DateTime.Now;
                    _reservationRepository.Insert(reservation);
                }
            }
        }

        public void DeleteContact(Guid contactId)
        {
            _contactRepository.Remove(contactId);
        }

        public void UpdateReservation(Reservation reservation)
        {
            _reservationRepository.Update(reservation);
        }

    }
}
