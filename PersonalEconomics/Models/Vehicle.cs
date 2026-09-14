public class Vehicle {
    public string       Model       { get; set; } = string.Empty;
    public string       NumberPlate { get; set; } = string.Empty;
    public Insurance    VehicleInsurance { get; set; } = new();
    public double       Fuel        { get; set; } = 0;
    public double       Maintenance { get; set; } = 0;
    public double       Repairs     { get; set; } = 0;
    public double       Total       { get; set; } = 0;
    public string       Note        { get; set; } = string.Empty;
}