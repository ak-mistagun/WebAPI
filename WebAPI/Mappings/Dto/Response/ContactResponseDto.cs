using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto.Response
{
    public sealed class ContactResponseDto : ContactDto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public IEnumerable<int> MessageIds { get; set; }
    }
}