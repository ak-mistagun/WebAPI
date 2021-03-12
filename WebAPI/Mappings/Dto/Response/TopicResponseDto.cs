using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto.Response
{
    public sealed class TopicResponseDto : TopicDto
    {
        [Required]
        public int Id { get; set; }
    }
}