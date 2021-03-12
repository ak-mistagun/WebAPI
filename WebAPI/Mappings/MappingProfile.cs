using System.Linq;
using AutoMapper;
using WebAPI.Mappings.Dto;
using WebAPI.Mappings.Dto.Response;
using WebAPI.Models;

namespace WebAPI.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Message.BaseModel -> MessageOutDto
            CreateMap<BaseEntity<int>, MessageResponseDto>()
                .Include<Message, MessageResponseDto>();
            CreateMap<Message, MessageResponseDto>();
            // MessageOutDto -> Message.BaseModel
            CreateMap<MessageDto, Message>()
                .Include<MessageResponseDto, Message>();
            CreateMap<MessageResponseDto, Message>();
            // Topic.BaseModel -> TopicOutDto
            CreateMap<BaseEntity<int>, TopicResponseDto>()
                .Include<Topic, TopicResponseDto>();
            CreateMap<Topic, TopicResponseDto>();
            // TopicOutDto -> Topic.BaseModel
            CreateMap<TopicDto, Topic>()
                .Include<TopicResponseDto, Topic>();
            CreateMap<TopicResponseDto, Topic>();
            
            MapFromContactToDto();
            MapFromDtoToContact();
        }

        private void MapFromContactToDto()
        {
            CreateMap<BaseEntity<int>, ContactResponseDto>()
                .Include<Contact, ContactResponseDto>();
            CreateMap<Contact, ContactResponseDto>()
                .ForMember(dto => dto.MessageIds,
                    opt => opt.MapFrom(contact => contact.Messages.Select(c => c.Id)));
        }

        private void MapFromDtoToContact()
        {
            CreateMap<ContactDto, Contact>()
                .Include<ContactResponseDto, Contact>();
            CreateMap<ContactResponseDto, Contact>();
        }
    }
}