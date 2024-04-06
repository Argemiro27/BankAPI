using BankAccounts.Domains.Entities;

namespace BankAccounts.InfraWrite.Repositories.Interfaces
{
    public interface IAccountCommand
    {

        Task<AccountModel> Create(AccountModel account);
    }
}
