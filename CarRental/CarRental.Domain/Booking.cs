using System;

namespace CarRental.Domain
{
    public class Booking
    {
        public Booking(Guid id, DateTime rentalStart)
        {
            Id = id;
            _rentalPeriod = new Period(rentalStart);
        }

        public Booking(DateTime rentalStart)
        {
            _rentalPeriod = new Period(rentalStart);
        }

        public void RegisterBooking(Guid id)
        {
            Id = id;
        }

        public int GetNumberOfRentedDays(DateTime endDate)
        {
            return _rentalPeriod.With(endDate).NumberOfDays;
        }

        public bool HasBookingDatePassed => DateTime.UtcNow > _rentalPeriod.Start;

        public Guid? Id;
        private readonly Period _rentalPeriod;
        public DateTime StartDate => _rentalPeriod.Start;
    }
}
