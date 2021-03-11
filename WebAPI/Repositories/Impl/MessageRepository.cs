using WebAPI.Database;
using WebAPI.Models;

namespace WebAPI.Repositories.Impl
{
    public class MessageRepository : CrudRepository<int, Message>, IMessageRepository
    {
        public MessageRepository(DbContext context) : base(context)
        {
        }
    }
}