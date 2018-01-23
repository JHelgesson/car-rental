using System;
using Autofac;
using CarRental.Api;
using CarRental.Dependencies;
using CarRental.Domain;
using CarRental.Domain.VehicleTypes;
using CarRental.RentalStorage;
using Xunit;

namespace CarRental.UseCaseTestAdapter
{
    public class CarReturnTests
    {
        [Theory]
        [InlineData(typeof(Van), 1000, 1100, 5, 6200)]
        [InlineData(typeof(Van), 1000, 1200, 5, 11200)]
        [InlineData(typeof(Van), 1000, 1300, 5, 16200)]
        [InlineData(typeof(MiniBus), 1000, 1100, 5, 9200)]
        [InlineData(typeof(MiniBus), 1000, 1200, 5, 16700)]
        [InlineData(typeof(MiniBus), 1000, 1300, 5, 24200)]
        [InlineData(typeof(SmallCar), 1000, 1100, 5, 1000)]
        [InlineData(typeof(SmallCar), 1000, 1200, 5, 1000)]
        [InlineData(typeof(SmallCar), 1000, 1300, 5, 1000)]
        public void CarReturnedTests(Type vehicleType, int startDashboardMileage, int endDashboardMileage, int numberOfRentDays, decimal expectedAmount)
        {
            var previouslyBookedVehicle = new RentalRegistration(
                new Customer(DateTime.Parse("1980-01-01")),
                (Vehicle)Activator.CreateInstance(vehicleType, startDashboardMileage),
                new Booking(Guid.NewGuid(), DateTime.UtcNow.AddDays(2)));

            var dependencies = new DependencyBuilder()
                .Begin()
                .WithProductionDependencies()
                .WithMock<IRentalStorage>(new RentalRepoMock(previouslyBookedVehicle))
                .Build();

            var sut = dependencies.Resolve<CarRentalApplication>();

            var result = sut.ReturnVehicle(previouslyBookedVehicle.Booking.Id.Value, 
                previouslyBookedVehicle.Booking.StartDate.AddDays(numberOfRentDays), 
                endDashboardMileage);

            Assert.Equal(expectedAmount, result.AmountToPay);
            Assert.Equal(previouslyBookedVehicle.Booking.StartDate, result.RentalPeriod.Start);
            Assert.Equal(numberOfRentDays, result.RentalPeriod.NumberOfDays);
            Assert.Equal(endDashboardMileage - startDashboardMileage, result.DrivenKilometers);
        }
    }

    public class RentalRepoMock : IRentalStorage
    {
        private readonly RentalRegistration _rentalRegistration;

        public RentalRepoMock(RentalRegistration rentalRegistration)
        {
            _rentalRegistration = rentalRegistration;
        }

        public RentalRegistration RentVehicle(RentalRegistration rentalRegistration)
        {
            throw new NotImplementedException();
        }

        public RentalRegistration GetRentalRegistration(Guid id)
        {
            return _rentalRegistration;
        }
    }
}
