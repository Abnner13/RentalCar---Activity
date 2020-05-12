using System;

namespace InterfacePRO.Entities
{
    class CarRental
    {
        public DateTime Start { get; set; }
        public DateTime Final { get; set; }
        public Vehicle Vehicle { get; set; }
        public Invoice Invoice { get; set; }

        public CarRental(DateTime start, DateTime final, Vehicle vehicle)
        {
            Start = start;
            Final = final;
            Vehicle = vehicle;
           
        }
    }
}
