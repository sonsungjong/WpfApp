using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LeftMenuDashBoard7.ViewModel
{
    public abstract class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged(string a_property_name)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(a_property_name));
        }
    }
}
