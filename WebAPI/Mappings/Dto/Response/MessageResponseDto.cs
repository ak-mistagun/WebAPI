using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto.Response
{
    public sealed class MessageResponseDto : MessageDto
    {
        [Required]
        public int Id { get; set; }

        [Required] 
        public int TopicId { get; set; }

        [Required] 
        public int ContactId { get; set; }
    }
}