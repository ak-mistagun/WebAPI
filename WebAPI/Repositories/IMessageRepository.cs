using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IMessageRepository : ICrudRepository<int, Message>
    {
        
    }
}