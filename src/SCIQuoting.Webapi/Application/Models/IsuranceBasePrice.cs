using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SCIQuoting.Webapi.Application.Models
{
    public class IsuranceBasePrice
    {
        public VehicleType VehicleType { get; set; }
        public int ManufacturingYear { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
        public int Price { get; set; }

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
