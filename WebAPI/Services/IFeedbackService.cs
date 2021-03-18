using System.Collections.Generic;
using WebAPI.Mappings.Dto.Request;
using WebAPI.Mappings.Dto.Response;

namespace WebAPI.Services
{
    public interface IFeedbackService
    {
        public IEnumerable<FeedbackResponseDto> All();
        public FeedbackResponseDto Create(FeedbackRequestDto feedbackRequestDto);
    }
}