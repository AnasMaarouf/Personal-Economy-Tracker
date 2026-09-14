using CommunityToolkit.Mvvm.ComponentModel;

namespace Personal_Economy_Display.ViewModels;

public partial class VehicleViewModel : CategoryViewModel {
    static int instances = 0;
    public Vehicle _vehicle;
    public VehicleViewModel(Vehicle Vehicle) {
        instances++;
        _vehicle = Vehicle;

        Model_TextBox = Vehicle.Model;
        NumberPlate_TextBox = Vehicle.NumberPlate;
        
        VehicleInsurance_Company_TextBox = Vehicle.VehicleInsurance.Company;
        VehicleInsurance_Type_TextBox = Vehicle.VehicleInsurance.Type;
        VehicleInsurance_Amount_TextBox = Vehicle.VehicleInsurance.Amount;
        VehicleInsurance_Note_TextBox = Vehicle.VehicleInsurance.Note;

        Fuel_TextBox = Vehicle.Fuel;
        Maintenance_TextBox = Vehicle.Maintenance;
        Repairs_TextBox = Vehicle.Repairs;
        Total_TextBox = Vehicle.Total;
        Note_TextBox = Vehicle.Note;
    }
    
    [ObservableProperty]
    public partial string Model_TextBox             { get; set; }
    [ObservableProperty]
    public partial string NumberPlate_TextBox       { get; set; }

    [ObservableProperty]
    public partial string VehicleInsurance_Company_TextBox { get; set; }
    [ObservableProperty]
    public partial string VehicleInsurance_Type_TextBox { get; set; }
    [ObservableProperty]
    public partial double VehicleInsurance_Amount_TextBox { get; set; }
    [ObservableProperty]
    public partial string VehicleInsurance_Note_TextBox { get; set; }

    [ObservableProperty]
    public partial double Fuel_TextBox              { get; set; }
    [ObservableProperty]
    public partial double Maintenance_TextBox       { get; set; }
    [ObservableProperty]
    public partial double Repairs_TextBox           { get; set; }
    [ObservableProperty]
    public partial double Total_TextBox             { get; set; }
    [ObservableProperty]
    public partial string Note_TextBox              { get; set; }
}