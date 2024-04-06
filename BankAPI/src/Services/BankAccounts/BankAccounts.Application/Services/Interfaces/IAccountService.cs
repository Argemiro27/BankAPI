using BankAccounts.Domains.Entities;
using System.Collections.Generic;

namespace BankAccounts.Application.Services.Interfaces
{
    public interface IAccountService
    {
        //ICollection<AccountModel> Get();

        //Task<AccountModel> GetById(int id);

        Task<AccountModel> Create(AccountModel account);

        //Task<AccountModel> Update(int id, AccountModel user);

        //void Delete(int id);
    }
}
