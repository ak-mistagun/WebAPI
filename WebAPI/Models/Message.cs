using System.ComponentModel.DataAnnotations.Schema;

namespace WebAPI.Models
{
    [Table("message")]
    public class Message : BaseEntity<int>
    {
        [Column("text")]
        public string Text { get; init; } = string.Empty;

        public int TopicId { get; private set; } = default;

        public Topic Topic { get; private set; } = default;

        public int ContactId { get; private set; } = default;

        public Contact Contact { get; private set; } = default;

        public Message ChangeTopic(Topic topic)
        {
            Topic = topic;
            TopicId = topic.Id;
            return this;
        }

        public Message ChangeContact(Contact contact)
        {
            Contact = contact;
            ContactId = contact.Id;
            return this;
        }
    }
}