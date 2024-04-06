using BankAccounts.Domains;
using BankAccounts.Domains.Entities;
using BankAccounts.InfraWrite.Repositories.Interfaces;

namespace BankAccounts.InfraWrite.Repositories
{
    public class AuthCommand : IAuthCommand
    {
        private readonly BankAccountsDbContext _dbContext;

        public AuthCommand(BankAccountsDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<UserModel> Register(UserModel user)
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
