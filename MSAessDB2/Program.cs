using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.Data.SqlTypes;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MSAessDB2
{
    public class MSDB
    {
        private List<string> id = new List<string>();
        private List<string> password = new List<string>();
        private List<string> name = new List<string>();

        static void Main(string[] args)
        {
            MSDB db_access = new MSDB();
            db_access.UserSelectAll(db_access.id, db_access.password, db_access.name);

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

        public void UserSelectAll(List<string> _id, List<string> _password, List<string> _name)
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
                    using (OleDbDataReader reader = cmd.ExecuteReader())
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
