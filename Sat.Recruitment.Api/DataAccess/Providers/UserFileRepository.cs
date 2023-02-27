using Sat.Recruitment.Api.DataAccess.Models;
using System.Text.Json;

namespace Sat.Recruitment.Api.DataAccess.Providers
{
    public class UserFileRepository : IUserRepository
    {
        private readonly IConfiguration _config;
        private readonly string _filePath;

        public UserFileRepository(IConfiguration config)
        {
            _config = config;
            _filePath = Directory.GetCurrentDirectory() + @"\Files\" + _config.GetValue<string>("UserFileName");
        }

        public async Task<UserFile> GetUserAsync(string name, string email, string phone, string address)
        {
            UserFile response= null;

            var users = await this.GetAllUserAsync();
            var found = false;

            for (int i = 0; i < users.Count && !found; i++)
            {
                var userStored = users[i];
                if (userStored.Email == email || userStored.Phone == phone || (userStored.Name == name && userStored.Address == address))
                {
                    response = userStored;
                    found = true;
                }
            }

            return response;
        }

        public async Task StorerUserAsync(UserFile user)
        {
            try
            {
                var users = await this.GetAllUserAsync();
                users.Add(user);

                string usersJson = JsonSerializer.Serialize(users);

                await File.WriteAllTextAsync(_filePath, usersJson);

            }
            catch (Exception e)
            {
                throw new Exception("Error storing user: " + e.Message);
            }
        }

        private async Task<List<UserFile>> GetAllUserAsync()
        {
            List<UserFile> users;

            try
            {
                var aux = await File.ReadAllTextAsync(_filePath);
                users = JsonSerializer.Deserialize<List<UserFile>>(aux);

            }
            catch (Exception e)
            {
                throw new Exception("Error reading users file: " + e.Message);
            }

            return users;
        }
    }
}
