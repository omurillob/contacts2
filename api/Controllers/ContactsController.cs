using Microsoft.AspNetCore.Mvc;
using contacts2.Services;
using contacts2.Models;
using Microsoft.AspNetCore.Authorization;

namespace contacts2.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ContactsController(ContactService contactService) : ControllerBase
    {
        [HttpGet]
        public IActionResult GetContacts()
        {
            var contacts = contactService.GetContacts();
            return Ok(contacts);
        }

        [HttpGet("{id}")]
        public IActionResult GetContactById(int id)
        {
            var contact = contactService.GetContactById(id);
            if (contact == null)
            {
                return NotFound();
            }
            return Ok(contact);
        }

        [HttpPut("{id}")]
        public IActionResult UpdateContact(int id, [FromBody] Contact contact)
        {
            if (id != contact.Id)
            {
                return BadRequest();
            }

            contactService.AddorUpdateContact(contact);

            return NoContent();
        }
    }
}