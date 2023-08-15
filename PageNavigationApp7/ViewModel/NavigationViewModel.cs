using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageNavigationApp7.Utilities;
using System.Windows.Input;

namespace PageNavigationApp7.ViewModel
{
    class NavigationViewModel : ViewModelBase
    {
        private object _currentView;
        public object CurrentView
        {
            get
            {
                return _currentView;
            }
            set
            {
                _currentView = value;
                OnPropertyChanged();
            }
        }

        public ICommand HomeCommand { get; set; }
        public ICommand CustomersCommand { get; set; }
        public ICommand ProductsCommand { get; set; }
        public ICommand OrdersCommand { get; set; }
        public ICommand TransactionsCommand { get; set; }
        public ICommand ShipmentsCommand { get; set; }
        public ICommand SettingsCommand { get; set; }

        private void Home(object obj)
        {
            CurrentView = new HomeViewModel();
        }
        private void Customer(object obj)
        {
            CurrentView = new CustomerViewModel();
        }
        private void Product(object obj)
        {
            CurrentView = new ProductViewModel();
        }
        private void Order(object obj)
        {
            CurrentView = new OrderViewModel();
        }
        private void Transaction(object obj)
        {
            CurrentView = new TransactionViewModel();
        }
        private void Shipment(object obj)
        {
            CurrentView = new ShipmentViewModel();
        }
        private void Setting(object obj)
        {
            CurrentView = new SettingViewModel();
        }

        public NavigationViewModel()
        {
            HomeCommand = new ViewModelCommand(Home);
            CustomersCommand = new ViewModelCommand(Customer);
            ProductsCommand = new ViewModelCommand(Product);
            OrdersCommand = new ViewModelCommand(Order);
            TransactionsCommand = new ViewModelCommand(Transaction);
            ShipmentsCommand = new ViewModelCommand(Shipment);
            SettingsCommand = new ViewModelCommand(Setting);

            // Startup Page
            CurrentView = new HomeViewModel();
        }
    }
}
