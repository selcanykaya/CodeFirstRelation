using CodeFirstRelation.Entities;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstRelation.Context
{
    public class PatikaSecondDbContext : DbContext
    {
        public DbSet<UserEntity> Users { get; set; }

        public DbSet<PostEntity> Posts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost\\SQLEXPRESS;Database=PatikaCodeFirstDb2;Trusted_Connection=True;TrustServerCertificate=True;");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            //İlişkiler
            modelBuilder.Entity<PostEntity>()
                .HasOne(p => p.User) //Her post bir usera aittir.
                .WithMany(u => u.Posts) //Bir userın birden fazla postu olabilir.
                .HasForeignKey(p => p.UserId); //Postların yazarı UserId ile belirlenir 
        }
    }
}