using BankAccounts.Domains;
using BankAccounts.Domains.Entities;
using BankAccounts.InfraRead.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace BankAccounts.InfraRead.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly BankAccountsDbContext _dbContext;

        public UserRepository(BankAccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserModel> GetByEmailAsync(string email)
        {
            try
            {
                UserModel resultado = await _dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);

                if (resultado == null)
                {
                    throw new Exception("User not found in the database.");
                }

                return resultado;
            }
            catch (Exception ex)
            {
                // Log the exception
                Console.WriteLine($"Exception occurred: {ex}");

                // Rethrow the exception or handle it appropriately based on your application's logic
                throw;
            }
        }

        public async Task<UserModel> GetByUsernameAsync(string username)
        {
            try
            {
                UserModel resultado = await _dbContext.Users.FirstOrDefaultAsync(x => x.Username == username);

                if(resultado == null)
                {
                    throw new Exception("Ocorreu um erro ao tentar buscar o usuário no banco de dados!");
                }
                return resultado;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> DeleteAsync(UserModel userToDelete)
        {
            try
            {

                _dbContext.Users.Remove(userToDelete);
                var resultado = await _dbContext.SaveChangesAsync();

                if(resultado == null)
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
                Console.WriteLine($"Ocorreu um erro de banco de dados: {ex.Message}");
                throw ex;
            }
        }
    }
}
