using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto.Out
{
    public sealed class FeedbackOutDto
    {
        [Required]
        public ContactOutDto Contact { get; init; }
        
        [Required]
        public TopicOutDto Topic { get; init; }
        
        [Required]
        public MessageOutDto Message { get; init; }
    }
}