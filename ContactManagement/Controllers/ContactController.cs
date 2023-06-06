using ContactManagement.Models;
using ContactManagement.Services.ContactService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ContactManagement.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IContactService _contactService;

        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }

        [HttpGet]
        public async Task<ActionResult<List<Contact>>> GetAll()
        {
            var result = await _contactService.GetAll();

            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Contact>> GetSingle(int id)
        {
            var result = await _contactService.GetSingle(id);

            if (result is null)
            {
                return NotFound("Contact doesn't exist.");
            }

            return Ok(result);
        }

        [HttpPost]
        public async Task<ActionResult<List<Contact>>> Create(Contact contact)
        {
            var result = await _contactService.Create(contact);

            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<List<Contact>>> Update(int id, Contact contact)
        {
            var result = await _contactService.Update(id, contact);

            if (result is null)
            {
                return NotFound("Contact not found.");
            }

            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<List<Contact>>> Delete(int id)
        {
            var result = await _contactService.Delete(id);

            if (result is null)
            {
                return NotFound("Contact not found.");
            }

            return Ok(result);
        }
    }
}
