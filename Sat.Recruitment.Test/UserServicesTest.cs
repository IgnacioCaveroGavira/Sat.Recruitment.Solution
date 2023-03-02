
using Moq;
using Sat.Recruitment.Api.BusinessLogic.Models;
using Sat.Recruitment.Api.BusinessLogic.Services;
using Xunit;
using Sat.Recruitment.Api.DataAccess.Providers;

namespace Sat.Recruitment.Test
{
    public class UserServicesTest
    {
        [Fact]
        public void CreateNewUserByType_CreateNomarlUser_ReturnNormalUser()
        {
            // Arrange
            string name = "NameTest";
            string address = "AddressTest";
            string email = "email@test.com";
            string phone = "696 696 696";
            double money = 123;
            UserType userType = UserType.Normal;
        
            var mockUserRepository = new Mock<IUserRepository>();

            var userService = new UserService(mockUserRepository.Object);

            //Act
            var userResult = userService.CreateNewUserByType(name, email, address, phone, userType.ToString(), money);

            //Assert
            Assert.IsType<NormalUser>(userResult);
            Assert.Equal(name, userResult.Name);
            Assert.Equal(email, userResult.Email);
            Assert.Equal(address, userResult.Address);
            Assert.Equal(phone, userResult.Phone);

        }

        [Fact]
        public void CreateNewUserByType_CreateSuperUser_ReturnSuperUser()
        {
            // Arrange

            string name = "NameTest";
            string address = "AddressTest";
            string email = "email@test.com";
            string phone = "696 696 696";
            double money = 123;
            UserType userType = UserType.Super;

            var mockUserRepository = new Mock<IUserRepository>();

            var userService = new UserService(mockUserRepository.Object);


            //Act
            var userResult = userService.CreateNewUserByType(name, email, address, phone, userType.ToString(), money);


            //Assert
            Assert.IsType<SuperUser>(userResult);
            Assert.Equal(name, userResult.Name);
            Assert.Equal(email, userResult.Email);
            Assert.Equal(address, userResult.Address);
            Assert.Equal(phone, userResult.Phone);
            //Assert.Equal(money, userResult.Money);

        }

        [Fact]
        public void CreateNewUserByType_CreatePremiumUser_ReturnPremiumUser()
        {
            // Arrange

            string name = "NameTest";
            string address = "AddressTest";
            string email = "email@test.com";
            string phone = "696 696 696";
            double money = 123;
            UserType userType = UserType.Premium;

            var mockUserRepository = new Mock<IUserRepository>();

            var userService = new UserService(mockUserRepository.Object);


            //Act
            var userResult = userService.CreateNewUserByType(name, email, address, phone, userType.ToString(), money);


            //Assert
            Assert.IsType<PremiumUser>(userResult);

        }
    }
}
