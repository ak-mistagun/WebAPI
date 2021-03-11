using WebAPI.Mappings.Dto.In;
using WebAPI.Mappings.Dto.Out;

namespace WebAPI.Services
{
    public interface IFeedbackService
    {
        public FeedbackOutDto Create(FeedbackInDto dto);
    }
}