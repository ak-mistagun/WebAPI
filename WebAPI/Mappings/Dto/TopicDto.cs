using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto
{
    public abstract class TopicDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
    }
}