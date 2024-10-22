using EnglishProject.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EnglishProject.Data.Configuration
{
    public class WordConfiguration : IEntityTypeConfiguration<Word>
    {
        public void Configure(EntityTypeBuilder<Word> builder)
        {
        

            // Primary key tanımlama
            builder.HasKey(w => w.Id);
            builder.Property(w=>w.Terms).HasMaxLength(250);
            builder.Property(w => w.Meaning).HasMaxLength(500);
            builder.Property(w => w.Meaning2).HasMaxLength(500);
            builder.Property(w => w.Meaning3).HasMaxLength(500);





        }
    }
}
