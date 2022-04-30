using UsersAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace UsersAPI.Repository.UsersRep
{
    public class UsersRepository : IUsersRepository
    {
        List<ValidationResult> _results;
        ValidationContext _context;
        UsersDbContext _dbContext;
        public UsersRepository(UsersDbContext dbContext)
        {
            _dbContext = dbContext;
            _results = new List<ValidationResult>();
        }
        public User CreateUser(User user, string createdBy)
        {
            var potentialUser = GetUserByLogin(user.Login);
            if (potentialUser != null)
                return default;
            if (validateObject(user))
            {
                user.CreatedOn = DateTime.Now;
                user.CreatedBy = createdBy;
                _dbContext.Users.Add(user);
                _dbContext.SaveChanges();
                return user;
            }
            return default;
        }

        public IEnumerable<User> GetActiveUsers()
        {
            return _dbContext.Users.Where(user =>
                String.IsNullOrEmpty(user.RevokedBy)
                && user.RevokedOn == null).ToList();
        }

        public IEnumerable<User> GetUsersByAge(int age)
        {
            return _dbContext.Users.Where((user) =>
                user.Birthday.HasValue ?
                user.Birthday.Value.AddYears(age) < DateTime.Now
                : false).ToList();
        }

        public User GetUserByLogin(string login)
        {
            return _dbContext.Users.Where((user) =>
                user.Login == login)
                .FirstOrDefault();
        }

        public User GetUserByLoginAndPassword(string login, string password)
        {
            return _dbContext.Users.Where((user) =>
                user.Login == login
                && user.Password == password)
                .FirstOrDefault();
        }

        public void HardDeleteUser(User user)
        {
            if (user == default)
                return;
            _dbContext.Users.Remove(user);
            _dbContext.SaveChanges();
        }

        public void RecoverUser(User user)
        {
            if (user == default)
                return;
            user.RevokedBy = null;
            user.RevokedOn = null;
            _dbContext.SaveChanges();
        }

        public void SoftDeleteUser(User user, string revokerName)
        {
            if (user == default)
                return;
            user.RevokedBy = revokerName;
            user.RevokedOn = DateTime.Now;
            _dbContext.SaveChanges();
        }

        public void UpdateUserLogin(User user, string newLogin, string modifiedBy)
        {
            var potentialUser = GetUserByLogin(newLogin);
            if (user == default || potentialUser != default)
                return;
            var savedLogin = user.Login;
            user.Login = newLogin;
            if (validateObject(user))
            {
                user.ModifiedBy = modifiedBy;
                user.ModifiedOn = DateTime.Now;
                _dbContext.SaveChanges();
                return;
            }
            user.Login = savedLogin;
        }

        public void UpdateUserPassword(User user, string newPassword, string modifiedBy)
        {
            if (user == default)
                return;
            var savedPassword = user.Password;
            user.Password = newPassword;
            if (validateObject(user))
            {
                user.ModifiedBy = modifiedBy;
                user.ModifiedOn = DateTime.Now;
                _dbContext.SaveChanges();
                return;
            }
            user.Password = savedPassword;
        }

        public void UpdateUserProps(User user, UserProps props, string modifiedBy)
        {
            if (validateObject(props))
            {
                user.Name = props.Name == default ? user.Name : props.Name;
                user.Gender = !props.Gender.HasValue ? user.Gender : props.Gender.Value;
                user.Birthday = (props.Birthday == null || props.Birthday == default) ? user.Birthday : props.Birthday;
                user.ModifiedBy = modifiedBy;
                user.ModifiedOn = DateTime.Now;
                _dbContext.SaveChanges();
            }
        }
        private bool validateObject<Type>(Type obj)
        {
            _context = new(obj);
            _results = new();
            return Validator.TryValidateObject(obj, _context, _results, true);
        }
    }
}
