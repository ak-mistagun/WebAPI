using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto.Out
{
    public sealed class MessageOutDto : MessageDto
    {
        [Required]
        public int Id { get; set; }
    }
}