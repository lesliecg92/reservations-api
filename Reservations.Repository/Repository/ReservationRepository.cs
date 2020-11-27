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
    public class ReservationRepository : IReservationRepository
    {
        private readonly ReservationDbContext _reservationDbContext;

        public ReservationRepository(ReservationDbContext reservationDbContext)
        {
            _reservationDbContext = reservationDbContext;
        }

        public void Insert(Reservation reservation)
        {
             _reservationDbContext.Reservations.Add(reservation);
             _reservationDbContext.SaveChanges();
        }

        public void Update(Reservation reservation)
        {
            var reservationUpdate = _reservationDbContext.Reservations.Find(reservation.ReservationId);
            reservationUpdate.Description = reservation.Description;
            reservationUpdate.Destination = reservation.Destination;
            reservationUpdate.IsFavorite = reservation.IsFavorite;
            reservationUpdate.Ranking = reservation.Ranking;
            _reservationDbContext.SaveChanges();
        }

        public IQueryable<Reservation> Find()
        {
            return _reservationDbContext.Reservations;
        }

        public async Task<Reservation> FindById(Guid id)
        {
            return await _reservationDbContext.Reservations.FindAsync(id);
        }

        public void Remove(Guid reservationId)
        {
            _reservationDbContext.Reservations.Remove(_reservationDbContext.Reservations.Find(reservationId));
            _reservationDbContext.SaveChanges();
        }

    }
}
