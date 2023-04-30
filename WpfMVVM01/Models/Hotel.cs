using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

// Hotel -> ReservationBook -> Reservation -> RoomID

// User -> Make Reservation -> Display Reservation Conflict Error
// User -> View Reservations

namespace WpfMVVM01.Models
{
    internal class Hotel
    {
        private readonly ReservationBook _reservationBook;

        public string Name { get; }

        public Hotel(string name)
        {
            Name = name;

            _reservationBook = new ReservationBook();
        }

        /// <summary>
        /// Get the reservations for a user.
        /// </summary>
        /// <param name="username">The usrename of the user.</param>
        /// <returns>The reservations for the user.</returns>
        public IEnumerable<Reservation> GetAllReservations()
        {
            return _reservationBook.GetAllReservations();
        }

        /// <summary>
        /// Make a reservation.
        /// </summary>
        /// <param name="reservation">The incoming reservation.</param>
        /// <exception cref="ReservationConflictException">Thrown if incoming reservation conflicts with existing reservation.</exception>
        public void MakeReservation(Reservation reservation)
        {
            _reservationBook.AddReservation(reservation);
        }
    }
}
