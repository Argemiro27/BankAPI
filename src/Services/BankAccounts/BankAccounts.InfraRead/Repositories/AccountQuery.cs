using BankAccounts.Domains;
using BankAccounts.Domains.Entities;
using BankAccounts.InfraRead.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.InfraRead.Repositories
{
    public class AccountQuery : IAccountQuery
    {
        private readonly BankAccountsDbContext _dbContext;

        public AccountQuery(BankAccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<AccountModel> GetByIdUserAsync(int idUser)
        {
            try
            {
                AccountModel resultado = await _dbContext.Accounts.FirstOrDefaultAsync(x => x.UserId == idUser);

                // Caso o usuário não exista, retornará null.
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
