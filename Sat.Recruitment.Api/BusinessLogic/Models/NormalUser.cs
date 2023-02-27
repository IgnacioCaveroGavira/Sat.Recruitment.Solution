namespace Sat.Recruitment.Api.BusinessLogic.Models
{
    public class NormalUser : UserAbstract, IUser
    {
        private static readonly double UPPER_100_PERSENTAGE = 0.12;
        private static readonly double BEWTEEN_10_AND_100 = 0.8;

        public NormalUser(string name, string email, string address, string phone, double money, bool isNewUser = false)
        {
            Name = name;
            Email = email;
            Address = address;
            Phone = phone;
            Type = UserType.Normal;
            Money = money;

            if (isNewUser)
            {
                if (Money > 100)
                {
                    Money = AddPercentage(UPPER_100_PERSENTAGE);
                }
                if (Money > 10 && Money < 100)
                {
                    Money = AddPercentage(BEWTEEN_10_AND_100);
                }
            }
        }      
    }
}
