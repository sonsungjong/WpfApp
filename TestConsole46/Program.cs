using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetsaKuur;

namespace TestConsole46
{
    public class Program
    {
        static void Main(string[] args)
        {
            MKAuthenticator mkAuthenticator = new MKAuthenticator();
        }




        //static void MKAuth()
        //{
        //    MKAuthenticator mkAuthenticator = new MKAuthenticator();
        //    mkAuthenticator.TopMost = true;
        //
        //    if (!mkAuthenticator.IsCamOpened())
        //    {
        //        Console.WriteLine("throw Init Device Failed");
        //    }
        //
        //    if (!mkAuthenticator.StartCapture(10000))
        //    {
        //        Console.WriteLine("throw Start Capture Failed");
        //    }
        //}

        //static void MKRegi()
        //{
        //    MKRegister mkRegister = new MKRegister();
        //    mkRegister.TopMost = true;
        //    if (!mkRegister.IsCamOpened())
        //    {
        //        Console.WriteLine("throw StartFailed");
        //    }
        //
        //    if (!mkRegister.StartCapture(10000))
        //    {
        //        Console.WriteLine("throw CaptureFailed");
        //    }
        //
        //    
        //}
    }
}
