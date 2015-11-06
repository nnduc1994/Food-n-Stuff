using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodnStuff;
using System.Reflection;
using FoodnStuff.Model;
namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            //string a = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Replace("\\bin\\Debug","");
            string Alreadypassword = PasswordHash.CreateHash("Hello this is a test");
            bool check = PasswordHash.ValidatePassword("Hello this is a test",Alreadypassword);
            Console.WriteLine(check);
            Console.ReadLine();
        }
    }
}
