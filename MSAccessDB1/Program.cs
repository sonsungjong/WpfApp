using System;
using System.Data.OleDb;            // NuGet 패키지 관리자에서 설치
using System.Reflection;

namespace MSAccess
{
    public class MSDB
    {
        private List<string> id = new List<string>();
        private List<string> password = new List<string>();
        private List<string> name = new List<string>();

        public static void Main()
        {
            string dll_path = @"D:\csharp\WpfApp1\MSAccessDB1\DbLib.dll";
            Assembly assembly = Assembly.LoadFile(dll_path);
            Type type = assembly.GetType("DbLib.DbUse");
            object db_lib = Activator.CreateInstance(type);

            MSDB db_access = new MSDB();
            type.GetMethod("UserSelectAll").Invoke(db_lib, new object[] { db_access.id, db_access.password, db_access.name });           // 메서드 호출
            //db_access.QueryAccessDatabase(db_access.id, db_access.password, db_access.name);

            // 테스트용 코드
            Console.WriteLine("IDs:");
            foreach (string element in db_access.id)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nPasswords:");
            foreach (string element in db_access.password)
            {
                Console.WriteLine(element);
            }

            Console.WriteLine("\nNames:");
            foreach (string element in db_access.name)
            {
                Console.WriteLine(element);
            }

        }

        public void QueryAccessDatabase(List<string> _id, List<string> _password, List<string> _name)
        {
            // 데이터베이스 파일의 경로 지정
            string db_path = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=C:\Users\sungjong.son\Documents\test.accdb;";

            // OleDb 객체를 생성하고 연결
            using (OleDbConnection conn = new OleDbConnection(db_path))
            {
                conn.Open();

                // 쿼리 정의
                string query = "SELECT * FROM [user]";

                // OleDbCommand 객체를 생성하고 쿼리 설정
                using (OleDbCommand cmd = new OleDbCommand(query, conn))
                {
                    // OleDBDataReader를 사용하여 쿼리 결과를 얻는다
                    using(OleDbDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            _id.Add(reader.GetString(0));
                            _password.Add(reader.GetString(1));
                            _name.Add(reader.GetString(2));
                        }
                    }
                }
            }
        }
    }
}