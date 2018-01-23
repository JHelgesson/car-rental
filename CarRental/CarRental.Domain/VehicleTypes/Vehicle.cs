namespace CarRental.Domain.VehicleTypes
{
    public abstract class Vehicle
    {
        protected Vehicle(int dashboardMileage)
        {
            DashboardMileage = dashboardMileage;
        }

        public int DashboardMileage { get; }
        public bool DashboardMileageLessThanZero => DashboardMileage < 0;

        public int GetDrivenKilometers(int endDashboardMileage)
        {
            return endDashboardMileage - DashboardMileage;
        }
    }
}
