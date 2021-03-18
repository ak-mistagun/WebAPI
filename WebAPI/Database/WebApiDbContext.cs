using Microsoft.EntityFrameworkCore;
using WebAPI.Models;

namespace WebAPI.Database
{
    public class WebApiDbContext : Microsoft.EntityFrameworkCore.DbContext
    {
        public WebApiDbContext(DbContextOptions<WebApiDbContext> options) 
            : base(options)
        {
        }

        public DbSet<Feedback> Feedbacks { get; set; }
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
                new Topic { Id = 1, Name = "technical support" }, 
                new Topic { Id = 2, Name = "sales" }, 
                new Topic { Id = 3, Name = "other" });
        }
    }
}