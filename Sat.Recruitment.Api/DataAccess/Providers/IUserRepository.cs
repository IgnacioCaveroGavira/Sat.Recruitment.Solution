using Sat.Recruitment.Api.DataAccess.Models;

namespace Sat.Recruitment.Api.DataAccess.Providers
{
    public interface IUserRepository
    {
        public Task<UserFile> GetUserAsync(string username, string email, string phone, string address);

        public Task StorerUserAsync(UserFile user);
    }
}
