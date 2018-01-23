using System;
using CarRental.Api.Dto;

namespace CarRental.UseCaseTestAdapter
{
    public class RentalRequestBuilder
    {
        private RentalRequestDto _rentalRequestDto;

        public RentalRequestBuilder Begin()
        {
            _rentalRequestDto = new RentalRequestDto
            {
                VehicleCategory = VehicleCategoryEnum.Van,
                CustomerBirthday = DateTime.UtcNow.AddYears(-23),
                DashboardMileage = 10000,
                StartOfRental = DateTime.UtcNow.AddDays(10)
            };

            return this;
        }

        public RentalRequestBuilder With(VehicleCategoryEnum vehicleCategoryEnum)
        {
            _rentalRequestDto.VehicleCategory = vehicleCategoryEnum;
            return this;
        }

        public RentalRequestBuilder WithUnderAgeCustomer()
        {
            _rentalRequestDto.CustomerBirthday = DateTime.UtcNow.AddYears(-17);
            return this;
        }

        public RentalRequestBuilder WithRentalStartTimePassed()
        {
            _rentalRequestDto.StartOfRental = DateTime.UtcNow.AddDays(-1);
            return this;
        }

        public RentalRequestBuilder WithInvalidDashboardMileage()
        {
            _rentalRequestDto.DashboardMileage = -1;
            return this;
        }

        public RentalRequestDto Build()
        {
            return _rentalRequestDto;
        }
    }
}
