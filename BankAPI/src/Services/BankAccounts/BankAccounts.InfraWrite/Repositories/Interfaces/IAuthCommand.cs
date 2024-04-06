using BankAccounts.Domains.Entities;

namespace BankAccounts.InfraWrite.Repositories.Interfaces
{
    public interface IAuthCommand
    {

        Task<UserModel> Register(UserModel user);
    }
}
