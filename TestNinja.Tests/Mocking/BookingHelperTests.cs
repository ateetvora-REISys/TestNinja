using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using NUnit.Framework.Internal;
using TestNinja.Mocking;

namespace TestNinja.Tests.Mocking
{
    [TestFixture()]
    public class BookingHelperTests
    {
        private Mock<IBookingRepository> _bookingRepository;
        private List<Booking> _bookings;

        [SetUp]
        public void Setup()
        {
            _bookingRepository = new Mock<IBookingRepository>();
            _bookings = new List<Booking>
            {
                new Booking { Id=1, Reference = "Ateet_India", ArrivalDate = new DateTime(2018, 01, 01), DepartureDate = new DateTime(2018, 03, 31), Status = "Open"},
                new Booking { Id=2, Reference = "Ateet_Atlanta", ArrivalDate = new DateTime(2018, 07, 15), DepartureDate = new DateTime(2018, 07, 25), Status = "Open"},
                new Booking { Id=3, Reference = "Ateet_Toronto", ArrivalDate = new DateTime(2018, 11, 01), DepartureDate = new DateTime(2018, 11, 30), Status = "Open"}
            };

            _bookingRepository.Setup(a => a.GetBookings()).Returns(_bookings.AsQueryable);
        }

        [Test]
        public void OverlappingBookingsExist_WhenBookingCancelled_ReturnEmptyString()
        {
            var booking = new Booking {Status = "Cancelled", Id = 100};

            Assert.That(BookingHelper.OverlappingBookingsExist(booking, _bookingRepository.Object), Is.EqualTo(""));
        }

        [Test]
        public void OverlappingBookingsExist_WhenNoOverlappingBookingExists_ReturnEmptyString()
        {
            var booking = new Booking { Status = "Open", Id = 5, ArrivalDate = new DateTime(2018, 04, 11), DepartureDate = new DateTime(2018, 06, 20) };

            Assert.That(BookingHelper.OverlappingBookingsExist(booking, _bookingRepository.Object), Is.EqualTo(""));
        }

        [Test]
        public void OverlappingBookingsExist_WhenArrivalDateOverlapsWithCurrentBookings_ReturnReferenceValue()
        {
            var booking = new Booking { Status = "Open", Id = 5, ArrivalDate = new DateTime(2018, 01, 11), DepartureDate = new DateTime(2018, 01, 20) };

            Assert.That(BookingHelper.OverlappingBookingsExist(booking, _bookingRepository.Object), Is.EqualTo("Ateet_India"));
        }

        [Test]
        public void OverlappingBookingsExist_WhenDepartureDateOverlapsWithCurrentBookings_ReturnReferenceValue()
        {
            var booking = new Booking { Status = "Open", Id = 5, ArrivalDate = new DateTime(2018, 10, 01), DepartureDate = new DateTime(2018, 11, 20) };

            Assert.That(BookingHelper.OverlappingBookingsExist(booking, _bookingRepository.Object), Is.EqualTo("Ateet_Toronto"));
        }

        [Test]
        public void OverlappingBookingsExist_WhenArrivalDateAndDepartureOverlapSeparateBookings_ReturnReferenceValue()
        {
            var booking = new Booking { Status = "Open", Id = 5, ArrivalDate = new DateTime(2018, 07, 10), DepartureDate = new DateTime(2018, 07, 27) };

            Assert.That(BookingHelper.OverlappingBookingsExist(booking, _bookingRepository.Object), Is.EqualTo("Ateet_Atlanta"));
        }
    }
}
