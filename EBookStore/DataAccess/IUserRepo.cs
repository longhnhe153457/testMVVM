using AutoMapper.Execution;
using BusinessObject.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public interface IUserRepo
    {
        User GetUserById(string id);
        User GetMemberByEmailAndPassword(string email, string password);
        List<User> GetUsers();
        void SaveUser(User user);
        void UpdateUser(User user);
        void DeleteUser(User user);
    }
}
