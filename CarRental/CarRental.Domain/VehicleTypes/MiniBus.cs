using System.Globalization;

namespace CarRental.Domain.VehicleTypes
{
    public class MiniBus : Vehicle, IRentCalculatable
    {
        private readonly decimal _dayFactor = decimal.Parse("1,7", new NumberFormatInfo { NumberDecimalSeparator = "," });
        private readonly decimal _kilometerFactor = decimal.Parse("1,5", new NumberFormatInfo { NumberDecimalSeparator = "," });

        public MiniBus(int dashboardMileage) : base(dashboardMileage) { }

        public decimal Calculate(int numberOfDays, int numberOfKilometers, decimal baseRentalPrice, decimal baseKilometerPrice)
        {
            return baseRentalPrice * numberOfDays * _dayFactor
                + baseKilometerPrice * numberOfKilometers * _kilometerFactor;
        }
    }
}
