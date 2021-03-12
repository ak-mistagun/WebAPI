using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPI.Mappings.Dto.Response;
using WebAPI.Repositories;

namespace WebAPI.Services.Impl
{
    public class MessageService : IMessageService
    {
        private readonly IMessageRepository repository;
        private readonly IMapper mapper;

        public MessageService(IMessageRepository repository, IMapper mapper)
        {
            this.repository = repository;
            this.mapper = mapper;
        }

        public IEnumerable<MessageResponseDto> All()
        {
            return repository.All().Select(message => mapper.Map<MessageResponseDto>(message));
        }
    }
}