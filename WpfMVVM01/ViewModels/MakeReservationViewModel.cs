using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using WpfMVVM01.Commands;
using WpfMVVM01.Models;

namespace WpfMVVM01.ViewModels
{
    internal class MakeReservationViewModel : ViewModelBase
    {
        private string _username;

        // View(.xmal) 에서 {Binding Username} 을 통해 사용
        public string Username
        {
            get { return _username; }
            set {
                _username = value;
                OnPropertyChanged(nameof(Username));
            }
        }

        private int _roomNumber;

        // {Binding RoomNumber} 로 사용
        public int RoomNumber
        {
            get { return _roomNumber; }
            set
            {
                _roomNumber = value;
                OnPropertyChanged(nameof(RoomNumber));
            }
        }

        private int _floorNumber;
        // {Binding FloorNumber}
        public int FloorNumber
        {
            get { return _floorNumber; }
            set
            {
                _floorNumber = value;
                OnPropertyChanged(nameof(FloorNumber));
            }
        }

        private DateTime _startDate = new DateTime(2021,1,1);
        public DateTime StartDate
        {
            get { return _startDate; }
            set
            {
                _startDate = value;
                OnPropertyChanged(nameof(StartDate));
            }
        }

        private DateTime _endDate = new DateTime(2021, 1, 8);
        public DateTime EndDate
        {
            get { return _endDate; }
            set
            {
                _endDate = value;
                OnPropertyChanged(nameof(EndDate));
            }
        }

        // Submit버튼 동작 : Commands 의 MakeReservationCommand.cs
        public ICommand SubmitCommand { get; }

        // Cancel버튼 동작 : Commands 의 CancelMakeReservationCommand.cs
        public ICommand CancelCommand { get; }

        public MakeReservationViewModel(Hotel hotel)
        {
            // 생성자
            SubmitCommand = new MakeReservationCommand(this, hotel);            // submit 버튼 동작 클래스 객체화
            CancelCommand = new CancelMakeReservationCommand();                 // cancel 버튼 동작 클래스 객체화
        }
    }
}
