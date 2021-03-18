using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Models;

namespace WebAPI.Repositories.Impl
{
    public class FeedbackRepository : CrudRepository<int, Feedback>, IFeedbackRepository
    {
        public FeedbackRepository(WebApiDbContext context) 
            : base(context)
        {
        }

        public override IEnumerable<Feedback> All()
        {
            return Context.Feedbacks
                .Include(feedback => feedback.Contact)
                .Include(feedback => feedback.Topic)
                .Include(feedback => feedback.Message);
        }
    }
}