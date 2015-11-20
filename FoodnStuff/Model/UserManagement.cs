using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using FoodnStuff.Model;


namespace FoodnStuff.Model
{
    public class UserManagement
    {

        public string getData(string field, string id)
        {
            string data = "";
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM UserTable Where ID=" + id + "";
            var reader = myDatabase.ExcuteQuery(command);
            reader.Read();
            if (reader.HasRows == true)
            {
                data = reader[field].ToString();
            }
            return data;
        }

        public bool CheckForUname(string uname)
        {
            bool contain = false;
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM UserTable Where UserName='" + uname + "'";
            var reader = myDatabase.ExcuteQuery(command);
            reader.Read();
            if (reader.HasRows == true)
            {
                contain = true;
            }
            return contain;
        }

        public bool CheckForEmail(string email)
        {
            bool contain = false;
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM UserTable Where Email='" + email + "'";
            var reader = myDatabase.ExcuteQuery(command);
            reader.Read();
            if (reader.HasRows == true)
            {
                contain = true;
            }
            return contain;
        }

        public string Login(string inputUserName, string inputPassWord)
        {
            Database myDatabase = new Database();
            string id = "0";
            myDatabase.ReturnConnection();
            string command = "SELECT * FROM UserTable Where UserName='" + inputUserName + "'";
            var reader = myDatabase.ExcuteQuery(command);
            reader.Read();
            if (reader.HasRows == true)
            {
                string name = reader["Name"].ToString();
                string hashedPass = reader["Pass"].ToString();

                if (PasswordHash.ValidatePassword(inputPassWord, hashedPass) == true)
                {
                    id = reader["ID"].ToString();
                }
            }
            return id;

        }

        public void Register(string UserName, string Name, string Email, string PassWord)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string Alreadypassword = PasswordHash.CreateHash(PassWord);
            string command = "INSERT INTO UserTable (Name,UserName,Email,Pass,RoleID) VALUES ('" + Name + "','" + UserName + "','" + Email + "','" + Alreadypassword + "','2');";
            myDatabase.ExcuteNonQuery(command);
            myDatabase.CloseConnection();
            StorageManagement.CreateStorage(UserName);
        }
               public void EditProfile(string id, string Name, string UserName, string Email, string PassWord)
        {
            Database myDatabase = new Database();
            myDatabase.ReturnConnection();
            string command;
            if (PassWord == "")
            {
                command = "UPDATE UserTable SET Name='" + Name + "',UserName='" + UserName + "',Email='" + Email + "' WHERE ID =" + id + ";";

            }
            else
            {
                string Alreadypassword = PasswordHash.CreateHash(PassWord);
                command = "UPDATE UserTable SET Name='" + Name + "',UserName='" + UserName + "',Email='" + Email + "',Pass='" + Alreadypassword + "' WHERE ID =" + id + ";";

            }
            myDatabase.ExcuteNonQuery(command);
        }
        public List<User> GetUser()
        {
            List<User> userList = new List<User>();
            return userList;
        }
    }

    //Business Object
    public class User
    {
        public string Name { get; set; }
        public PasswordHash PassWord { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
    }

    public class PasswordHash
    {
        // The following constants may be changed without breaking existing hashes.
        public const int SALT_BYTE_SIZE = 24;
        public const int HASH_BYTE_SIZE = 24;
        public const int PBKDF2_ITERATIONS = 1000;

        public const int ITERATION_INDEX = 0;
        public const int SALT_INDEX = 1;
        public const int PBKDF2_INDEX = 2;

        /// <summary>
        /// Creates a salted PBKDF2 hash of the password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <returns>The hash of the password.</returns>
        public static string CreateHash(string password)
        {
            // Generate a random salt
            RNGCryptoServiceProvider csprng = new RNGCryptoServiceProvider();
            byte[] salt = new byte[SALT_BYTE_SIZE];
            csprng.GetBytes(salt);

            // Hash the password and encode the parameters
            byte[] hash = PBKDF2(password, salt, PBKDF2_ITERATIONS, HASH_BYTE_SIZE);
            return PBKDF2_ITERATIONS + ":" +
                Convert.ToBase64String(salt) + ":" +
                Convert.ToBase64String(hash);
        }

        /// <summary>
        /// Validates a password given a hash of the correct one.
        /// </summary>
        /// <param name="password">The password to check.</param>
        /// <param name="correctHash">A hash of the correct password.</param>
        /// <returns>True if the password is correct. False otherwise.</returns>
        public static bool ValidatePassword(string password, string correctHash)
        {
            // Extract the parameters from the hash
            char[] delimiter = { ':' };
            string[] split = correctHash.Split(delimiter);
            int iterations = Int32.Parse(split[ITERATION_INDEX]);
            byte[] salt = Convert.FromBase64String(split[SALT_INDEX]);
            byte[] hash = Convert.FromBase64String(split[PBKDF2_INDEX]);

            byte[] testHash = PBKDF2(password, salt, iterations, hash.Length);
            return SlowEquals(hash, testHash);
        }
        /// <summary>
        /// Compares two byte arrays in length-constant time. This comparison
        /// method is used so that password hashes cannot be extracted from
        /// on-line systems using a timing attack and then attacked off-line.
        /// </summary>
        /// <param name="a">The first byte array.</param>
        /// <param name="b">The second byte array.</param>
        /// <returns>True if both byte arrays are equal. False otherwise.</returns>
        private static bool SlowEquals(byte[] a, byte[] b)
        {
            uint diff = (uint)a.Length ^ (uint)b.Length;
            for (int i = 0; i < a.Length && i < b.Length; i++)
                diff |= (uint)(a[i] ^ b[i]);
            return diff == 0;
        }

        /// <summary>
        /// Computes the PBKDF2-SHA1 hash of a password.
        /// </summary>
        /// <param name="password">The password to hash.</param>
        /// <param name="salt">The salt.</param>
        /// <param name="iterations">The PBKDF2 iteration count.</param>
        /// <param name="outputBytes">The length of the hash to generate, in bytes.</param>
        /// <returns>A hash of the password.</returns>
        private static byte[] PBKDF2(string password, byte[] salt, int iterations, int outputBytes)
        {
            Rfc2898DeriveBytes pbkdf2 = new Rfc2898DeriveBytes(password, salt);
            pbkdf2.IterationCount = iterations;
            return pbkdf2.GetBytes(outputBytes);
        }
    }
}