using BusinessObject;

namespace DataAccess
{
    public class UserDAO
    {
        private static UserDAO instance = null;
        private static readonly object instanceLock = new object();
        public static UserDAO Instance
        {
            get
            {
                lock (instanceLock)
                {
                    if (instance == null)
                    {
                        instance = new UserDAO();
                    }
                }
                return instance;
            }
        }

        public async Task<IEnumerable<User>> GetList()
        {
            var members = new List<User>();
            try
            {
                using var context = new CarSaleManagementDbContext();
                members = context.Users.ToList();
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return members;
        }

        public User GetById(string userId)
        {
            User user = null;
            try
            {
                using var context = new CarSaleManagementDbContext();
                user = context.Users.SingleOrDefault(c => c.Userid == userId);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public User AuthenticateUser(string username, string password)
        {
            User user = null;
            try
            {
                using var context = new CarSaleManagementDbContext();
                user = context.Users.SingleOrDefault(u => u.Username == username);
                if (user != null){
                    user = user.Password.Equals(password) ? user : new User();
                }
                return user;
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public User GetUserByUsername(string username)
        {
            User user = null;
            try
            {
                using var context = new CarSaleManagementDbContext();
                user = context.Users.SingleOrDefault(u => u.Username == username);
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
            return user;
        }

        public void Add(User user)
        {
            try
            {
                User _user = GetById(user.Userid);
                if (_user == null)
                {
                    using var context = new CarSaleManagementDbContext();
                    context.Users.Add(user);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The User is already exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Update(User user)
        {
            try
            {
                User _user = GetById(user.Userid);
                if (_user != null)
                {
                    using var context = new CarSaleManagementDbContext();
                    context.Users.Update(user);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The User does not exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void DeactivateUser(string id)
        {
            try
            {
                User _user = GetById(id);
                if (_user != null)
                {
                    using var context = new CarSaleManagementDbContext();
                    _user.IsActive = false;
                    context.Users.Update(_user);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The User does not exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }

        public void Delete(string userId)
        {
            try
            {
                User _mem = GetById(userId);
                if (_mem != null)
                {
                    using var context = new CarSaleManagementDbContext();
                    context.Users.Remove(_mem);
                    context.SaveChanges();
                }
                else
                {
                    throw new Exception("The User does not exist.");
                }
            }
            catch (Exception e)
            {
                throw new Exception(e.Message);
            }
        }
    }
}
