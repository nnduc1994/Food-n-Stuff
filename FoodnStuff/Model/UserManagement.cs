using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FoodnStuff.Model
{
    public class UserManagement
    {
        public void Register(string inputUserName, string inputPassWord) { }
        public void Login(string Name, string UserName, string Email, string PassWord) { }
        public void EditProfile() { }
        public List<User> GetUser() {
            List<User> userList = new List<User>();
            return userList;
        }
    }

    //Business Object
    public class User
    {
        public string Name { get; set; }
        public string PassWord { get; set; }
        public int UserId { get; set; }
        public string Email { get; set; }
    }
}