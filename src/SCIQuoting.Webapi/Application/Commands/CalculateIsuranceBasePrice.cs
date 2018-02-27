using MediatR;
using SCIQuoting.Webapi.Application.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;

namespace SCIQuoting.Webapi.Application.Commands
{
    public class CalculateIsuranceBasePrice : IRequest<decimal>
    {

        [DataMember]
        public VehicleType VehicleType { get; private set; }
        [DataMember]
        public int ManufacturingYear { get; private set; }
        [DataMember]
        public string Model { get; private set; }
        [DataMember]
        public string Make { get; private set; }

        public CalculateIsuranceBasePrice(VehicleType vehicleType, int manufacturingYear, string model, string make)
        {
            VehicleType = vehicleType;
            ManufacturingYear = manufacturingYear;
            Model = model;
            Make = make;
        }
    }
}
