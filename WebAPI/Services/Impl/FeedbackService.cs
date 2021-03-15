using System;
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