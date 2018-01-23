using System;
using System.Collections.Generic;
using System.Linq;
using CarRental.Domain;
using CarRental.RentalStorage;

namespace CarRental.RentalRepository
{
    public class RentalRepository : IRentalStorage
    {
        private readonly List<RentalRegistration> _rentalRegistrations;

        public RentalRepository()
        {
            _rentalRegistrations = new List<RentalRegistration>();
        }

        RentalRegistration IRentalStorage.RentVehicle(RentalRegistration rentalRegistration)
        {
            rentalRegistration.Booking.RegisterBooking(Guid.NewGuid());

            _rentalRegistrations.Add(rentalRegistration);

            return rentalRegistration;
        }

        public RentalRegistration GetRentalRegistration(Guid id)
        {
            return _rentalRegistrations.FirstOrDefault(item => item.Booking.Id == id);
        }
    }
}
