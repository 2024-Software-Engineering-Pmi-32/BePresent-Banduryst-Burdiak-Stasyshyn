using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Reflection.Emit;
using System.Runtime.Remoting.Contexts;
using System.Windows.Documents;

namespace bepresent_wpf.DAL
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Gift> Gifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("Users");
            modelBuilder.Entity<Board>().ToTable("Boards");
            modelBuilder.Entity<Gift>().ToTable("Gifts");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=1234;Database=bePresent");
        }
    }
}
