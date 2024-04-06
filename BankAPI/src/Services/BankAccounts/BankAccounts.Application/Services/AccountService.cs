using BankAccounts.Application.Services.Interfaces;
using BankAccounts.Domains.Entities;
using BankAccounts.InfraRead.Repositories.Interfaces;
using BankAccounts.InfraWrite.Repositories.Interfaces;

namespace BankAccounts.Application.Services
{
    public class AccountService : IAccountService
    {
        private readonly IAccountCommand _accountCommand;
        private readonly IAccountQuery _accountQuery;
        private readonly IUserQuery _userQuery;

        public AccountService(IAccountCommand accountCommand, 
                            IAccountQuery accountQuery,
                            IUserQuery userQuery)
        {
            _accountCommand = accountCommand;
            _accountQuery = accountQuery;
            _userQuery = userQuery;
        }

        public async Task<AccountModel> Create(AccountModel account)
        {
            try
            {
                AccountModel checkAccount = await _accountQuery.GetByIdUserAsync(account.UserId);
                // Verificar se o usuário já existe
                if (checkAccount != null)
                {
                    throw new Exception("Usuário já possui uma conta cadastrada!");
                }

                UserModel checkUserExists = await _userQuery.GetByIdAsync(account.UserId);

                if (checkUserExists == null) {
                    throw new Exception("Usuário informado não encontrado!");
                }

                AccountModel newAccount = await _accountCommand.Create(account);

                if (newAccount == null) { throw new Exception("Ocorreu um erro ao tentar cadastrar a conta no banco de dados!"); }

                return newAccount;
            }catch (Exception ex)
            {
                throw ex;
            }
        }

    }
}
