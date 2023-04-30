using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using WpfMVVM01.Exceptions;
using WpfMVVM01.Models;

namespace WpfMVVM01
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        protected override void OnStartup(StartupEventArgs e)
        {
            Hotel hotel = new Hotel("My Hotel");

            try 
            {
                hotel.MakeReservation(new Reservation(
                    new RoomID(1, 3),
                    "MyName",
                    new DateTime(1995, 1, 1),
                    new DateTime(1999, 1, 3)));

                hotel.MakeReservation(new Reservation(
                    new RoomID(1, 3),
                    "MyName",
                    new DateTime(2000, 1, 1),
                    new DateTime(2000, 1, 2)));
            }
            catch(ReservationConflictException ex)
            {

            }

            IEnumerable<Reservation> reservations = hotel.GetAllReservations();

            base.OnStartup(e);
        }
    }
}
