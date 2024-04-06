using BankAccounts.Domains.Entities;

namespace BankAccounts.InfraRead.Repositories.Interfaces
{
    public interface IAccountQuery
    {
        Task<AccountModel> GetByIdUserAsync(int id);


    }
}
