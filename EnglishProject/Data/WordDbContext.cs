using EnglishProject.Data.Configuration;
using EnglishProject.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace EnglishProject.Data
{
    public class WordDbContext:DbContext
    {
        public WordDbContext(DbContextOptions<WordDbContext> options) : base(options)
        { 
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Transaction> Transactions { get; set; }
        public DbSet<Word> Words { get; set; }
        public DbSet<Test> Tests{ get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserConfiguration());
            modelBuilder.ApplyConfiguration(new TransactionConfiguration());
            modelBuilder.ApplyConfiguration(new WordConfiguration());


        }





    }
}
