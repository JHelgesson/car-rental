using CarRental.Domain.VehicleTypes;

namespace CarRental.Domain
{
    public class RentalRegistration
    {
        public RentalRegistration(Customer customer, Vehicle vehicle, Booking booking)
        {
            Customer = customer;
            Vehicle = vehicle;
            Booking = booking;
        }

        public bool IsConfirmed => Booking.Id.HasValue;

        public readonly Customer Customer;
        public readonly Vehicle Vehicle;
        public readonly Booking Booking;
    }
}
