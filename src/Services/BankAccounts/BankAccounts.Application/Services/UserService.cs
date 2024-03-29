using BankAccounts.Application.Services.Interfaces;
using BankAccounts.Domains.Entities;
using BankAccounts.InfraRead.Repositories.Interfaces;
using BankAccounts.InfraWrite.Repositories.Interfaces;

namespace BankAccounts.Application.Services
{
    public class UserService : IUserService
    {
        private IUserQuery _userQuery;
        private IUserCommand _userCommand;

        public UserService(IUserQuery userQuery, IUserCommand userCommand)
        {
            _userQuery = userQuery;
            _userCommand = userCommand;
        }

        public UserModel Create(UserModel user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            UserModel userToDelete = await _userQuery.GetByIdAsync(id);
            return await _userCommand.DeleteAsync(userToDelete);
        }

        public IEnumerable<UserModel> Get()
        {
            throw new NotImplementedException();
        }

        public UserModel GetById(int id)
        {
            throw new NotImplementedException();
        }

        public UserModel Update(int id, UserModel user)
        {
            throw new NotImplementedException();
        }
    }
}
