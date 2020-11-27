using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Reservations.Repository.Contexts;
using Reservations.Repository.Domain;

namespace Reservations.Repository.Repository
{
    public class ContactRepository : IContactRepository
    {
        private readonly ReservationDbContext _reservationDbContext;

        public ContactRepository(ReservationDbContext reservationDbContext)
        {
            _reservationDbContext = reservationDbContext;
        }

        public Contact Insert(Contact entity)
        {
            var contact = _reservationDbContext.Contacts.Add(entity);
            _reservationDbContext.SaveChanges();

            return contact.Entity;
        }

        public void Remove(Guid contactId)
        {
            _reservationDbContext.Contacts.Remove(_reservationDbContext.Contacts.Find(contactId));
            _reservationDbContext.SaveChanges();
        }

        public void Update(Contact contact)
        {
            var contactUpdate = _reservationDbContext.Contacts.Find(contact.ContactId);
            contactUpdate.BirthDate = contact.BirthDate;
            contactUpdate.Name = contact.Name;
            contactUpdate.PhoneNumber = contact.PhoneNumber;
            contactUpdate.ContactType = contact.ContactType;
            _reservationDbContext.SaveChanges();
        }

        public IQueryable<Contact> Find()
        {
            return _reservationDbContext.Contacts.Include("ContactType");
        }

        public async Task<Contact> FindById(Guid id)
        {
            return await _reservationDbContext.Contacts.FindAsync(id);
        }

        public async Task<Contact> FindByName(string name)
        {
            var contact = _reservationDbContext.Contacts.FromSqlRaw($"Get_Contact_By_Name '{name}'").ToList();
            if (!contact.Any())
            {
                return null;
            }

            var foundContact = contact.First();
            foundContact.ContactType =
                await _reservationDbContext.ContactTypes.FirstOrDefaultAsync(c =>
                    c.ContactTypeId == contact.First().ContactTypeId);
            return foundContact;
        }


    }
}
