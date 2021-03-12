#nullable enable

using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using WebAPI.Models;
using DbContext = WebAPI.Database.DbContext;

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