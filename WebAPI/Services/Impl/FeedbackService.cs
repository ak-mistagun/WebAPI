using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using WebAPI.Mappings.Dto.Request;
using WebAPI.Mappings.Dto.Response;
using WebAPI.Models;
using WebAPI.Repositories;
using WebAPI.Services.Exceptions;
using WebAPI.Untils;

namespace WebAPI.Services.Impl
{
    public class FeedbackService: IFeedbackService
    {
        private readonly IFeedbackRepository feedbackRepository;
        private readonly IContactRepository contactRepository;
        private readonly IMessageRepository messageRepository;
        private readonly ITopicRepository topicRepository;
        private readonly IMapper mapper;

        public FeedbackService(IFeedbackRepository feedbackRepository,
            IContactRepository contactRepository, 
            IMessageRepository messageRepository, 
            ITopicRepository topicRepository, 
            IMapper mapper)
        {
            this.feedbackRepository = feedbackRepository;
            this.contactRepository = contactRepository;
            this.messageRepository = messageRepository;
            this.topicRepository = topicRepository;
            this.mapper = mapper;
        }

        public IEnumerable<FeedbackResponseDto> All()
        {
            return feedbackRepository.All().Select(feedback => mapper.Map<FeedbackResponseDto>(feedback));
        }

        public FeedbackResponseDto Create(FeedbackRequestDto feedback)
        {
            var contact = contactRepository.FindByEmailAndTelephone(feedback.Contact.Email, feedback.Contact.Telephone) ??
                          contactRepository.Create(mapper.Map<Contact>(feedback.Contact));
            var topic = topicRepository.FindByName(feedback.Topic.Name)
                .OrElseThrow(() => new TopicNotFoundException($"Topic with name {feedback.Topic.Name} not found"));
            var message = messageRepository.Create(mapper.Map<Message>(feedback.Message));

            message.ChangeContact(contact.AddMessage(message))
                .ChangeTopic(topic);

            contactRepository.Save();
            topicRepository.Save();
            messageRepository.Save();
                
            return new FeedbackResponseDto
            {
                Contact = mapper.Map<ContactResponseDto>(contact),
                Topic = mapper.Map<TopicResponseDto>(topic),
                Message = mapper.Map<MessageResponseDto>(message)
            };
        }
    }
}