using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("feedbacks")]
    public class Feedback : BaseEntity<int>
    {
        public int ContactId { get; private set; }

        public Contact Contact { get; init; }

        public int TopicId { get; private set; }

        public Topic Topic  { get; init; }

        public int MessageId { get; private set; }

        public Message Message { get; init; }
    }
}