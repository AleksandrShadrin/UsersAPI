using UsersAPI.Models;

namespace UsersAPI.Repository.UsersRep
{
    public interface IUsersCreate
    {
        //public void CreateUser(string login, string password, string name, int gender, DateTime birthDay, bool isAdmin);
        public User CreateUser(User user, string createdBy);
    }
}
