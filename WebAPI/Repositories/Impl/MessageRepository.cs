using WebAPI.Database;
using WebAPI.Models;

namespace WebAPI.Repositories.Impl
{
    public class MessageRepository : CrudRepository<int, Message>, IMessageRepository
    {
        public MessageRepository(WebApiDbContext context) : base(context)
        {
        }
    }
}