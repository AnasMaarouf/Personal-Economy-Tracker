
using System;
using System.Collections.ObjectModel;
using System.Linq;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;

namespace Personal_Economy_Display.ViewModels;

public partial class ApartmentViewModel : CategoryViewModel {
    public Apartment _apartment;
    public ApartmentViewModel(Apartment apartment) {
        InsuranceSectionVisible = false;

        _apartment = apartment;
        LandlordTextBox = apartment.Landlord;
        AddressTextBox = apartment.Address;
        Utilities_WaterTextBox = apartment.Utilities.WaterBill;
        Utilities_HeatingTextBox = apartment.Utilities.HeatingBill;
        Utilities_InternetTextBox = apartment.Utilities.InternetBill;
        Utilities_LaundromatTextBox = apartment.Utilities.LaundromatSubscription;
        Utilities_ElectricityTextBox = apartment.Utilities.ElectricityBill;
        Utilities_NoteTextBox = apartment.Utilities.Note;

        foreach (var item in apartment.Insurances)
            Insurances.Add(item);

        FurnitureTextBox = apartment.Furniture;
        RepairsTextBox = apartment.Repairs;
        MortgageTextBox = apartment.Mortgage;
        RentTextBox = apartment.Rent;
        TotalTextBox = apartment.Total;
        NoteTextBox = apartment.Note;

        InsuranceCompany_TextBox = string.Empty;
        InsuranceType_TextBox = string.Empty;
        InsuranceAmount_TextBox = 0;
        InsuranceNote_TextBox = string.Empty;

    }
    
    [RelayCommand]
    private void DeleteInsurance(Insurance insurance) {
        #if DEBUG
            System.Console.WriteLine($"[OK]     \"ApartmentViewModel.DeleteInsuranceCommand(Insurance insurance)\" function Called");
        #endif

        var _insurance = _apartment.Insurances.FirstOrDefault(item =>
            item.Company == insurance.Company &&
            item.Type == insurance.Type &&
            item.Amount == insurance.Amount &&
            item.Note == insurance.Note
        );

        var error2 = _insurance != null && _apartment.Insurances.Remove(_insurance);


        _insurance = Insurances.FirstOrDefault(item =>
            item.Company == insurance.Company &&
            item.Type == insurance.Type &&
            item.Amount == insurance.Amount &&
            item.Note == insurance.Note
        );

        var error1 = _insurance != null && Insurances.Remove(_insurance);

        #if DEBUG
            if(error1 == true)
                System.Console.WriteLine($"[OK]                 |----> Deleting instance of insurance in Insurances:");
            else
                System.Console.WriteLine($"[ERROR]              |----> Deleting instance of insurance in Insurances:");
            
            System.Console.WriteLine($"                     |           |----> Name:            {insurance.Name}");
            System.Console.WriteLine($"                     |           |----> Company Name:    {insurance.Company}");
            System.Console.WriteLine($"                     |           |----> Insurance Type:  {insurance.Type}");
            System.Console.WriteLine($"                     |           |----> Amount:          {insurance.Amount}");
            System.Console.WriteLine($"                     |           |----> Note:            {insurance.Note}");
            System.Console.WriteLine($"                     |");

            if(error2 == true)
                System.Console.WriteLine($"[OK]                 |----> Deleting instance of insurance in _apartment.Insurances:");
            else {
                System.Console.WriteLine($"[ERROR]              |----> Deleting instance of insurance in _apartment.Insurances:");
            }
            System.Console.WriteLine($"                     |           |----> Name:            {_apartment.Insurances.FirstOrDefault(i => i.Company == insurance.Company)?.Name}");
            System.Console.WriteLine($"                     |           |----> Company Name:    {_apartment.Insurances.FirstOrDefault(i => i.Company == insurance.Company)?.Company}");
            System.Console.WriteLine($"                     |           |----> Insurance Type:  {_apartment.Insurances.FirstOrDefault(i => i.Company == insurance.Company)?.Type}");
            System.Console.WriteLine($"                     |           |----> Amount:          {_apartment.Insurances.FirstOrDefault(i => i.Company == insurance.Company)?.Amount}");
            System.Console.WriteLine($"                     |           |----> Note:            {_apartment.Insurances.FirstOrDefault(i => i.Company == insurance.Company)?.Note}");
            System.Console.WriteLine($"                     |");

            System.Console.WriteLine($"                     |----> Items in Insurances:");
            System.Console.WriteLine($"                     |           |----> Count:   {Insurances.Count}");
            
            foreach(var item in Insurances) {
                System.Console.WriteLine($"                     |           |----> {item.Company}; {item.Type}");
            }

            System.Console.WriteLine($"                     |");
            System.Console.WriteLine($"                     |----> Items in _apartment.Insurances:");
            System.Console.WriteLine($"                                 |----> Count:   {_apartment.Insurances.Count}");
            foreach(var item in _apartment.Insurances) {
                System.Console.WriteLine($"                                 |----> {item.Company}; {item.Type}");
            }

            System.Console.WriteLine($"");
        #endif

        SelectedHomeInsurancesExpenseListBox = null;
        InsuranceSectionVisible = false;
    }
    
