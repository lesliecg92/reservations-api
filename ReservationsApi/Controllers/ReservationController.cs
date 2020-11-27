using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Reservations.Business;
using Reservations.Repository.Domain;
using Reservations.Web.Api.Extensions;
using Reservations.Web.Api.ViewModel;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Reservations.Web.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private static IReservationBusiness _reservationBusiness;

        public ReservationController(IReservationBusiness reservationBusiness)
        {
            _reservationBusiness = reservationBusiness;
        }


        [HttpPost("List")]
        public async Task<IActionResult> Get([FromBody] PaginationViewModel paginationViewModel)
        {
            if (paginationViewModel == null)
            {
                return BadRequest();
            }

            var (reservations, total) = await _reservationBusiness.GetReservationsList(paginationViewModel.PageSize,
                paginationViewModel.Page, paginationViewModel.OrderBy, paginationViewModel.Order);
            
            return new OkObjectResult(new ReservationsViewModel
            {
                Reservations = reservations.ToList(),
                Total = total
            });

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(Guid id)
        {
            var reservation = await _reservationBusiness.GetReservation(id);
            
            if (reservation == null)
            {
                NotFound();
            }

            return new OkObjectResult(reservation);
        }

        [HttpPost("Add")]
        public IActionResult Post([FromBody] ReservationModel reservationModel)
        {
            if (reservationModel == null)
            {
                BadRequest();
            }

            _reservationBusiness.AddReservation(reservationModel.ToReservation());
            return Ok();
        }

        [HttpPut("Update")]
        public void Put([FromBody] Reservation reservation)
        {
            _reservationBusiness.UpdateReservation(reservation);
        }

        [HttpDelete("Delete/{id}")]
        public void Delete(Guid id)
        {
            _reservationBusiness.DeleteReservation(id);
        }
    }
}
