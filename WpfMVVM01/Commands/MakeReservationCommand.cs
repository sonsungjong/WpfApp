using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfMVVM01.Exceptions;
using WpfMVVM01.Models;
using WpfMVVM01.Services;
using WpfMVVM01.ViewModels;

namespace WpfMVVM01.Commands
{
    // Submit 버튼의 동작 클래스
    internal class MakeReservationCommand : CommandBase
    {
        private readonly MakeReservationViewModel _makeReservationViewModel;
        private readonly Hotel _hotel;
        private readonly NavigationService _reservationViewNavigationService;

        public MakeReservationCommand(MakeReservationViewModel makeReservationViewModel, Hotel hotel, NavigationService reservationViewNavigationService)
        {
            _makeReservationViewModel = makeReservationViewModel;
            _hotel = hotel;
            _reservationViewNavigationService = reservationViewNavigationService;

            _makeReservationViewModel.PropertyChanged += OnViewModelPropertyChanged;
        }

        public override bool CanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(_makeReservationViewModel.Username) &&
                _makeReservationViewModel.FloorNumber > 0 &&
                base.CanExecute(parameter);
        }

        public override void Execute(object? parameter)
        {
            Reservation reservation = new Reservation(
                new RoomID(_makeReservationViewModel.FloorNumber, _makeReservationViewModel.RoomNumber),
                _makeReservationViewModel.Username,
                _makeReservationViewModel.StartDate,
                _makeReservationViewModel.EndDate
                );

            try
            {
                _hotel.MakeReservation(reservation);
                MessageBox.Show("Successfully reserved room", "Success", MessageBoxButton.OK, MessageBoxImage.Information);

                _reservationViewNavigationService.Navigate();
            }
            catch(ReservationConflictException)
            {
                MessageBox.Show("This room is already taken.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }

        }

        private void OnViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            if(e.PropertyName == nameof(MakeReservationViewModel.Username) || e.PropertyName == nameof(MakeReservationViewModel.FloorNumber))
            {
                OnCanExecutedChanged();
            }
        }
    }
}
