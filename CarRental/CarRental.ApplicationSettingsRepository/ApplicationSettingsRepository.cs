using System.Globalization;
using CarRental.ApplicationSettings;

namespace CarRental.ApplicationSettingsRepository
{
    public class ApplicationSettingsRepository : IApplicationSettings
    {
        public decimal GetBaseDayRentalPrice()
        {
            return decimal.Parse("200", new NumberFormatInfo { NumberDecimalSeparator = "," });
        }

        public decimal GetKilometerPrice()
        {
            return decimal.Parse("50", new NumberFormatInfo { NumberDecimalSeparator = "," });
        }
    }
}
