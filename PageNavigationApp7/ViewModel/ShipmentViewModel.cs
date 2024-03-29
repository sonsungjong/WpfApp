﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PageNavigationApp7.Model;

namespace PageNavigationApp7.ViewModel
{
    class ShipmentViewModel : Utilities.ViewModelBase
    {
        private readonly PageModel _pageModel;
        public TimeOnly ShipmentTracking
        {
            get
            {
                return _pageModel.ShipmentDelivery;
            }
            set
            {
                _pageModel.ShipmentDelivery = value;
                OnPropertyChanged();
            }
        }

        public ShipmentViewModel()
        {
            _pageModel = new PageModel();
            TimeOnly time = TimeOnly.FromDateTime(DateTime.Now);
            ShipmentTracking = time;
        }
    }
}
