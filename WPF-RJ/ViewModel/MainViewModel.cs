using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using WPF_RJ.Model;
using WPF_RJ.Repositories;

namespace WPF_RJ.ViewModel
{
    public class MainViewModel : ViewModelBase
    {
        // 멤버변수
        private UserAccountModel _currentUserAccount;
        private IUserRepository userRepository;

        public UserAccountModel CurrentUserAccount
        {
            get { return _currentUserAccount; }
            set 
            {
                _currentUserAccount = value;
                OnPropertyChanged(nameof(CurrentUserAccount));
            }
        }

        public MainViewModel()
        {
            userRepository = new UserRepository();
            CurrentUserAccount = new UserAccountModel();
            LoadCurrentUserData();
        }

        private void LoadCurrentUserData()
        {
            var user = userRepository.GetByUsername(Thread.CurrentPrincipal.Identity.Name);
            if(user != null)
            {

                CurrentUserAccount.Username = user.Username;
                CurrentUserAccount.DisplayName = $"Welcome {user.Name} {user.LastName} ;)";
                CurrentUserAccount.ProfilePicture = null;
                
            }
            else
            {
                CurrentUserAccount.DisplayName = "Invalid user, not logged in";
                // Hide child views.
            }
        }
    }
}
