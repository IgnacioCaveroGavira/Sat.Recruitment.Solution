using Sat.Recruitment.Api.BusinessLogic.Models;
using Sat.Recruitment.Api.DataAccess.Models;
using Sat.Recruitment.Api.DataAccess.Providers;

namespace Sat.Recruitment.Api.BusinessLogic.Services
{
    public class UserService : IUserService
    {
        public readonly IUserRepository _userRepository;

        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<bool> ExistUserAsync(IUser user)
        {
            var userFile = await _userRepository.GetUserAsync(user.Name,user.Email, user.Phone, user.Address);
            return userFile!= null;
        }

        public async Task<IUser> StorerUserAsync(IUser user)
        {
            
            var userFile = new UserFile()
            {
                Name = user.Name,
                Email = user.Email,
                Address = user.Address,
                Phone = user.Phone,
                Type = user.Type.ToString(),
                Money = user.Money
            };

            await _userRepository.StorerUserAsync(userFile);

            return user;
        }

        public IUser CreateNewUserByType(string name, string email, string address, string phone, string userType, double money)
        {

            IUser res = null;

            switch (userType)
            {
                case "Normal":
                    res = new NormalUser(name, email, address, phone, money, isNewUser: true);
                    break;

                case "Super":
                    res = new SuperUser(name, email, address, phone, money, isNewUser: true);
                    break;

                case "Premium":
                    res = new PremiumUser(name, email, address, phone, money, isNewUser: true);
                    break;

                default:
                    break;
            }

            return res;
        }

    }
}
