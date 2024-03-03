using BusinessObject;
using DataAccess;

namespace BusinessService
{
    public class UserService: IUserService
    {
        public UserService() { }

        private UserRepo userRepo = null;

        private UserRepo _userRepo()
        {
            if (this.userRepo == null)
            {
                this.userRepo = new UserRepo();
            }
            return this.userRepo;
        }

        public void AddUser(User user)
        {
            _userRepo().AddUser(user);
        }

        public void DeleteUserById(string id)
        {
            _userRepo().DeleteUserById(id);
        }

        public User GetUserById(string id)
        {
            return _userRepo().GetUserById(id);
        }

        public User AuthenticateUser(string username, string password)
        {
            return _userRepo().AuthenticateUser(username, password);
        }

        public async Task<IEnumerable<User>> GetUserList()
        {
            return await _userRepo().GetUserList();
        }
        public void UpdateUser(User user)
        {
            _userRepo().UpdateUser(user);
        }

        public void DeactivateUser(string id)
        {
            _userRepo().DeactivateUser(id);
        }

        public User GetUserByUsername(string username)
        {
            return _userRepo().GetUserByUsername(username);
        }
    }
}
