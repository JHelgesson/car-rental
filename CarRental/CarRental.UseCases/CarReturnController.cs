using System;
using CarRental.ApplicationSettings;
using CarRental.Domain;
using CarRental.Domain.VehicleTypes;
using CarRental.RentalStorage;
using CarRental.UseCases.Exceptions;

namespace CarRental.UseCases
{
    public class CarReturnController
    {
        private readonly IRentalStorage _rentalStorage;
        private readonly IApplicationSettings _applicationSettings;

        public CarReturnController(IRentalStorage rentalStorage,
            IApplicationSettings applicationSettings)
        {
            _rentalStorage = rentalStorage;
            _applicationSettings = applicationSettings;
        }
        
        public RentalReceipt ReturnVehicle(Guid bookingId, DateTime returnDateTime, int dashboardMileage)
        {
            var rentalBooking = _rentalStorage.GetRentalRegistration(bookingId);

            if (rentalBooking == null)
                throw new BookingNotFoundException();

            var numberOfDays = rentalBooking.Booking.GetNumberOfRentedDays(returnDateTime);
            var kilometers = rentalBooking.Vehicle.GetDrivenKilometers(dashboardMileage);
            var amountToPay = ((IRentCalculatable) rentalBooking.Vehicle)
                .Calculate(numberOfDays, kilometers, _applicationSettings.GetBaseDayRentalPrice(), _applicationSettings.GetKilometerPrice());

            return new RentalReceipt(amountToPay, 
                new Period(rentalBooking.Booking.StartDate, returnDateTime),
                kilometers);
        }
    }
}
