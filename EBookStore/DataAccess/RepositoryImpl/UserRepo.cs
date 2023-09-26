using BusinessObject.Models;
using DataAccess.DAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.RepositoryImpl
{
    public class UserRepo : IUserRepo
    {
        public User GetMemberByEmailAndPassword(string email, string password) => UserDAO.GetUserByEmailAndPassword(email, password);

        public User GetUserById(string id) => UserDAO.GetUserById(id);

        public List<User> GetUsers() => UserDAO.GetUsers();

        public void SaveUser(User user) => UserDAO.SaveUser(user);

        public void UpdateUser(User user) => UserDAO.UpdateUser(user);

        public void DeleteUser(User user) => UserDAO.DeleteUser(user);

    }
}
