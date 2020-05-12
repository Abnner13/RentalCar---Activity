using System;
using System.Globalization;
using InterfacePRO.Entities;

namespace InterfacePRO.Services
{
    class RentalServices
    {
        public double PricePerHour { get; private set; }
        public double PricePerDay { get; private set; }

        private ITaxService _taxService;

        public RentalServices(double priceperhour, double pricepreday, ITaxService taxService)
        {
            PricePerHour = priceperhour;
            PricePerDay  = pricepreday;
            _taxService = taxService;
        }

        public void ProcessInvoice(CarRental carRental){

            TimeSpan duration = carRental.Final.Subtract(carRental.Start);

            double basicPayment = 0.0;
            if(duration.TotalHours <= 12.0){
                basicPayment = Math.Ceiling(duration.TotalHours) * PricePerHour;

            }else{
                basicPayment = Math.Ceiling(duration.TotalDays) * PricePerDay;
            }

            double tax = _taxService.Tax(basicPayment);

            carRental.Invoice = new Invoice(basicPayment, tax);
             
        }
    }
}
