using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageNavigationApp7.Model;

namespace PageNavigationApp7.ViewModel
{
    class OrderViewModel : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        public DateOnly DisplayOrderDate
        {
            get
            {
                return _pageModel.OrderDate;
            }
            set
            {
                _pageModel.OrderDate = value;
                OnPropertyChanged();
            }
        }
        public OrderViewModel()
        {
            _pageModel = new PageModel();
            DisplayOrderDate = DateOnly.FromDateTime(DateTime.Now);
        }
    }
}
