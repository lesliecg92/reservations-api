using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservations.Repository.Domain;

namespace Reservations.Repository.Repository
{
    public interface IContactRepository
    {
        Contact Insert(Contact contact);
        void Remove(Guid contactId);
        void Update(Contact contact);
        IQueryable<Contact> Find();
        Task<Contact> FindById(Guid id);
        Task<Contact> FindByName(string name);
    }
}
