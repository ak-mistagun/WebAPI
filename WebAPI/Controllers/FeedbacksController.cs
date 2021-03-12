using Microsoft.AspNetCore.Mvc;
using WebAPI.Mappings.Dto.Request;
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
        public IActionResult CreateFeedback([FromBody] FeedbackRequestDto dto)
        {
            return Created("", feedbackService.Create(dto));
        }
    }
}