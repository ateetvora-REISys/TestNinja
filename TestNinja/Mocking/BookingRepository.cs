using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestNinja.Mocking
{
    public interface IBookingRepository
    {
        IQueryable<Booking> GetBookings();
    }

    public class BookingRepository : IBookingRepository
    {
        public IQueryable<Booking> GetBookings()
        {
            var unitOfWork = new UnitOfWork();
            var bookings =
                unitOfWork.Query<Booking>();

            return bookings;
        }
    }
}
