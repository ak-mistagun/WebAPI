using WebAPI.Mappings.Dto.Request;
using WebAPI.Mappings.Dto.Response;

namespace WebAPI.Services
{
    public interface IFeedbackService
    {
        public FeedbackResponseDto Create(FeedbackRequestDto feedback);
    }
}