using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CsClassLib;

namespace TestConsole46
{
    public class Program
    {
        static void Main(string[] args)
        {
            MyDll dll = new MyDll();
            string str = dll.Func1("hello world");
            Console.WriteLine(str);
            dll.Func2();
        }
    }
}
