using System.Globalization;

namespace CarRental.Domain.VehicleTypes
{
    public class Van : Vehicle, IRentCalculatable
    {
        private readonly decimal _dayFactor = decimal.Parse("1,2", new NumberFormatInfo { NumberDecimalSeparator = "," });

        public Van(int dashboardMileage) : base(dashboardMileage) { }

        public decimal Calculate(int numberOfDays, int numberOfKilometers, decimal baseRentalPrice, decimal baseKilometerPrice)
        {
            return baseRentalPrice * numberOfDays * 
                _dayFactor + baseKilometerPrice * numberOfKilometers;
        }
    }
}
