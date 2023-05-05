using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfMVVM01.Models;

namespace WpfMVVM01.ViewModels
{
    internal class MainViewModel : ViewModelBase
    {
        public ViewModelBase CurrentViewModel { get; }
        public MainViewModel(Hotel hotel)
        {
            CurrentViewModel = new ReservationListingViewModel();
        }
    }
}
