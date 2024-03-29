using BankAccounts.Domains.Entities;

namespace BankAccounts.InfraWrite.Repositories.Interfaces
{
    public interface IUserCommand
    {

        Task<bool> DeleteAsync(UserModel userToDelete);

    }
}
