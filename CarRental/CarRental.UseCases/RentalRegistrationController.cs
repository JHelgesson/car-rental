using CarRental.Domain;
using CarRental.Domain.VehicleTypes;
using CarRental.RentalStorage;
using CarRental.UseCases.Exceptions;

namespace CarRental.UseCases
{
    public class RentalRegistrationController
    {
        private readonly IRentalStorage _rentalStorage;
        public RentalRegistrationController(IRentalStorage rentalStorage)
        {
            _rentalStorage = rentalStorage;
        }
        
        public RentalRegistration RentVehicle(Vehicle vehicle, Customer customer, Booking booking)
        {
            if (customer.IsYoungerThanEighteen)
                throw new CustomerToYoungException();

            if (booking.HasBookingDatePassed)
                throw new RentalStartTimeHasPassedException();

            if (vehicle.DashboardMileageLessThanZero)
                throw new DashboardMileageCannotBeNegative();

            return _rentalStorage.RentVehicle(new RentalRegistration(customer, vehicle, booking));
        }
    }
}
