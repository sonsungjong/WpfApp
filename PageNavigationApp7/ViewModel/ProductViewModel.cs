using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageNavigationApp7.Model;

namespace PageNavigationApp7.ViewModel
{
    class ProductViewModel : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        public string ProductAvailability
        {
            get
            {
                return _pageModel.ProductStatus;
            }
            set
            {
                _pageModel.ProductStatus = value;
                OnPropertyChanged();
            }
        }

        public ProductViewModel()
        {
            _pageModel = new PageModel();
            ProductAvailability = "Out of Stock";
        }
    }
}
