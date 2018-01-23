using System;

namespace CarRental.Domain
{
    public class Customer
    {
        public Customer(DateTime birthday)
        {
            Birthday = birthday;
        }

        public DateTime Birthday;
        public bool IsYoungerThanEighteen => DateTime.UtcNow.AddYears(-18) < Birthday;
    }
}
