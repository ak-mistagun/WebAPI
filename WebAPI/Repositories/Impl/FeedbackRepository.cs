using WebAPI.Database;
using WebAPI.Models;

namespace WebAPI.Repositories.Impl
{
    public class FeedbackRepository : CrudRepository<int, Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(DbContext context) 
            : base(context)
        {
        }
    }
}