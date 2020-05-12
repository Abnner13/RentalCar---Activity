using System;
using System.Globalization;
using InterfacePRO.Entities;
using InterfacePRO.Services;

namespace InterfacePRO
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter rental data");
            Console.Write("Car Model: ");
            string model = Console.ReadLine();

            Console.Write("Pickup (dd/MM/yyyy hh:mm): ");
            DateTime start = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);
            Console.Write("Return (dd/MM/yyyy hh:mm): ");
            DateTime finish = DateTime.ParseExact(Console.ReadLine(), "dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture);

            Console.Write("Enter price per hour: ");
            double priceHour = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            Console.Write("Enter price per Day: ");
            double priceDay = double.Parse(Console.ReadLine(),CultureInfo.InvariantCulture);
            
            
            CarRental carRental = new CarRental(start, finish, new Vehicle(model));
            
            RentalServices rentalServices = new RentalServices(priceHour, priceDay, new BrazilTaxServices());
            
            rentalServices.ProcessInvoice(carRental);
            
            Console.WriteLine("INVOICE: ");

            System.Console.WriteLine(carRental.Invoice);

            

        }
    }
}
