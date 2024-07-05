using Domain.Enuns;
using Domain.Models.Abstract;
using Domain.Models.AssotiativeEntities;

namespace Domain.Models
{
    public class User : Entity
    {
        public string Name { get; set; }=string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public Role Role { get; set; } = Role.Customer;
        public string PicturePath { get; set; } = string.Empty;

        public List<Enrollment> UserQuizzes { get; set; }
    }
}
