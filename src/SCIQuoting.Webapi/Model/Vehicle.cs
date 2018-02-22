namespace SCIQuoting.Webapi.Model{
    public enum VehicleType{
        Motorcycle = 1,
        Car = 2,
        Truck = 3,
        Other = 4
    }
    public class Vehicle{
        public VehicleType VehicleType { get; private set; }
        public string ManufacturingYear { get; private set; }
        public string Model { get; private set; }
        public string Make { get; private set; }
    }
}