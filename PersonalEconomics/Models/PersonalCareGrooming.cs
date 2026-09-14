public class PersonalCareGrooming {
    public Insurance    HealthInsurance { get; set; } = new();
    public Insurance    LifeInsurance   { get; set; } = new();
    public double   HygieneProducts     { get; set; } = 0;
    public double   Clothes { get; set; } = 0;
    public double   Haircuts{ get; set; } = 0;
    public double   Total   { get; set; } = 0;
    public string   Note    { get; set; } = string.Empty;
}