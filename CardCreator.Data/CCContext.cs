using Microsoft.EntityFrameworkCore;
using CardCreator.Domain;


namespace CardCreator.Data
{
    public class CCContext : DbContext
    {
        public DbSet<Card> Card { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server = (localdb)\MSSQLLocalDB;" + 
                @"Database = CardCreator;" + 
                @"Trusted_Connection = True;"); 

        }
    }
}
