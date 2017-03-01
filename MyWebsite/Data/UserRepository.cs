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
        public static void EncodePassword(Username username)
        {
            using (Context _context = new Context())
            {
                byte[] bytes = System.Text.Encoding.UTF8.GetBytes(username.Password);
                SHA1 sha = new SHA1CryptoServiceProvider();
                byte[] password = sha.ComputeHash(bytes);

                username.EncodedPassword = password;

                _context.Usernames.Add(username);
                _context.SaveChanges();
            }            
        }
    }
}