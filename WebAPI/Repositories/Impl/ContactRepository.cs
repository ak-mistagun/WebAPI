#nullable enable

using System.Linq;
using WebAPI.Database;
using WebAPI.Models;

namespace WebAPI.Repositories.Impl
{
    public class ContactRepository : CrudRepository<int, Contact>, IContactRepository
    {
        public ContactRepository(DbContext context) 
            : base(context)
        {
        }

        public Contact? FindByEmailAndTelephone(string email, string telephone)
        {
            return Context.Contacts.FirstOrDefault(contact => contact.Email == email && contact.Telephone == telephone);
        }
    }
}