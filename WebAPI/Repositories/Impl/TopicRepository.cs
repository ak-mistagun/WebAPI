#nullable enable

using System.Linq;
using WebAPI.Database;
using WebAPI.Models;

namespace WebAPI.Repositories.Impl
{
    public class TopicRepository : CrudRepository<int, Topic>, ITopicRepository
    {
        public TopicRepository(WebApiDbContext context) 
            : base(context)
        {
        }

        public Topic? FindByName(string name)
        {
            return Context.Topics.FirstOrDefault(topic => topic.Name == name);
        }
    }
}