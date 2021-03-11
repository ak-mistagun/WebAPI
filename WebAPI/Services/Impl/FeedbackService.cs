using AutoMapper;
using WebAPI.Mappings.Dto.In;
using WebAPI.Mappings.Dto.Out;
using WebAPI.Models;
using WebAPI.Repositories;

namespace WebAPI.Services.Impl
{
    public class FeedbackService: IFeedbackService
    {
        private readonly IContactRepository contactRepository;
        private readonly IMessageRepository messageRepository;
        private readonly ITopicRepository topicRepository;
        private readonly IMapper mapper;

        public FeedbackService(IContactRepository contactRepository, 
            IMessageRepository messageRepository, 
            ITopicRepository topicRepository, 
            IMapper mapper)
        {
            this.contactRepository = contactRepository;
            this.messageRepository = messageRepository;
            this.topicRepository = topicRepository;
            this.mapper = mapper;
        }

        public FeedbackOutDto Create(FeedbackInDto dto)
        {
            var contact = contactRepository.FindByEmailAndTelephone(dto.Contact.Email, dto.Contact.Telephone) ??
                          contactRepository.Create(mapper.Map<Contact>(dto.Contact));
            var topic = topicRepository.FindByName(dto.Topic.Name) ?? 
                        topicRepository.Create(mapper.Map<Topic>(dto.Topic));
            var message = messageRepository.Create(mapper.Map<Message>(dto.Message));

            return new FeedbackOutDto
            {
                Contact = mapper.Map<ContactOutDto>(contact),
                Topic = mapper.Map<TopicOutDto>(topic),
                Message = mapper.Map<MessageOutDto>(message)
            };
        }
    }
}