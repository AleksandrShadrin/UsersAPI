using UsersAPI.Models;

namespace UsersAPI.Repository.UsersRep
{
    public interface IUsersGet
    {
        public IEnumerable<User> GetActiveUsers();
        public User GetUserByLogin(string login);
        public User GetUserByLoginAndPassword(string login, string password);
        public IEnumerable<User> GetUsersByAge(int age);
    }
}
