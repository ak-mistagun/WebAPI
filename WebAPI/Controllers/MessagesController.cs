using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Services;

namespace WebAPI.Controllers
{
    [ApiController]
    [Route("/api/messages")]
    public class MessagesController : ControllerBase
    {
        private readonly IMessageService messageService;

        public MessagesController(IMessageService messageService)
        {
            this.messageService = messageService;
        }

        [HttpGet]
        [AllowAnonymous]
        public IActionResult GetAll()
        {
            return new ObjectResult(messageService.All());
        }
    }
}