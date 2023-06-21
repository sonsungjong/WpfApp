using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TacticMVVM.Models
{
    internal class UserManager
    {
        // 데이터베이스가 아닌 하드코딩으로 임시값 셋팅
        public static ObservableCollection<User> _DatabaseUsers = new ObservableCollection<User>()
        {
            new User(){Email="son@naver.com", Name="Son"},
            new User(){Email="sung@gmail.com", Name="Sung"},
            new User(){Email="jong@naver.com", Name="Jong"},
            new User(){Email="choi@gmail.com", Name="choi"},
            new User(){Email="go@naver.com", Name="go"}
        };

        public static ObservableCollection<User> GetUsers()
        {
            return _DatabaseUsers;
        }

        public static void AddUser(User user)
        {
            _DatabaseUsers.Add(user);

        }
    }
}
