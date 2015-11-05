using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FoodnStuff;
using System.Reflection;

namespace TestApplication
{
    class Program
    {
        static void Main(string[] args)
        {
            string a = System.IO.Path.GetDirectoryName(Assembly.GetEntryAssembly().Location).Replace("\\bin\\Debug","");
            Console.WriteLine(a);
            Console.ReadLine();
        }
    }
}
