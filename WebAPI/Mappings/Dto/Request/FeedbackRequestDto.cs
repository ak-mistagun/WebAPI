using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto.Request
{
    public sealed class FeedbackRequestDto
    {
        [Required]
        public ContactRequestDto Contact { get; set; }
        
        [Required]
        public TopicRequestDto Topic { get; set; }
        
        [Required]
        public MessageRequestDto Message { get; set; }
    }
}