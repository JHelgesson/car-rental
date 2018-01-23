using Autofac;
using CarRental.Api;
using CarRental.Api.Dto;
using CarRental.Dependencies;
using CarRental.UseCases.Exceptions;
using Xunit;

namespace CarRental.UseCaseTestAdapter
{
    public class RentalRegistrationTests
    {
        [Theory]
        [InlineData(VehicleCategoryEnum.MiniBus)]
        [InlineData(VehicleCategoryEnum.SmallCar)]
        [InlineData(VehicleCategoryEnum.Van)]
        public void RentalRegistrationTest(VehicleCategoryEnum vehicleCategoryEnum)
        {
            var dependencies = new DependencyBuilder()
                .Begin()
                .WithProductionDependencies()
                .Build();

            var sut = dependencies.Resolve<CarRentalApplication>();
            var rentalRequest = new RentalRequestBuilder()
                .Begin()
                .With(vehicleCategoryEnum)
                .Build();

            var bookingReference = sut.RentVehicle(rentalRequest);

            Assert.True(bookingReference.IsConfirmed);
            Assert.Equal(rentalRequest.CustomerBirthday, bookingReference.Customer.Birthday);
            Assert.Equal(rentalRequest.DashboardMileage, bookingReference.Vehicle.DashboardMileage);
            Assert.Equal(rentalRequest.StartOfRental, bookingReference.Booking.StartDate);
            Assert.Equal(rentalRequest.VehicleCategory.ToString(), bookingReference.Vehicle.GetType().Name);
        }

        [Fact]
        public void RentalRegistrationTest_WithUnderAgeDriver_ThrowsException()
        {
            var dependencies = new DependencyBuilder()
                .Begin()
                .WithProductionDependencies()
                .Build();

            var sut = dependencies.Resolve<CarRentalApplication>();
            var rentalRequest = new RentalRequestBuilder()
                .Begin()
                .WithUnderAgeCustomer()
                .Build();

            var bookingException = Assert.Throws<CustomerToYoungException>(() => sut.RentVehicle(rentalRequest));

            Assert.Equal(typeof(CustomerToYoungException), bookingException.GetType());
        }

        [Fact]
        public void RentalRegistrationTest_WithRentalStartTimePassed_ThrowsException()
        {
            var dependencies = new DependencyBuilder()
                .Begin()
                .WithProductionDependencies()
                .Build();

            var sut = dependencies.Resolve<CarRentalApplication>();
            var rentalRequest = new RentalRequestBuilder()
                .Begin()
                .WithRentalStartTimePassed()
                .Build();

            var bookingException = Assert.Throws<RentalStartTimeHasPassedException>(() => sut.RentVehicle(rentalRequest));

            Assert.Equal(typeof(RentalStartTimeHasPassedException), bookingException.GetType());
        }

        [Fact]
        public void RentalRegistrationTest_WithInvalidDashboardMileage_ThrowsException()
        {
            var dependencies = new DependencyBuilder()
                .Begin()
                .WithProductionDependencies()
                .Build();

            var sut = dependencies.Resolve<CarRentalApplication>();
            var rentalRequest = new RentalRequestBuilder()
                .Begin()
                .WithInvalidDashboardMileage()
                .Build();

            var bookingException = Assert.Throws<DashboardMileageCannotBeNegative>(() => sut.RentVehicle(rentalRequest));

            Assert.Equal(typeof(DashboardMileageCannotBeNegative), bookingException.GetType());
        }
    }
}
