using System.ComponentModel.DataAnnotations;

namespace UsersTest.Models
{
    public class UserModel
    {
        public string ID { get; set; }
        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 2)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }
    }
}
