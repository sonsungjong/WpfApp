using LeftMenuDashBoard7.Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Input;

namespace LeftMenuDashBoard7.ViewModel
{
    public class NavigationViewModel : ViewModelBase
    {
        // 멤버변수
        private string m_filter_text;
        private object m_selected_view_model;
        private CollectionViewSource m_menu_items_collection;


        // 생성자
        public NavigationViewModel()
        {
            ObservableCollection<MenuItems> menu_items = new ObservableCollection<MenuItems>
            {
                new MenuItems {MenuName = "Home", MenuImage=@"../Images/Home_Icon.png"},
                new MenuItems {MenuName = "Desktop", MenuImage=@"../Images/Desktop_Icon.png"},
                new MenuItems {MenuName = "Documents", MenuImage=@"../Images/Document_Icon.png"},
                new MenuItems {MenuName = "Downloads", MenuImage=@"../Images/Download_Icon.png"},
                new MenuItems {MenuName = "Pictures", MenuImage=@"../Images/Images_Icon.png"},
                new MenuItems {MenuName = "Music", MenuImage=@"../Images/Music_Icon.png"},
                new MenuItems {MenuName = "Movies", MenuImage=@"../Images/Movies_Icon.png"},
                new MenuItems {MenuName = "Trash", MenuImage=@"../Images/Trash_Icon.png"},
            };

            m_menu_items_collection = new CollectionViewSource { Source = menu_items };
            m_menu_items_collection.Filter += MenuItems_Filter;

            //m_selected_view_model = new StartupViewModel();
        }

        // 커맨드
        private ICommand m_menu_command;
        private ICommand m_pc_command;
        private ICommand m_back_home_command;
        private ICommand m_close_command;

/*        public ICommand MenuCommand
        {
            get
            {
                if(m_menu_command == null)
                {
                    m_menu_command = new ViewModelCommand(p => SwitchViews(p));
                }
                return m_menu_command;
            }
        }
        public ICommand ThisPCCommand
        {
            get
            {
                if(m_pc_command == null)
                {
                    m_pc_command = new ViewModelCommand(p => PCView());
                }
                return m_pc_command;
            }
        }
        public ICommand BackHomeCommand
        {
            get
            {
                if(m_back_home_command == null)
                {
                    m_back_home_command = new ViewModelCommand(p => ShowHome());
                }
                return m_back_home_command;
            }
        }
        public ICommand CloseAppCommand
        {
            get
            {
                if(m_close_command == null)
                {
                    m_close_command = new ViewModelCommand(p => CloseApp(p));
                }
                return m_close_command;
            }
        }*/

        // 프로퍼티
        public string FilterText
        {
            get => m_filter_text;
            set
            {
                m_filter_text = value;
                m_menu_items_collection.View.Refresh();
                OnPropertyChanged("FilterText");
            }
        }
        public object SelectedViewModel
        {
            get => m_selected_view_model;
            set
            {
                m_selected_view_model = value;
                OnPropertyChanged("SelectedViewModel");
            }
        }

        // 메서드
        public ICollectionView SourceCollection => m_menu_items_collection.View;
        private void MenuItems_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(m_filter_text))
            {
                e.Accepted = true;
                return;
            }
            MenuItems _item = e.Item as MenuItems;
            if (_item.MenuName.ToUpper().Contains(FilterText.ToUpper()))
            {
                e.Accepted = true;
            }
            else
            {
                e.Accepted = false;
            }
        }
/*        public void PCView()
        {
            SelectedViewModel = new PCViewModel();
        }
        private void ShowHome()
        {
            SelectedViewModel = new HomeViewModel();
        }*/
        //public void CloseApp(object obj)
        //{
        //    MainViewModel win = obj as MainWindow;
        //    win.Close();
        //}
/*        public void SwitchViews(object a_parameter)
        {
            switch (a_parameter)
            {
                case "Home":
                    SelectedViewModel = new HomeViewModel();
                    break;
                case "Desktop":
                    SelectedViewModel = new DesktopViewModel();
                    break;
                case "Documents":
                    SelectedViewModel = new DocumentViewModel();
                    break;
                case "Downloads":
                    SelectedViewModel = new DownloadViewModel();
                    break;
                case "Pictures":
                    SelectedViewModel = new PictureViewModel();
                    break;
                case "Music":
                    SelectedViewModel = new MusicViewModel();
                    break;
                case "Movies":
                    SelectedViewModel = new MovieViewModel();
                    break;
                case "Trash":
                    SelectedViewModel = new TrashViewModel();
                    break;
                default:
                    SelectedViewModel = new HomeViewModel();
                    break;
            }
        }*/
    }
}
