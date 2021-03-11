using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto.In
{
    public sealed class FeedbackInDto
    {
        [Required]
        public ContactInDto Contact { get; set; }
        
        [Required]
        public TopicInDto Topic { get; set; }
        
        [Required]
        public MessageInDto Message { get; set; }
    }
}