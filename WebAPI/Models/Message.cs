using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("message")]
    public class Message : BaseModel<int>
    {
        [Column("text")]
        public string Text { get; init; } = string.Empty;
    }
}