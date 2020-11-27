using System;
using System.Collections.Generic;
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
    public class ContactController : ControllerBase
    {

        private static IReservationBusiness _reservationBusiness;

        public ContactController(IReservationBusiness reservationBusiness)
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

            var (contacts, total) = await _reservationBusiness.GetContactsList(paginationViewModel.PageSize,
                paginationViewModel.Page, paginationViewModel.OrderBy, paginationViewModel.Order);

            return new OkObjectResult(new ContactViewModel
            {
                Contacts = contacts.ToList(),
                Total = total
            });

        }

        [HttpGet("ContactTypes")]
        public async Task<IActionResult> GetContactTypes()
        {
            var types = await _reservationBusiness.GetContactTypes();
            return new OkObjectResult(types);
        }

        [HttpGet("ContactByName/{name}")]
        public async Task<IActionResult> Get(string name)
        {
            var contact = await _reservationBusiness.GetContactByName(name);
            return new OkObjectResult(contact);
        }

        
        [HttpPost("Add")]
        public void Post([FromBody] ContactModel contactModel)
        {
            _reservationBusiness.AddContact(contactModel.ToContact());
        }

        [HttpPut("Update")]
        public void Put([FromBody] Contact contact)
        {
            _reservationBusiness.UpdateContact(contact);
        }

        [HttpDelete("Delete/{id}")]
        public void Delete(Guid id)
        {
            _reservationBusiness.DeleteContact(id);
        }
    }
}
