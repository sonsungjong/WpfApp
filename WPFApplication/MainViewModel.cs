using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Security.Policy;

namespace WPFApplication
{
    class MainViewModel : INotifyPropertyChanged
    {
        private Person _person;
        public MainViewModel()
        {
            _person = new Person { Name = "John Doe", Age = 30 };
        }

        public string Name
        {
            get => _person.Name;
            set
            {
                _person.Name = value;
                OnPropertyChanged();
            }
        }

        public int Age
        {
            get => _person.Age;
            set
            {
                _person.Age = value;
                OnPropertyChanged();
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
