using BankAccounts.Domains.Entities;

namespace BankAccounts.InfraRead.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<UserModel> GetByIdAsync(int id);

        Task<UserModel> GetByEmailAsync(string email);

        Task<UserModel> GetByUsernameAsync(string username);

        Task<bool> DeleteAsync(UserModel userToDelete);

    }
}
