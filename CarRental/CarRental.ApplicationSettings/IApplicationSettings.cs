namespace CarRental.ApplicationSettings
{
    public interface IApplicationSettings
    {
        decimal GetBaseDayRentalPrice();
        decimal GetKilometerPrice();
    }
}
