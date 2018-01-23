using System;
using CarRental.Domain;

namespace CarRental.RentalStorage
{
    public interface IRentalStorage
    {
        RentalRegistration RentVehicle(RentalRegistration rentalRegistration);
        RentalRegistration GetRentalRegistration(Guid id);
    }
}
