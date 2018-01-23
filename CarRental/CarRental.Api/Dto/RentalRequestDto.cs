using System;

namespace CarRental.Api.Dto
{
    public class RentalRequestDto
    {
        public DateTime CustomerBirthday;
        public VehicleCategoryEnum VehicleCategory;
        public DateTime StartOfRental;
        public int DashboardMileage;
    }
}
