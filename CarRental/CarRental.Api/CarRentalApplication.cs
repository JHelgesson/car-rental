using System;
using CarRental.Api.Dto;
using CarRental.Domain;
using CarRental.Domain.VehicleTypes;
using CarRental.UseCases;

namespace CarRental.Api
{
    public class CarRentalApplication
    {
        private readonly RentalRegistrationController _rentalRegistration;
        private readonly CarReturnController _carReturn;

        public CarRentalApplication(RentalRegistrationController rentalRegistration,
            CarReturnController carReturn)
        {
            _rentalRegistration = rentalRegistration;
            _carReturn = carReturn;
        }
        
        public RentalRegistration RentVehicle(RentalRequestDto rentalRequestDto)
        {
            Vehicle vehicle;
            switch (rentalRequestDto.VehicleCategory)
                {
                    case VehicleCategoryEnum.SmallCar:
                        vehicle = new SmallCar(rentalRequestDto.DashboardMileage);
                        break;
                    case VehicleCategoryEnum.Van:
                        vehicle = new Van(rentalRequestDto.DashboardMileage);
                    break;
                    case VehicleCategoryEnum.MiniBus:
                         vehicle = new MiniBus(rentalRequestDto.DashboardMileage);
                    break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }

            var customer = new Customer(rentalRequestDto.CustomerBirthday);
            var booking = new Booking(rentalRequestDto.StartOfRental);

            return _rentalRegistration.RentVehicle(vehicle, customer, booking);
        }

        public RentalReceipt ReturnVehicle(Guid bookingId, DateTime returnDateTime, int dashboardMileage)
        {
            return _carReturn.ReturnVehicle(bookingId, returnDateTime, dashboardMileage);
        }
    }
}
