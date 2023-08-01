using System;
using System.IO;
using LogLib;

namespace FileLogTest
{
    public class MyFileLog
    {
        public static void Main()
        {
            // 메시지 송수신 전에 해당 문자열을 기록
            string message = "show me the money";

            // message를 C:\\log\\mylog.txt
            FileLog fl = new FileLog();
            fl.Log(message, "dll_log");

            // 사용하기 전까지 message를 신뢰할 수 없다
            Console.WriteLine(message);
        }

        public void Log(string message)
        {
            string path = "C:\\log\\mylog.txt";
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int len = message.Length;
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            File.AppendAllText(path, datetime + ">>" + message + "[" + len + "]\n");
        }

        public void Log(string message, string filename)
        {
            string path = "C:\\log\\"+filename+".txt";
            string datetime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            int len = message.Length;
            string directory = Path.GetDirectoryName(path);
            if (!Directory.Exists(directory))
            {
                Directory.CreateDirectory(directory);
            }
            File.AppendAllText(path, datetime + ">>" + message + "[" + len + "]\n");
        }
    }
}