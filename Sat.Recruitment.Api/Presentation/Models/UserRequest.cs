using Sat.Recruitment.Api.BusinessLogic.Models;
using System.ComponentModel.DataAnnotations;

namespace Sat.Recruitment.Api.Presentation.Models
{
    public class UserRequest
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string UserType { get; set; }
        public double Money { get; set; }
    }
}
