using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UITCC.Model
{
    public class UserModel
    {
        public string UserId { get; set; }
        public string UserPw { get; set; }
        public string UserName { get; set; }

        // 로그인한 사용자 정보 유지를 위해 싱글턴으로 관리
        private static UserModel m_instance;
        public static UserModel Instance => m_instance ?? (m_instance = new UserModel());

        private UserModel() { }
    }
}
