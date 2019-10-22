using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace CardCreator
{
    public class CCContext : DbContext
    {
        public DbSet<Card> Cards { get; set; }
        public DbSet<Type> Types { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server = (localdb)\MSSQLLocalDB;" +
                @"Database = CardCreator;" +
                @"Trusted_Connection = True;");

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Card>()
                .HasOne<Type>(s => s.Type)
                .WithMany(g => g.Card);
        }
    }

    public class Card
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public int Cost { get; set; }
        public Type Type { get; set; }
        public string Image { get; set; }

    }

    public class Type
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Max_Attack { get; set; }
        public int Min_Attack { get; set; }
        public int Max_Defence { get; set; }
        public int Min_Defence { get; set; }
        public int Max_Cost { get; set; }
        public int Min_Cost { get; set; }
        public ICollection<Card> Card { get; set; }

    }
}