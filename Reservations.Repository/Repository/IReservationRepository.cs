using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Reservations.Repository.Domain;

namespace Reservations.Repository.Repository
{
    public interface IReservationRepository
    {
        void Insert(Reservation reservation);
        void Update(Reservation reservation);
        IQueryable<Reservation> Find();
        Task<Reservation> FindById(Guid id);
        void Remove(Guid reservationId);
    }
}
