using BankAccounts.Domains.Entities;
using System.Collections.Generic;

namespace BankAccounts.Application.Services.Interfaces
{
    public interface IAccountService
    {
        IEnumerable<AccountModel> Get();

        AccountModel GetById(int id);

        AccountModel Create(AccountModel user);

        AccountModel Update(int id, AccountModel user);

        void Delete(int id);
    }
}
