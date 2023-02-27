
namespace Sat.Recruitment.Api.BusinessLogic.Models
{
    public interface IUser
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType Type { get; set; }
        public double Money { get; set; }
    }
}
