namespace CarRental.Domain.VehicleTypes
{
    public interface IRentCalculatable
    {
        decimal Calculate(int numberOfDays, int numberOfKilometers, decimal baseRentalPrice, decimal baseKilometerPrice);
    }
}
