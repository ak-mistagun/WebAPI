#nullable enable

using WebAPI.Models;

namespace WebAPI.Repositories
{
    public interface IContactRepository : ICrudRepository<int, Contact>
    {
        public Contact? FindByEmailAndTelephone(string email, string telephone);
    }
}

#nullable disable