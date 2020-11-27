using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Reservations.Repository.Domain;

namespace Reservations.Repository.Repository
{
    public interface IContactTypeRepository
    {
        Task<IEnumerable<ContactType>> FindAll();
    }
}
