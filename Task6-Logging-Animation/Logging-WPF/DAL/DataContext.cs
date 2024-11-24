namespace bepresent_wpf.DAL
{
    using Microsoft.EntityFrameworkCore;
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Board> Boards { get; set; }
        public DbSet<Gift> Gifts { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("users");
            modelBuilder.Entity<Board>().ToTable("boards");
            modelBuilder.Entity<Gift>().ToTable("gifts");
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Username=postgres;Password=1234;Database=bePresent");
        }
    }
}
