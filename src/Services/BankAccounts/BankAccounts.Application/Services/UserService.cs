using BankAccounts.Application.Services.Interfaces;
using BankAccounts.Domains.Entities;
using BankAccounts.InfraRead.Repositories.Interfaces;

namespace BankAccounts.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public UserModel Create(UserModel user)
        {
            throw new NotImplementedException();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            UserModel userToDelete = await _userRepository.GetByIdAsync(id);
            return await _userRepository.DeleteAsync(userToDelete);
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
