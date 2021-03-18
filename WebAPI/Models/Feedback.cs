using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("feedbacks")]
    public class Feedback : BaseEntity<int>
    {

        public Contact Contact { get; init; }


        public Topic Topic  { get; init; }


        public Message Message { get; init; }
    }
}