using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace WPF_RJ.Repositories
{
    public abstract class RepositoryBase
    {
        private readonly string _connectionString;
        public RepositoryBase()
        {
            // 로컬 데이터베이스 서버에 연결
            //_connectionString = "Server=localhost; Database=MVVMLoginDb; Integrated Security=true;";
            _connectionString = "Server=127.0.0.1; Database=MVVMLoginDb; User Id=root; Password=root;";

        }
        protected SqlConnection GetConnection()
        {
            return new SqlConnection(_connectionString);
        }
    }
}
