
using Sat.Recruitment.Api.BusinessLogic.Models;
using Xunit;

namespace Sat.Recruitment.Test
{
    public class NormalUserTest
    {
        [Fact]
        public void newNormalUser_WithUp100Money_CreatedNormalUserWithPersentage()
        {
            // Arrange
            double money = 200;

            // Act
            NormalUser user = new NormalUser("NameTest", "email@test.com", "AddressTest", "696 696 696", money, isNewUser: true);

            // Asserts
            Assert.Equal(user.Money, money + (money * 0.12));
        }
    }
}
