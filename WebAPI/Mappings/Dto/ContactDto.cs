using System.ComponentModel.DataAnnotations;

namespace WebAPI.Mappings.Dto
{
    public abstract class ContactDto
    {
        [Required(AllowEmptyStrings = false)]
        public string Name { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        [EmailAddress]
        public string Email { get; set; }
        
        [Required(AllowEmptyStrings = false)]
        [Phone]
        public string Telephone { get; set; }
    }
}