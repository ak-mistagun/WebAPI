using AutoMapper;
using WebAPI.Mappings.Dto;
using WebAPI.Mappings.Dto.Out;
using WebAPI.Models;

namespace WebAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Message.BaseModel -> MessageOutDto
            CreateMap<BaseModel<int>, MessageOutDto>()
                .Include<Message, MessageOutDto>();
            CreateMap<Message, MessageOutDto>();
            // MessageOutDto -> Message.BaseModel
            CreateMap<MessageDto, Message>()
                .Include<MessageOutDto, Message>();
            CreateMap<MessageOutDto, Message>();
            // Topic.BaseModel -> TopicOutDto
            CreateMap<BaseModel<int>, TopicOutDto>()
                .Include<Topic, TopicOutDto>();
            CreateMap<Topic, TopicOutDto>();
            // TopicOutDto -> Topic.BaseModel
            CreateMap<TopicDto, Topic>()
                .Include<TopicOutDto, Topic>();
            CreateMap<TopicOutDto, Topic>();
            // Contact.BaseModel -> ContactOutDto
            CreateMap<BaseModel<int>, ContactOutDto>()
                .Include<Contact, ContactOutDto>();
            CreateMap<Contact, ContactOutDto>();
            // Contact -> Contact.BaseModel
            CreateMap<ContactDto, Contact>()
                .Include<ContactOutDto, Contact>();
            CreateMap<ContactOutDto, Contact>();
        }
    }
}