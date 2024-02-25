using Microsoft.EntityFrameworkCore;

namespace EmailTemplatesBuilder.Models
{
    public class EmailDBContext : DbContext
    {
        public DbSet<Message> Messages { get; set; }

        public DbSet<Item> Items { get; set; }

        public DbSet<ContentDescriptor>  Descriptors { get; set; }

        public EmailDBContext(DbContextOptions<EmailDBContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Message>();

            base.OnModelCreating(modelBuilder);
        }
    }
}
