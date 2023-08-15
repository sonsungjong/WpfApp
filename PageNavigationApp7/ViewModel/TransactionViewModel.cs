using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageNavigationApp7.Model;

namespace PageNavigationApp7.ViewModel
{
    class TransactionViewModel : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        public decimal TransactionAmount
        {
            get
            {
                return _pageModel.TransactionValue;
            }
            set
            {
                _pageModel.TransactionValue = value;
                OnPropertyChanged();
            }
        }

        public TransactionViewModel()
        {
            _pageModel = new PageModel();
            TransactionAmount = 5638;
        }
    }
}
