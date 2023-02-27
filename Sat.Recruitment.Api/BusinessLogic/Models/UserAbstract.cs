namespace Sat.Recruitment.Api.BusinessLogic.Models
{
    public abstract class UserAbstract
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public UserType Type { get; set; }
        public double Money { get; set; }

        internal double AddPercentage(double percentage)
        {
            return Money + (Money * percentage);
        }
    }
}
