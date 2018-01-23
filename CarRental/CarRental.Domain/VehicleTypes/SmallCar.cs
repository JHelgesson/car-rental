namespace CarRental.Domain.VehicleTypes
{
    public class SmallCar : Vehicle, IRentCalculatable
    {
        public SmallCar(int dashboardMileage) : base(dashboardMileage) { }

        public decimal Calculate(int numberOfDays, int numberOfKilometers, decimal baseRentalPrice, decimal baseKilometerPrice)
        {
            return baseRentalPrice * numberOfDays;
        }
    }
}
