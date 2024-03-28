using BankAccounts.Application.DTOs;
using BankAccounts.Domains.Entities;
using System.Collections.Generic;

namespace BankAccounts.Application.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginDTO> Get(string email, string senha);

        Task<UserModel> Create(UserModel user);

    }
}
