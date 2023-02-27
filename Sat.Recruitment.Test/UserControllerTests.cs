using Microsoft.AspNetCore.Mvc;
using Moq;
using Sat.Recruitment.Api.BusinessLogic.Models;
using Sat.Recruitment.Api.BusinessLogic.Services;
using Sat.Recruitment.Api.Presentation.Models;
using Sat.Recruitment.Api.Presentation.Models.Controllers;
using System.Threading.Tasks;
using Xunit;

namespace Sat.Recruitment.Test
{
    public class UserControllerTests
    {
        [Fact]
        public async Task CreateUser_CreateAUser_ReturnTheCreatedUser()
        {
            // Arrange
            var user = new UserRequest()
            {
                Name = "NameTest",
                Address = "AddressTest",
                Email = "email@test.com",
                Money = 1,
                Phone = "696 696 696",
                UserType = UserType.Normal.ToString()
            };

            IUser normalUser = new NormalUser("NormalUser", "NormalUser", "NormalUser", "NormalUser", 100);

            var mockUserService = new Mock<IUserService>();

            mockUserService.Setup(service => service.CreateNewUserByType(user.Name, user.Email, user.Address, user.Phone, user.UserType, user.Money)).Returns(CreateNewUserByTypeTest());
            mockUserService.Setup(service => service.ExistUserAsync(normalUser)).ReturnsAsync(getBoolTest());
            mockUserService.Setup(service => service.StorerUserAsync(normalUser)).ReturnsAsync(CreateNewUserByTypeTest());

            var userController = new UsersController(mockUserService.Object);


            //Act
            var result = await userController.CreateUser(user);


            //Assert
            Assert.IsType<OkResult>(result);

            //Assert.Equal(user.Name, result.Name);
            //Assert.Equal(user.Email, result.Email);
            //Assert.Equal(user.Address, result.Address);
        }

        private IUser CreateNewUserByTypeTest()
        {
            IUser res = new NormalUser("NameTest", "email@test.com", "AddressTest", "696 696 696", 123, true);
            return res;
        }

        private bool getBoolTest()
        {
            return true;
        }
    }
}