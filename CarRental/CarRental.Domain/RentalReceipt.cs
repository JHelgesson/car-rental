namespace CarRental.Domain
{
    public class RentalReceipt
    {
        public RentalReceipt(decimal amountToPay, Period rentalPeriod, int drivenKilometers)
        {
            AmountToPay = amountToPay;
            RentalPeriod = rentalPeriod;
            DrivenKilometers = drivenKilometers;
        }

        public readonly decimal AmountToPay;
        public readonly Period RentalPeriod;
        public readonly int DrivenKilometers;
    }
}
