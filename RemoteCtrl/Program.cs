using System;
using System.Diagnostics;
using System.Runtime.InteropServices;

namespace RemoteCtrl
{
    public class RemoteCtrl
    {
        public static void Main()
        {
            RemoteCtrl remote = new RemoteCtrl();
            //remote.PowerOff();
            //remote.RunExe("C:\\exe\\WPF-RJ.exe");
            //remote.KillProcess("WPF-RJ");

            remote.GetTime();
            //remote.ModifyTime();
        }

        /*
            컴퓨터 전원을 종료시키는 메서드
        */
        public void PowerOff()
        {
            Process.Start("shutdown", "/s /t 10");              // 10초후에 종료한다
        }

        /*
            프로그램을 실행시키는 메서드 
        */
        public void RunExe(string filepath)
        {
            Process.Start(filepath);                // exe파일의 경로를 받아 실행시킨다
        }

        /*
             프로세스를 종료시키는 메서드
        */
        public void KillProcess(string process_name)
        {
            Process[] processes = Process.GetProcessesByName(process_name);
            foreach (Process process in processes)
            {
                process.Kill();
            }
        }

        // UTC 기준
        [StructLayout(LayoutKind.Sequential)]
        public struct SYSTEMTIME
        {
            public ushort wYear;
            public ushort wMonth;
            public ushort wDayOfWeek;
            public ushort wDay;
            public ushort wHour;
            public ushort wMinute;
            public ushort wSecond;
            public ushort wMilliseconds;
        }

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool SetSystemTime(ref SYSTEMTIME st);

        [DllImport("kernel32.dll", SetLastError = true)]
        public static extern bool GetSystemTime(ref SYSTEMTIME st);

        public void ModifyTime()
        {
            SYSTEMTIME st = new SYSTEMTIME();
            st.wYear = 2023;
            st.wMonth = 7;
            st.wDay = 24;
            st.wHour = 10 +3;
            st.wMinute = 51;
            st.wSecond = 0;

            SetSystemTime(ref st);
        }


        // UTC 시간을 얻는다
        public void GetTime()
        {
            //SYSTEMTIME st = new SYSTEMTIME();
            //GetSystemTime(ref st);

            // YYYY-MM-DD HH:mm:SS
            // 한국시간이기 때문에 +9
            //string time = string.Format("{0:D4}-{1:D2}-{2:D2} {3:D2}:{4:D2}:{5:D2}", st.wYear, st.wMonth, st.wDay, (st.wHour + 9) % 24, st.wMinute, st.wSecond);
            string time = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            // 출력
            Console.WriteLine(time);
        }
    }
}