#nullable enable

using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface ITopicRepository : ICrudRepository<int, Topic>
    {
        public Topic? FindByName(string name);
    }
}
