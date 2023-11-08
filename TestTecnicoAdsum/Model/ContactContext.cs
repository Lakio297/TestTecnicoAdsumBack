using Microsoft.EntityFrameworkCore;

namespace TestTecnicoAdsum.Model
{
    public class ContactContext : DbContext
    {
        public DbSet<ContactModel> Contacts { get; set; }

        public ContactContext(DbContextOptions<ContactContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<ContactModel>()
                .Property(c => c.Id)
                .ValueGeneratedOnAdd();
        }
    }
}
