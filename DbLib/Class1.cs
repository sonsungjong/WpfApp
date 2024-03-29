﻿using System.Data.OleDb;

namespace DbLib
{
    public class DbUse
    {
        public void Print()
        {
            Console.WriteLine("Hello DbLie");
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