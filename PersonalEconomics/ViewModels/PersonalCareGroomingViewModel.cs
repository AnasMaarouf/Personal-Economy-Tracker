using CommunityToolkit.Mvvm.ComponentModel;

namespace Personal_Economy_Display.ViewModels;

public partial class PersonalCareGroomingViewModel : CategoryViewModel {
    static int instances = 0;
    public PersonalCareGrooming _personalCareGrooming;
    public PersonalCareGroomingViewModel(PersonalCareGrooming PersonalCareGrooming) {
        instances++;
        _personalCareGrooming = PersonalCareGrooming;
        
        HealthInsurance_Company_TextBox = PersonalCareGrooming.HealthInsurance.Company;
        HealthInsurance_Type_TextBox    = PersonalCareGrooming.HealthInsurance.Type;
        HealthInsurance_Amount_TextBox  = PersonalCareGrooming.HealthInsurance.Amount;
        HealthInsurance_Note_TextBox    = PersonalCareGrooming.HealthInsurance.Note;

        LifeInsurance_Company_TextBox = PersonalCareGrooming.LifeInsurance.Company;
        LifeInsurance_Type_TextBox    = PersonalCareGrooming.LifeInsurance.Type;
        LifeInsurance_Amount_TextBox  = PersonalCareGrooming.LifeInsurance.Amount;
        LifeInsurance_Note_TextBox    = PersonalCareGrooming.LifeInsurance.Note;

        HygieneProducts_TextBox = PersonalCareGrooming.HygieneProducts;
        Clothes_TextBox     = PersonalCareGrooming.Clothes;
        Haircuts_TextBox    = PersonalCareGrooming.Haircuts;
        Total_TextBox       = PersonalCareGrooming.Total;
        Note_TextBox        = PersonalCareGrooming.Note;
    }

    [ObservableProperty]
    public partial string HealthInsurance_Company_TextBox   { get; set; }
    [ObservableProperty]
    public partial string HealthInsurance_Type_TextBox      { get; set; }
    [ObservableProperty]
    public partial double HealthInsurance_Amount_TextBox    { get; set; }
    [ObservableProperty]
    public partial string HealthInsurance_Note_TextBox      { get; set; }

    [ObservableProperty]
    public partial string LifeInsurance_Company_TextBox   { get; set; }
    [ObservableProperty]
    public partial string LifeInsurance_Type_TextBox      { get; set; }
    [ObservableProperty]
    public partial double LifeInsurance_Amount_TextBox    { get; set; }
    [ObservableProperty]
    public partial string LifeInsurance_Note_TextBox      { get; set; }


    [ObservableProperty]
    public partial double HygieneProducts_TextBox   { get; set; }
    [ObservableProperty]
    public partial double Clothes_TextBox           { get; set; }
    [ObservableProperty]
    public partial double Haircuts_TextBox          { get; set; }
    [ObservableProperty]
    public partial double Total_TextBox             { get; set; }
    [ObservableProperty]
    public partial string Note_TextBox              { get; set; }
    
}