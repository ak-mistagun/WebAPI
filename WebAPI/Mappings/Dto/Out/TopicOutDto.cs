using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto.Out
{
    public sealed class TopicOutDto : TopicDto
    {
        [Required]
        public int Id { get; set; }
    }
}