using System;
using System.Globalization;
using InterfacePRO.Entities;

namespace InterfacePRO.Services
{
    class RentalServices
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private BrazilTaxServices _brazilTax = new BrazilTaxServices();

        public RentalServices(double priceperhour, double pricepreday)
        {
            PricePerHour = priceperhour;
            PricePerDay  = pricepreday;
        }

        public void ProcessInvoice(CarRental carRental){

            TimeSpan duration = carRental.Final.Subtract(carRental.Start);

            double basicPayment = 0.0;
            if(duration.TotalHours <= 12.0){
                basicPayment = Math.Ceiling(duration.TotalHours) * PricePerHour;

            }else{
                basicPayment = Math.Ceiling(duration.TotalDays) * PricePerDay;
            }

            double tax = _brazilTax.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
             
        }
    }
}
