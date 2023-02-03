using DAL.Entities;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public class EntityDatabase : DbContext
    {
        public DbSet<User> Users { get; set; }

        public EntityDatabase()
        {
            Database.EnsureCreated();
        }

        string _connect;
        public EntityDatabase(string connect)
        {
            _connect = connect;

        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=DBExamAspNet;Trusted_Connection=True;");

        }
    }
}