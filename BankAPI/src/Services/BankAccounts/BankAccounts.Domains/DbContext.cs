using Microsoft.EntityFrameworkCore;
using BankAccounts.Domains.Entities;

namespace BankAccounts.Domains
{
    public class BankAccountsDbContext : DbContext
    {
        public DbSet<AccountModel> Accounts { get; set; }
        public DbSet<UserModel> Users { get; set; }

        public BankAccountsDbContext(DbContextOptions<BankAccountsDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurando o relacionamento entre AccountModel e UserModel
            modelBuilder.Entity<AccountModel>()
                .HasOne<UserModel>()                  // AccountModel tem um relacionamento com UserModel
                .WithMany()                           // UserModel pode ter várias contas associadas
                .HasForeignKey(a => a.UserId);       // A chave estrangeira em AccountModel é UserId

            base.OnModelCreating(modelBuilder);


        }
    }
}
