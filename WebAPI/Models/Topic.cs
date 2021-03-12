using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace WebAPI.Models
{
    [Table("topic")]
    [Index(nameof(Name), IsUnique = true, Name = "IndexName")]
    public class Topic : BaseEntity<int>
    {
        [Column("name")]
        [Required(AllowEmptyStrings = false)]
        public string Name { get; init; }
    }
}
