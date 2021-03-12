using System.Collections.Generic;
using WebAPI.Mappings.Dto.Response;

namespace WebAPI.Services
{
    public interface ITopicService
    {
        IEnumerable<TopicResponseDto> All();
    }
}