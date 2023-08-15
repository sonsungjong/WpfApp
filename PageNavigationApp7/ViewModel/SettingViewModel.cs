using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageNavigationApp7.Model;

namespace PageNavigationApp7.ViewModel
{
    class SettingViewModel : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        public bool Settings
        {
            get
            {
                return _pageModel.LocationStatus;
            }
            set
            {
                _pageModel.LocationStatus = value;
                OnPropertyChanged();
            }
        }

        public SettingViewModel()
        {
            _pageModel = new PageModel();
            Settings = true;
        }
    }
}
