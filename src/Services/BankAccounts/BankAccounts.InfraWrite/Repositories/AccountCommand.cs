using BankAccounts.Domains;
using BankAccounts.Domains.Entities;
using BankAccounts.InfraWrite.Repositories.Interfaces;

namespace BankAccounts.InfraWrite.Repositories
{
    public class AccountCommand : IAccountCommand
    {
        private readonly BankAccountsDbContext _dbContext;

        public AccountCommand(BankAccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AccountModel> Create(AccountModel account)
        {
            // Adiciona o usuário ao contexto do banco de dados
            var newAccount = _dbContext.Accounts.Add(account);

            // Salva as mudanças no banco de dados e aguarda a conclusão
            await _dbContext.SaveChangesAsync();

            // Retorna o UserModel adicionado
            return newAccount.Entity;
        }

    }
}
