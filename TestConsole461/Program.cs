using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
//using CSharpDll;
//using MetsaKuur;

namespace TestConsole461
{
    public class Program
    {
        static void Main212(string[] args)
        {
            //CSharpDll.ClassLib21 c21 = new CSharpDll.ClassLib21();

            //string result = c21.HelloWorld("hello");
            //Console.WriteLine(result);

            //MetsaKuur.MKAuthenticator ma = new MKAuthenticator();
            //MetsaKuur.MKRegister mr = new MKRegister();

            var assembly = System.Reflection.Assembly.LoadFile("D:\\csharp\\WpfApp1\\TestConsole461\\CSharpDll.dll");
            var targetFramework = assembly.GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), false)
                                           .Cast<System.Runtime.Versioning.TargetFrameworkAttribute>()
                                           .SingleOrDefault();
            if (targetFramework != null)
            {
                Console.WriteLine(targetFramework.FrameworkName);
            }
        }

        static void Main(string[] args)
        {
            Console.WriteLine("Hello World");
            var assembly = System.Reflection.Assembly.LoadFile("D:\\csharp\\WpfApp1\\TestConsole461\\CSharpDll.dll");
            var targetFramework = assembly.GetCustomAttributes(typeof(System.Runtime.Versioning.TargetFrameworkAttribute), false)
                                           .Cast<System.Runtime.Versioning.TargetFrameworkAttribute>()
                                           .SingleOrDefault();
            if (targetFramework != null)
            {
                Console.WriteLine(targetFramework.FrameworkName);
            }
        }
    }
}
