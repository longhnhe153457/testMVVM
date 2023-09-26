using AutoMapper.Execution;
using BusinessObject.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DAO
{
    public class UserDAO
    {
        private static Random random = new Random();
        public static List<User> GetUsers()
        {
            var listUsers = new List<User>();
            try
            {
                using (var context = new AS2Context())
                {
                    listUsers = context.Users.Include(x => x.Pub).Include(x => x.Role).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listUsers;
        }

        public static User GetUserById(string id)
        {
            User? user = new();
            try
            {
                using (var context = new AS2Context())
                {
                    user = context.Users.Include(x => x.Pub).Include(x => x.Role).SingleOrDefault(x => x.UserId.Equals(id));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public static User GetUserByEmailAndPassword(string email, string password)
        {
            User? user = new();
            try
            {
                using (var context = new AS2Context())
                {
                    user = context.Users.Include(x => x.Role).SingleOrDefault(x => x.EmailAddress.Equals(email) && x.Password.Equals(password));
                    if(user is not null)
                    {
                        if (user.PubId != "0")
                        {
                            user.Pub = context.Publishers.SingleOrDefault(x => x.PubId == user.PubId);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        public static void SaveUser(User user)
        {
            if (GetUserByEmail(user.EmailAddress) is null)
            {
                user.UserId = GenerateUserId();
                //if id gen exists, gen new id
                while (GetUserById(user.UserId) != null)
                {
                    user.UserId = GenerateUserId();
                }
                try
                {
                    using (var context = new AS2Context())
                    {

                        context.Users.Add(user);
                        context.SaveChanges();
                    }
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }
        public static void UpdateUser(User user)
        {
            try
            {
                using (var context = new AS2Context())
                {
                    context.Entry<User>(user).State
                        = Microsoft.EntityFrameworkCore.EntityState.Modified;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public static void DeleteUser(User user)
        {
            try
            {
                using (var context = new AS2Context())
                {
                    context.Entry<User>(user).State
                        = Microsoft.EntityFrameworkCore.EntityState.Deleted;
                    context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        internal static List<User> GetUsersByPublisherId(string pubId)
        {
            var listUsers = new List<User>();
            try
            {
                using (var context = new AS2Context())
                {
                    listUsers = context.Users.Where(x => x.PubId.Equals(pubId)).ToList();
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return listUsers;
        }

        internal static User GetUserByEmail(string email)
        {
            User? user = new();
            try
            {
                using (var context = new AS2Context())
                {
                    user = context.Users.SingleOrDefault(x => x.EmailAddress.Equals(email));
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
            return user;
        }

        internal static string GenerateUserId()
        {
            const string chars = "abcdefghijklmopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, 10)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
