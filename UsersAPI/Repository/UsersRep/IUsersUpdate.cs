using System.ComponentModel.DataAnnotations;
using UsersAPI.Models;

namespace UsersAPI.Repository.UsersRep
{
    public interface IUsersUpdate
    {
        public void UpdateUserProps(User user,UserProps props, string modifiedBy);
        public void UpdateUserPassword(User user, string newPassword, string modifiedBy);
        public void UpdateUserLogin(User user, string newLogin, string modifiedBy);
    }
    public class UserProps
    {
        [RegularExpression(@"^[a-zA-Z]+$")]
        public string? Name { get; set; }
        public int? Gender { get; set; }
        public DateTime? Birthday { get; set; }
    }
}
