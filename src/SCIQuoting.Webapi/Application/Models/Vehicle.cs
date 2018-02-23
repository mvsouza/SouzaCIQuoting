namespace SCIQuoting.Webapi.Application.Models{
    public enum VehicleType{
        Motocycle = 1,
        Car = 2,
        Truck = 3,
        Other = 4
    }
    public class Vehicle{
        public VehicleType VehicleType { get; set; }
        public string ManufacturingYear { get; set; }
        public string Model { get; set; }
        public string Make { get; set; }
    }
}