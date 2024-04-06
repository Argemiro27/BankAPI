using BankAccounts.Domains.Entities;

namespace BankAccounts.InfraRead.Repositories.Interfaces
{
    public interface IUserQuery
    {
        Task<UserModel> GetByIdAsync(int id);

        Task<UserModel> GetByEmailAsync(string email);

        Task<UserModel> GetByUsernameAsync(string username);


    }
}
