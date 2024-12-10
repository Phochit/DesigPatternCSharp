using System;
namespace Facade
{
    // Subsystem of Vehicle Inventory  
    public class VehicleInventory
    {
        public bool CheckAvailability(string vehicleType)
        {
            Console.WriteLine($"Checking availability for {vehicleType}...");
            return true;
        }

        public void BookVehicle(string vehicleType)
        {
            Console.WriteLine($"{vehicleType} has been booked.");
        }
    }

    // Subsystem of Driver Service
    public class DriverService
    {
        public void AssignDriver(string vehicleType)
        {
            string drName = "Ko HTW";
            Console.WriteLine($"Driver {drName} assigned for {vehicleType}.");
        }
    }

    // Subsystem of Taxi Fees
    public class TaxiFeesCalculator
    {
        public decimal CalculateFees(string vehicleType, int rentalDays)
        {
            Console.WriteLine($"Calculating cost for {vehicleType} for {rentalDays} days...");
            decimal cost = rentalDays * 25; //  $25 per day
            Console.WriteLine($"Total cost: ${cost}");
            return cost;
        }
    }

    // Subsystem of Payment Service
    public class PaymentService
    {
        public bool ProcessPayment(decimal amount)
        {
            Console.WriteLine($"Processing payment of ${amount}...");
            return true;
        }
    }

    // Facade Object
    public class VehicleRentalFacade
    {
        private readonly VehicleInventory _vehicleInventory;
        private readonly DriverService _driverService;
        private readonly TaxiFeesCalculator _rentalCostCalculator;
        private readonly PaymentService _paymentService;

        public VehicleRentalFacade(VehicleInventory vehicleInventory, DriverService driverService,
                                   TaxiFeesCalculator rentalCostCalculator, PaymentService paymentService)
        {
            _vehicleInventory = vehicleInventory;
            _driverService = driverService;
            _rentalCostCalculator = rentalCostCalculator;
            _paymentService = paymentService;
        }

        public void RentVehicle(string vehicleType, int rentalDays, bool needsDriver)
        {
            Console.WriteLine("Starting vehicle rental process...");

            if (!_vehicleInventory.CheckAvailability(vehicleType))
            {
                Console.WriteLine("Vehicle not available. Cannot proceed with rental.");
                return;
            }

            _vehicleInventory.BookVehicle(vehicleType);

            if (needsDriver)
            {
                _driverService.AssignDriver(vehicleType);
            }

            var cost = _rentalCostCalculator.CalculateFees(vehicleType, rentalDays);

            if (!_paymentService.ProcessPayment(cost))
            {
                Console.WriteLine("Payment failed. Cannot complete the rental.");
                return;
            }

            Console.WriteLine("Vehicle rental process completed successfully!");
        }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            // Subsystems
            var vehicleInventory = new VehicleInventory();
            var driverService = new DriverService();
            var rentalCostCalculator = new TaxiFeesCalculator();
            var paymentService = new PaymentService();

            // Facade
            var vehicleRentalFacade = new VehicleRentalFacade(vehicleInventory, driverService,
                                                              rentalCostCalculator, paymentService);

            // Client uses the facade to rent a vehicle
            vehicleRentalFacade.RentVehicle("Mini-Bus", 4, true); // Mini-Bus for 4 days with a driver
        }
    }
}