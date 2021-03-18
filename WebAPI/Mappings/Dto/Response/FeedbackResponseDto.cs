using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto.Response
{
    public sealed class FeedbackResponseDto
    {
        [Required] 
        public int Id { get; init; }

        [Required]
        public ContactResponseDto Contact { get; init; }
        
        [Required]
        public TopicResponseDto Topic { get; init; }
        
        [Required]
        public MessageResponseDto Message { get; init; }
    }
}