using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebAPI.Models;

namespace WebAPI.Database
{
    public class DbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public DbContext(IConfiguration cfg, DbContextOptions options) 
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<Topic> Topics { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Contact> Contacts { get; set; }

        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>()
                .HasOne(message => message.Contact)
                .WithMany(contact => contact.Messages);

            modelBuilder.Entity<Contact>()
                .HasMany(contact => contact.Messages)
                .WithOne(message => message.Contact);
            
            // default topics.
            modelBuilder.Entity<Topic>().HasData(
                new Topic {Id = 1, Name = "first"}, 
                new Topic {Id = 2, Name = "second"}, 
                new Topic {Id = 3, Name = "third"});
        }
    }
}