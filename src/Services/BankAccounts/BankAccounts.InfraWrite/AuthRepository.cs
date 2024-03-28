
using BankAccounts.Domains;
using BankAccounts.Domains.Entities;
using BankAccounts.InfraRead.Repositories.Interfaces;

namespace BankAccounts.InfraRead.Repositories
{
    public class AuthRepository : IAuthRepository
    {
        private readonly BankAccountsDbContext _dbContext;

        public AuthRepository (BankAccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserModel> Create(UserModel user)
        {
            // Adiciona o usuário ao contexto do banco de dados
            var newUser = _dbContext.Users.Add(user);

            // Salva as mudanças no banco de dados e aguarda a conclusão
            await _dbContext.SaveChangesAsync();

            // Retorna o UserModel adicionado
            return newUser.Entity;
        }
    }
}
