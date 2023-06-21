using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using TacticMVVM.Commands;
using TacticMVVM.Models;
using TacticMVVM.Views;

namespace TacticMVVM.ViewModel
{
    public class MainViewModel
    {
        public ObservableCollection<User> Users { get; set; }

        public ICommand ShowWindowCommand { get; set; }

        // 생성자
        public MainViewModel()
        {
            Users = UserManager.GetUsers();

            ShowWindowCommand = new RelayCommand(ShowWindow, CanShowWindow);
        }

        private bool CanShowWindow(object obj)
        {
            return true;
        }

        private void ShowWindow(object obj)
        {
            var main_window = obj as Window;

            AddUser addUserWin = new AddUser();
            addUserWin.Owner = main_window;
            addUserWin.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            addUserWin.Show();
        }
    }
}
