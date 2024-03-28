

using BankAccounts.Domains.Entities;

namespace BankAccounts.InfraRead.Repositories.Interfaces
{
    public interface IAuthRepository
    {

        Task<UserModel> Create(UserModel user);
    }
}
