using BCSsolution.dbManager;
using BCSsolution.onStart.model;
using NHibernate.Linq;
using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;

namespace BCSsolution.onStart.viewmodel
{
    public class UserRepository : Repository<User>
    {
        public UserRepository() : base() { }

        public User AuthenticateUser(string username, string clearTextPassword)
        {
            var temp = this.FindAll().FirstOrDefault(u => u.UserName.Equals(username) && u.HashedPassword.Equals(clearTextPassword));
            return temp;
        }

        public static string CalculateHash(string clearTextPassword, string salt)
        {
            // Convert the salted password to a byte array
            byte[] saltedHashBytes = Encoding.UTF8.GetBytes(clearTextPassword + salt);
            // Use the hash algorithm to calculate the hash
            HashAlgorithm algorithm = new SHA256Managed();
            byte[] hash = algorithm.ComputeHash(saltedHashBytes);
            // Return the hash as a base64 encoded string to be compared to the stored password
            return Convert.ToBase64String(hash);
        }
    }
}