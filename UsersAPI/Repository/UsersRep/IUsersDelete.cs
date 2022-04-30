using UsersAPI.Models;

namespace UsersAPI.Repository.UsersRep
{
    public interface IUsersDelete
    {
        public void SoftDeleteUser(User user, string revokerName);
        public void HardDeleteUser(User user);
        public void RecoverUser(User user);
    }
}
