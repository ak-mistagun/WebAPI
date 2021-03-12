using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPI.Mappings.Dto.Response;
using WebAPI.Repositories;

namespace WebAPI.Services.Impl
{
    public class TopicService : ITopicService
    {
        private readonly ITopicRepository repository;
        private readonly IMapper mapper;

        public TopicService(ITopicRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<TopicResponseDto> All()
        {
                return repository.All().Select(topic => mapper.Map<TopicResponseDto>(topic));
        }
    }
}