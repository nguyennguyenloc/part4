using part4.core;
using part4.data.DAL;
using part4.data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace part4.service
{
    public class UserService
    {
        public User LoginByCredential(string username, string password)
        {
            UserDAL userDAL = new UserDAL();

            if (String.IsNullOrEmpty(username) || String.IsNullOrEmpty(password))
            {
                return null;
            }

            var user = userDAL.GetByUsername(username);
            if (user == null)
            {
                return null;
            }

            var passwordSalt = user.PasswordSalt;
            var passwordEncrypt = PasswordHash.EncryptionPasswordWithSalt(password, passwordSalt);
            if (passwordEncrypt == user.PasswordEncrypted)
            {
                return user;
            }
            else
            {
                return null;
            }

        }
    }

}
