using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Controllers.Filters;
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

        [HttpGet]
        public IActionResult All()
        {
            return new ObjectResult(feedbackService.All());
        }
        
        [TopicNotFoundExceptionFilter]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult CreateFeedback([FromBody] FeedbackRequestDto dto)
        {
            return Created("", feedbackService.Create(dto));
        }
    }
}