using BankAccounts.Domains;
using BankAccounts.Domains.Entities;
using BankAccounts.InfraWrite.Repositories.Interfaces;

namespace BankAccounts.InfraWrite.Repositories
{
    public class UserCommand : IUserCommand
    {
        private readonly BankAccountsDbContext _dbContext;

        public UserCommand(BankAccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<bool> DeleteAsync(UserModel userToDelete)
        {
            try
            {

                _dbContext.Users.Remove(userToDelete);
                var resultado = await _dbContext.SaveChangesAsync();

                if (resultado == null)
                {
                    throw new Exception("Não foi possível excluir o contato no banco de dados!");
                }

                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