    [RelayCommand]
    private void AddInsurance() {
        #if DEBUG
            System.Console.WriteLine($"[OK]     \"ApartmentView.AddInsuranceCommand()\" function Called.");
        #endif
        
        int nextNumber = Insurances.Count + 1;
        
        #if DEBUG
            System.Console.WriteLine($"                 |----> Number of insurances counted is {Insurances.Count}, next number is {nextNumber}.");
        #endif

        Insurances.Add(new Insurance {
            Company = $"Company {nextNumber}",
            Type = $"Insurance {nextNumber}",
            Amount = 0,
            Note = ""
        });

        _apartment.Insurances.Add(new Insurance {
            Company = $"Company {nextNumber}",
            Type = $"Insurance {nextNumber}",
            Amount = 0,
            Note = ""
        });


        #if DEBUG
            System.Console.WriteLine($"                 |----> New insurance added to Insurances list: {Insurances.Last().Type}.");
            System.Console.WriteLine($"                 |           |----> Company: {Insurances.Last().Company}.");
            System.Console.WriteLine($"                 |           |----> Type:    {Insurances.Last().Type}.");
            System.Console.WriteLine($"                 |           |----> Amount:  {Insurances.Last().Amount}.");
            System.Console.WriteLine($"                 |           |----> Note:    {Insurances.Last().Note}.");
            System.Console.WriteLine($"                 |");
            System.Console.WriteLine($"                 |----> New insurance added to _apartment.Insurances list: {_apartment.Insurances.Last().Type}.");
            System.Console.WriteLine($"                             |----> Company: {Insurances.Last().Company}.");
            System.Console.WriteLine($"                             |----> Type:    {Insurances.Last().Type}.");
            System.Console.WriteLine($"                             |----> Amount:  {Insurances.Last().Amount}.");
            System.Console.WriteLine($"                             |----> Note:    {Insurances.Last().Note}.");
            System.Console.WriteLine($"");
        #endif
    }


    [ObservableProperty]
    public partial string LandlordTextBox   { get; set; }

    [ObservableProperty]
    public partial string AddressTextBox    { get; set; }

    [ObservableProperty]
    public partial double FurnitureTextBox  { get; set; }

    [ObservableProperty]
    public partial double RepairsTextBox    { get; set; }

    [ObservableProperty]
    public partial double MortgageTextBox   { get; set; }

    [ObservableProperty]
    public partial double RentTextBox       { get; set; }

    [ObservableProperty]
    public partial double TotalTextBox      { get; set; }

    [ObservableProperty]
    public partial string NoteTextBox       { get; set; }

    // Utilities part
    [ObservableProperty]
    public partial double Utilities_ElectricityTextBox  { get; set; }
    [ObservableProperty]
    public partial double Utilities_WaterTextBox        { get; set; }
    [ObservableProperty]
    public partial double Utilities_HeatingTextBox      { get; set; }
    [ObservableProperty]
    public partial double Utilities_LaundromatTextBox   { get; set; }
    [ObservableProperty]
    public partial double Utilities_InternetTextBox     { get; set; }
    [ObservableProperty]
    public partial string Utilities_NoteTextBox         { get; set; }


    // Insurance part
    [ObservableProperty]
    public partial bool InsuranceSectionVisible { get; set; } = false;

    [ObservableProperty]
    public partial Insurance? SelectedHomeInsurancesExpenseListBox { get; set; }

    public ObservableCollection<Insurance> Insurances { get; } = new();

    [ObservableProperty]
    public partial string InsuranceCompany_TextBox { get; set; }

    [ObservableProperty]
    public partial string InsuranceType_TextBox { get; set; }

    [ObservableProperty]
    public partial double InsuranceAmount_TextBox { get; set; }

    [ObservableProperty]
    public partial string InsuranceNote_TextBox { get; set; }

    public static explicit operator ApartmentViewModel(Apartment? v)
    {
        throw new NotImplementedException();
    }
}
