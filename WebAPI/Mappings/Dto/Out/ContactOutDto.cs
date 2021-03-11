using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto.Out
{
    public sealed class ContactOutDto : ContactDto
    {
        [Required]
        public int Id { get; set; }
    }
}