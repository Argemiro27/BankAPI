using BankAccounts.Domains;
using BankAccounts.Domains.Entities;
using BankAccounts.InfraRead.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.InfraRead.Repositories
{
    public class UserQuery : IUserQuery
    {
        private readonly BankAccountsDbContext _dbContext;

        public UserQuery(BankAccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserModel> GetByEmailAsync(string email)
        {
            try
            {
                UserModel resultado = await _dbContext.Users.FirstOrDefaultAsync(y => y.Email == email);

                // Caso o usuário não exista, retornará null.
                return resultado;
            }
            catch (Exception ex)
            {
                // Rethrow the exception or handle it appropriately based on your application's logic
                throw ex;
            }
        }

        public async Task<UserModel> GetByUsernameAsync(string username)
        {
            try
            {
                UserModel resultado = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);

                // Caso o usuário não exista, retornará null.
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<UserModel> GetByIdAsync(int id)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(id);
                if (user == null) { throw new Exception("Usuário não encontrado!"); }
                return user;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
