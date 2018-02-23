using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIQuoting.Webapi.Application.Models
{
    public class IsuranceBasePrice
    {
        public VehicleType VehicleType { get; private set; }
        public int ManufacturingYear { get; private set; }
        public string Model { get; private set; }
        public string Make { get; private set; }
        public int Price { get; private set; }

        public IsuranceBasePrice(VehicleType vehicleType, int manufacturingYear, string model, string make, int price)
        {
            this.VehicleType = vehicleType;
            this.ManufacturingYear = manufacturingYear;
            this.Model = model;
            this.Make = make;
            this.Price = price;
        }
    }
}
