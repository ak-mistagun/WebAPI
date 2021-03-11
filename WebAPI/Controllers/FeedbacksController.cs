using Microsoft.AspNetCore.Mvc;
using WebAPI.Mappings.Dto.In;
using WebAPI.Services;

namespace WebAPI.Controllers
{

    [ApiController]
    [Route("/api/feedbacks")]
    public class FeedbacksController : ControllerBase
    {
        private readonly IFeedbackService feedbackService;

        public FeedbacksController(IFeedbackService feedbackService)
        {
            this.feedbackService = feedbackService;
        }

        [HttpPost]
        public IActionResult CreateFeedback([FromBody] FeedbackInDto dto)
        {
            return Created("", feedbackService.Create(dto));
        }
    }
}