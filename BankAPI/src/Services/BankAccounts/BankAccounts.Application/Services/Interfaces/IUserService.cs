using BankAccounts.Domains.Entities;
using System.Collections.Generic;

namespace BankAccounts.Application.Services.Interfaces
{
    public interface IUserService
    {
        ICollection<UserModel> Get();

        UserModel GetById(int id);

        UserModel Create(UserModel user);

        UserModel Update(int id, UserModel user);

        Task<bool> DeleteAsync(int id);
    }
}
