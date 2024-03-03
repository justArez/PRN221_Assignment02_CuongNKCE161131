using BusinessObject;
using DataAccess.Repository.Interface;

namespace DataAccess
{
    public class UserRepo: IUserRepo
    {
        public UserRepo() { }

        private UserDAO userDAO = null;

        private UserDAO _userDAO()
        {
            if (this.userDAO == null)
            {
                this.userDAO = new UserDAO();
            }
            return this.userDAO;
        }

        public void AddUser(User user)
        {
            _userDAO().Add(user);
        }
        public void DeleteUserById(string id)
        {
            _userDAO().Delete(id);
        }

        public User GetUserById(string id)
        {
            return _userDAO().GetById(id);
        }

        public User AuthenticateUser(string username, string password)
        {
            return _userDAO().AuthenticateUser(username, password);
        }

        public async Task<IEnumerable<User>> GetUserList()
        {
            return await _userDAO().GetList();
        }

        public void UpdateUser(User user)
        {
            _userDAO().Update(user);
        }

        public void DeactivateUser(string id)
        {
            _userDAO().DeactivateUser(id);
        }

        public User GetUserByUsername(string username)
        {
            return _userDAO().GetUserByUsername(username);
        }
    }
}
