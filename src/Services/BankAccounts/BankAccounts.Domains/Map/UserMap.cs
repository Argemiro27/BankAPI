
using BankAccounts.Domains.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace BankAccounts.Domains.Map
{
    public class UserMap : IEntityTypeConfiguration<UserModel>
    {
        public void Configure(EntityTypeBuilder<UserModel> builder)
        {
            builder.HasKey(x => x.UserId);

            builder.HasOne<AccountModel>()
                .WithMany();
            //builder.Property(x => x.quant_estoque).IsRequired().HasMaxLength(100);

        }
    }
}