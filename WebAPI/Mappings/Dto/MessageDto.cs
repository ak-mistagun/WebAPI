using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto
{
    public abstract class MessageDto
    {
        [Required(AllowEmptyStrings = true)]
        public string Text { get; set; }
    }
}