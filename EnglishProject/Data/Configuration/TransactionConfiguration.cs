using EnglishProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishProject.Data.Configuration
{
    public class TransactionConfiguration : IEntityTypeConfiguration<Transaction>
    {
        public void Configure(EntityTypeBuilder<Transaction> builder)
        {
            builder.HasKey(c => c.Id);

            builder.HasOne(t => t.User)
              .WithMany(u => u.Transactions)
              .HasForeignKey("UserId")
              .OnDelete(DeleteBehavior.Cascade);

           
            builder.HasOne(t => t.Word)
                .WithMany(w => w.Transactions)
                .HasForeignKey("WordId")
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}
