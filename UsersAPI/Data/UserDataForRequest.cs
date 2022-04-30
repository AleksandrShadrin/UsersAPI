using System.ComponentModel.DataAnnotations;
using UsersAPI.Models;

namespace UsersAPI.Data
{
    public class UserDataForRequest
    {
        [Required]
        [RegularExpression(@"^[a-zA-Z\d]+$")]
        public string Login { get; set; }
        [Required]
        [RegularExpression(@"^[a-zA-Z\d]+$")]
        public string Password { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public int Gender { get; set; }
        public DateTime? Birthday { get; set; }
        public bool Admin { get; set; }
    }
    public static class UserDataForRequestExtensionmethods
    {
        public static User UserFromUserDataForRequest(this UserDataForRequest udfr) =>
            new User()
            {
                Admin = udfr.Admin,
                Birthday = udfr.Birthday,
                Name = udfr.Name,
                Gender = udfr.Gender,
                Login = udfr.Login,
                Password = udfr.Password,
            };
    }
}
