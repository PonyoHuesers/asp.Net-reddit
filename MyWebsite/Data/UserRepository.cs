using MyWebsite.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;

namespace MyWebsite.Data
{
    public class UserRepository
    {
        public static void AddUsernameToDb(string username, string password)
        {
            using (Context _context = new Context())
            {
                Username userToAddToDb = new Username()
                {
                    Name = username,
                    Password = EncodePassword(password)
                };

                _context.Usernames.Add(userToAddToDb);
                _context.SaveChanges();
            }
        }

        public static Username GetUser(string username)
        {
            using (Context _context = new Context())
            {
                return _context.Usernames.SingleOrDefault(u => u.Name == username);
            }
        }

        //public static bool IsUsernameTaken(string username)
        //{
        //    using (Context _context = new Context())
        //    {
        //        if(_context.Usernames.Any(u => u.Name == username))
        //        {
        //            return true;
        //        }
        //        else
        //        {
        //            return false;
        //        }
        //    }
        //}

        public static byte[] EncodePassword(string password)
        {
            using (Context _context = new Context())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(password);
                SHA1 sha = new SHA1CryptoServiceProvider();
                byte[] encodedPassword = sha.ComputeHash(bytes);

                return encodedPassword;
            }            
        }

        public static bool VerifyPassword(string username, string password)
        {
            using (Context _context = new Context())
            {
                Username userInDb = _context.Usernames.SingleOrDefault(u => u.Name == username);

                byte[] inputPassword = EncodePassword(password);

                if(inputPassword.SequenceEqual(userInDb.Password))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }
    }
}