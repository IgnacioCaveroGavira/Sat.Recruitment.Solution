namespace Sat.Recruitment.Api.BusinessLogic.Models
{
    public class SuperUser : UserAbstract, IUser
    {
        private static readonly double UPPER_100_PERSENTAGE = 0.2;

        public SuperUser(string name, string email, string address, string phone, double money, bool isNewUser = false)
        {
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            Type = UserType.Super;
            Money = money;

            if (isNewUser && Money > 100)
            {
                Money = AddPercentage(UPPER_100_PERSENTAGE);
            }
        }
    }
}
