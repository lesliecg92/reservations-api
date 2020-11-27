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
    public class ContactTypeRepository : IContactTypeRepository
    {
        private readonly ReservationDbContext _reservationDbContext;

        public ContactTypeRepository(ReservationDbContext reservationDbContext)
        {
            _reservationDbContext = reservationDbContext;
        }

        public async Task<IEnumerable<ContactType>> FindAll()
        {
            return await _reservationDbContext.ContactTypes.ToListAsync();
        }
    }
}
