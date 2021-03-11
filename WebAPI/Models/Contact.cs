using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    [Table("contact")]
    [Index(nameof(Email), nameof(Telephone), IsUnique = true, Name = "IndexEmail")]
    public class Contact : BaseModel<int>
    {
        [Column("name")]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; init; }

        [Column("email")]
        [Required(AllowEmptyStrings = false)]
        public string Email { get; init; }
        
        [Column("telephone")]
        [Required(AllowEmptyStrings = false)]
        public string Telephone { get; init; }
    }
}