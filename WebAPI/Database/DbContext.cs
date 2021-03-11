using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Database
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(DbContextOptions options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }
    }
}