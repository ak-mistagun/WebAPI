using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Mappings.Dto.Response;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/contacts")]
    public class ContactsController : ControllerBase
    {
        private readonly IContactService contactService;

        public ContactsController(IContactService contactService)
        {
            this.contactService = contactService;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            return new ObjectResult(contactService.All());
        }
    }
}