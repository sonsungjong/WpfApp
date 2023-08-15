using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageNavigationApp7.Model;

namespace PageNavigationApp7.ViewModel
{
    class CustomerViewModel : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;

        public int CustomerID
        {
            get { return _pageModel.CustomerCount; }
            set
            {
                _pageModel.CustomerCount = value;
                OnPropertyChanged();
            }
        }

        public CustomerViewModel()
        {
            _pageModel = new PageModel();
            CustomerID = 100528;
        }
    }
}
