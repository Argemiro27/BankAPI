
using BankAccounts.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAccounts.Domains.Map
{
    public class AccountMap : IEntityTypeConfiguration<AccountModel>
    {
        public void Configure(EntityTypeBuilder<AccountModel> builder)
        {
            builder.HasKey(x => x.AccountId);

            builder.HasOne<AccountModel>()
                .WithMany()
                .HasForeignKey(x => x.UserId);
            //builder.Property(x => x.quant_estoque).IsRequired().HasMaxLength(100);


            builder.HasIndex(x => x.UserId)
                .IsUnique();
        }
    }
}