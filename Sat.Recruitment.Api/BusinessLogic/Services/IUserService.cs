using Sat.Recruitment.Api.BusinessLogic.Models;

namespace Sat.Recruitment.Api.BusinessLogic.Services
{
    public interface IUserService
    {
        public Task<bool> ExistUserAsync(IUser user);

        public Task<IUser> StorerUserAsync(IUser user);

        public IUser CreateNewUserByType(string name, string email, string address, string phone, string type, double money);

    }
}
