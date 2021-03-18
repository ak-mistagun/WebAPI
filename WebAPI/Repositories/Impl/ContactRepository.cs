#nullable enable

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Database;
using WebAPI.Models;

namespace WebAPI.Repositories.Impl
{
    public class ContactRepository : CrudRepository<int, Contact>, IContactRepository
    {
        public ContactRepository(WebApiDbContext context) 
            : base(context)
        {
        }

        public Contact? FindByEmailAndTelephone(string email, string telephone)
        {
            return Context.Contacts
                .Include(contact => contact.Messages)
                .FirstOrDefault(contact => contact.Email == email && contact.Telephone == telephone);
        }

        public override IEnumerable<Contact> All()
        {
            return Context.Contacts
                .Include(contact => contact.Messages);
        }
    }
}