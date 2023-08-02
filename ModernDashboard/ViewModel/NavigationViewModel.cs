using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Data;
using System.Windows.Input;
using ModernDashboard.Model;

namespace ModernDashboard.ViewModel
{
    public class NavigationViewModel : INotifyPropertyChanged
    {
        // CollectionViewSource enables XAML code to set the commonly used CollectionView properties, passing these settings to the underlying view.
        private CollectionViewSource MenuItemsCollection;

        // ICollectionView enables collections to have the functionalities of current record management, custom sorting, filtering, and grouping.
        public ICollectionView SourceCollection => MenuItemsCollection.View;

        public NavigationViewModel()
        {
            // ObservableCollection represents a dynamic data collection that provides notifications when items get added, removed, or when the whole list is refreshed.
            ObservableCollection<MenuItems> menuItems = new ObservableCollection<MenuItems>
            {
                new MenuItems {MenuName = "Home", MenuImage = @"Assets/Home_Icon.png"},
                new MenuItems {MenuName = "Desktop", MenuImage = @"Assets/Desktop_Icon.png"},
                new MenuItems {MenuName = "Documents", MenuImage = @"Assets/Document_Icon.png"},
                new MenuItems {MenuName = "Downloads", MenuImage = @"Assets/Download_Icon.png"},
                new MenuItems {MenuName = "Pictures", MenuImage = @"Assets/Images_Icon.png"},
                new MenuItems {MenuName = "Music", MenuImage = @"Assets/Music_Icon.png"},
                new MenuItems {MenuName = "Movies", MenuImage = @"Assets/Movies_Icon.png"},
                new MenuItems {MenuName = "Trash", MenuImage = @"Assets/Trash_Icon.png"}
            };

            MenuItemsCollection = new CollectionViewSource { Source = menuItems };
            MenuItemsCollection.Filter += MenuItems_Filter;
        }

        // Implement interface member for INotifyPropertyChanged.
        public event PropertyChangedEventHandler PropertyChanged;
        private void OnPropertyChanged(string propName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propName));
        }

        // Text Search Filter.
        private string filterText;
        public string FilterText
        {
            get => filterText;
            set
            {
                filterText = value;
                MenuItemsCollection.View.Refresh();
                OnPropertyChanged("FilterText");
            }
        }

        private void MenuItems_Filter(object sender, FilterEventArgs e)
        {
            if (string.IsNullOrEmpty(FilterText))
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
    }
}
