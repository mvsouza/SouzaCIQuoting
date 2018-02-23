namespace SCIQuoting.Webapi.Application.Models{
    public enum VehicleType{
        Motocycle = 1,
        Car = 2,
        Truck = 3,
        Other = 4
    }
    public class Vehicle{
        public VehicleType VehicleType { get; private set; }
        public int ManufacturingYear { get; private set; }
        public string Model { get; private set; }
        public string Make { get; private set; }
    }
}