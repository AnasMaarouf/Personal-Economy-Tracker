using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using System.IO;
using System.Text.Json;

namespace Personal_Economy_Display.ViewModels;

public partial class ExpenseViewModel : ObservableObject {
    [ObservableProperty]
    public partial DateTime PickedDate { get; set; } = DateTime.Now;
    [ObservableProperty]
    public partial string Expense_DragNDrop_Box_BackgroundColor { get; set; } = "#FFFFFFFF";

    public ObservableCollection<PdfFile_Processor> Files { get; } = new();

    public ObservableCollection<CategoryViewModel> Categories { get; } = new();

    [ObservableProperty]
    public partial CategoryViewModel? SelectedCategory { get; set; } = null;


    public bool LoadExpenseData(DateOnly day) {
        
        string path = Path.Combine(
            AppContext.BaseDirectory,
            "DataEntries",
            day.Year.ToString(),
            day.Month.ToString(),
            day.Day.ToString(),
            "Expense"
        );
        
        if(!Directory.Exists(path)) {
            return false;
        }

        if(Directory.Exists($"{path}/Files")) {
            var ListOfFiles = Directory.EnumerateFiles($"{path}/Files");
            foreach (var file in ListOfFiles) {
                var pdf = new PdfFile_Processor(file);
                if (pdf.Thumbnail != null) {
                    pdf.Thumbnail = AvaloniaPdfThumbnailConverter.ToBitmap((PdfThumbnail)pdf.Thumbnail);
                }
                Files.Add(pdf);
            }
        }

        if(Directory.Exists($"{path}/Apartment")) {
            var ListOfFiles = Directory.EnumerateFiles($"{path}/Apartment");
            foreach (var file in ListOfFiles) {
                try {
                    #if DEBUG
                        System.Console.WriteLine($"                 |----> Deserialising JSON file:");
                        System.Console.WriteLine($"                 |           |----> Filename:        {file}");
                        System.Console.WriteLine($"                 |");
                    #endif
                    
                    // This reads and deserializes object
                    string ReadFile = File.ReadAllText(file);
                    Apartment? _apartment = JsonSerializer.Deserialize<Apartment>(ReadFile);
                    if(_apartment is not null) {
                        Categories.FirstOrDefault(cat => cat.Name == "Apartment" && cat.IsCategoryRoot == true)?.Children.Add(new ApartmentViewModel(_apartment) {
                                Name = Path.GetFileName(file),
                                CanDelete = true
                            }
                        );
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> _apartment is NULL");
                        #endif
                        return false;
                    }

                    
                    #if DEBUG
                        ApartmentViewModel? viewModel = Categories.FirstOrDefault(cat => cat.Name == "Apartment" && cat.IsCategoryRoot == true)?.Children?.Last() as ApartmentViewModel;
                        System.Console.WriteLine($"[OK]             |----> File deserialized:");
                        System.Console.WriteLine($"                 |           |----> Name:      {Categories.FirstOrDefault(cat => cat.Name == "Apartment" && cat.IsCategoryRoot == true)?.Children.Last().Name}");
                        System.Console.WriteLine($"                 |           |----> Landlord:  {viewModel?._apartment.Landlord}");
                        System.Console.WriteLine($"                 |           |----> Rent:      {viewModel?._apartment.Rent}");

                        System.Console.WriteLine($"                 |           |----> Utilities heating:     {viewModel?._apartment.Utilities.HeatingBill}");
                        System.Console.WriteLine($"                 |           |----> Utilities Water:       {viewModel?._apartment.Utilities.WaterBill}");
                        System.Console.WriteLine($"                 |           |----> Utilities Internet:    {viewModel?._apartment.Utilities.InternetBill}");
                        System.Console.WriteLine($"                 |           |----> Utilities electricity: {viewModel?._apartment.Utilities.ElectricityBill}");
                        System.Console.WriteLine($"                 |           |----> Utilities laundromat:  {viewModel?._apartment.Utilities.LaundromatSubscription}");
                        System.Console.WriteLine($"                 |           |----> Utilities Total:       {viewModel?._apartment.Utilities.Total}");
                        System.Console.WriteLine($"                 |           |----> Utilities Note:        {viewModel?._apartment.Utilities.Note}");

                        System.Console.WriteLine($"                 |           |----> Number of insurances:  {viewModel?._apartment.Insurances.Count}");

                        System.Console.WriteLine($"                 |           |----> Address:   {viewModel?._apartment.Address}");
                        System.Console.WriteLine($"                 |           |----> Furniture: {viewModel?._apartment.Furniture}");
                        System.Console.WriteLine($"                 |           |----> Mortgage:  {viewModel?._apartment.Mortgage}");
                        System.Console.WriteLine($"                 |           |----> Repairs:   {viewModel?._apartment.Repairs}");
                        System.Console.WriteLine($"                 |           |----> Total:     {viewModel?._apartment.Total}");
                        System.Console.WriteLine($"                 |           |----> Note:      {viewModel?._apartment.Note}");
                        System.Console.WriteLine($"                 |");
                    #endif
                } catch(ArgumentNullException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(JsonException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    JsonException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(NotSupportedException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                }
            }
        }
        
        if(Directory.Exists($"{path}/Groceries")) {
            var ListOfFiles = Directory.EnumerateFiles($"{path}/Groceries");
            foreach (var file in ListOfFiles) {
                try {
                    #if DEBUG
                        System.Console.WriteLine($"                 |----> Deserialising JSON file:");
                        System.Console.WriteLine($"                 |           |----> Filename:        {file}");
                        System.Console.WriteLine($"                 |");
                    #endif

                    // This reads and deserializes object
                    string ReadFile = File.ReadAllText(file);
                    Grocery? _grocery = JsonSerializer.Deserialize<Grocery>(ReadFile);
                    if(_grocery is not null) {
                        Categories.FirstOrDefault(cat => cat.Name == "Grocery" && cat.IsCategoryRoot == true)?.Children.Add(new GroceriesViewModel(_grocery) {
                                Name = Path.GetFileName(file),
                                CanDelete = true
                            }
                        );
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> _grocery is NULL");
                        #endif
                        return false;
                    }
                    
                    
                    #if DEBUG
                        GroceriesViewModel? viewModel = Categories.FirstOrDefault(cat => cat.Name == "Groceries" && cat.IsCategoryRoot == true)?.Children?.Last() as GroceriesViewModel;
                        System.Console.WriteLine($"[OK]             |----> File deserialized:");
                        System.Console.WriteLine($"                 |           |----> Name:  {Categories.FirstOrDefault(cat => cat.Name == "Groceries" && cat.IsCategoryRoot == true)?.Children.Last().Name}");
                        System.Console.WriteLine($"                 |           |----> Candy: {viewModel?._groceries.Candy}");
                        System.Console.WriteLine($"                 |           |----> Fish:  {viewModel?._groceries.Fish}");
                        System.Console.WriteLine($"                 |           |----> Meat:  {viewModel?._groceries.Meat}");
                        System.Console.WriteLine($"                 |           |----> Soda:  {viewModel?._groceries.Soda}");
                        System.Console.WriteLine($"                 |           |----> Vegetables:      {viewModel?._groceries.Vegetables}");
                        System.Console.WriteLine($"                 |           |----> Canned Products: {viewModel?._groceries.CannedProducts}");
                        System.Console.WriteLine($"                 |           |----> Household Items: {viewModel?._groceries.HouseholdItems}");
                        System.Console.WriteLine($"                 |           |----> Other Items:     {viewModel?._groceries.OtherItems}");
                        System.Console.WriteLine($"                 |           |----> Total: {viewModel?._groceries.Total}");
                        System.Console.WriteLine($"                 |           |----> Note:  {viewModel?._groceries.Note}");
                        System.Console.WriteLine($"                 |");
                    #endif
                } catch(ArgumentNullException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(JsonException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    JsonException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(NotSupportedException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                }
            }
        }

        if(Directory.Exists($"{path}/Entertainment")) {
            var ListOfFiles = Directory.EnumerateFiles($"{path}/Entertainment");
            foreach (var file in ListOfFiles) {
                try {
                    #if DEBUG
                        System.Console.WriteLine($"                 |----> Deserialising JSON file:");
                        System.Console.WriteLine($"                 |           |----> Filename:        {file}");
                        System.Console.WriteLine($"                 |");
                    #endif

                    
                    // This reads and deserializes object
                    string ReadFile = File.ReadAllText(file);
                    Entertainment? _entertainment = JsonSerializer.Deserialize<Entertainment>(ReadFile);
                    if(_entertainment is not null) {
                        Categories.FirstOrDefault(cat => cat.Name == "Entertainment" && cat.IsCategoryRoot == true)?.Children.Add(new EntertainmentViewModel(_entertainment) {
                                Name = Path.GetFileName(file),
                                CanDelete = true
                            }
                        );
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> _entertainment is NULL");
                        #endif
                        return false;
                    }

                    #if DEBUG
                        EntertainmentViewModel? viewModel = Categories.FirstOrDefault(cat => cat.Name == "Entertainment" && cat.IsCategoryRoot == true)?.Children?.Last() as EntertainmentViewModel;
                        System.Console.WriteLine($"[OK]             |----> File deserialized:");
                        System.Console.WriteLine($"                 |           |----> Name:     {Categories.FirstOrDefault(cat => cat.Name == "Entertainment" && cat.IsCategoryRoot == true)?.Children.Last().Name}");
                        System.Console.WriteLine($"                 |           |----> Books:    {viewModel?._entertainment.Books}");
                        System.Console.WriteLine($"                 |           |----> Hobbies:  {viewModel?._entertainment.Hobbies}");
                        System.Console.WriteLine($"                 |           |----> Movies:   {viewModel?._entertainment.Movies}");
                        System.Console.WriteLine($"                 |           |----> Vacation: {viewModel?._entertainment.Vacation}");
                        System.Console.WriteLine($"                 |           |----> Concert Tickets:    {viewModel?._entertainment.ConcertTickets}");
                        System.Console.WriteLine($"                 |           |----> Sporting Events:    {viewModel?._entertainment.SportingEvents}");
                        System.Console.WriteLine($"                 |           |----> Streaming Services: {viewModel?._entertainment.StreamingServicesSubscriptions}");
                        System.Console.WriteLine($"                 |           |----> Bar Hopping:        {viewModel?._entertainment.BarHopping}");
                        System.Console.WriteLine($"                 |           |----> Total: {viewModel?._entertainment.Total}");
                        System.Console.WriteLine($"                 |           |----> Note:  {viewModel?._entertainment.Note}");
                        System.Console.WriteLine($"                 |");
                    #endif
                } catch(ArgumentNullException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(JsonException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    JsonException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(NotSupportedException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                }
            }
        }
        
        if(Directory.Exists($"{path}/Personal care & grooming")) {
            var ListOfFiles = Directory.EnumerateFiles($"{path}/Personal care & grooming");
            foreach (var file in ListOfFiles) {
                try {
                    #if DEBUG
                        System.Console.WriteLine($"                 |----> Deserialising JSON file:");
                        System.Console.WriteLine($"                 |           |----> Filename:        {file}");
                        System.Console.WriteLine($"                 |");
                    #endif
                    
                    // This reads and deserializes object
                    string ReadFile = File.ReadAllText(file);
                    PersonalCareGrooming? _personalCareGrooming = JsonSerializer.Deserialize<PersonalCareGrooming>(ReadFile);
                    if(_personalCareGrooming is not null) {
                        Categories.FirstOrDefault(cat => cat.Name == "Personal care & grooming" && cat.IsCategoryRoot == true)?.Children.Add(new PersonalCareGroomingViewModel(_personalCareGrooming) {
                                Name = Path.GetFileName(file),
                                CanDelete = true
                            }
                        );
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> _personalCareGrooming is NULL");
                        #endif
                        return false;
                    }
                    
                    #if DEBUG
                        PersonalCareGroomingViewModel? viewModel = Categories.FirstOrDefault(cat => cat.Name == "Personal care & grooming" && cat.IsCategoryRoot == true)?.Children?.Last() as PersonalCareGroomingViewModel;
                        System.Console.WriteLine($"[OK]             |----> File deserialized:");
                        System.Console.WriteLine($"                 |           |----> Name:     {Categories.FirstOrDefault(cat => cat.Name == "Personal care & grooming" && cat.IsCategoryRoot == true)?.Children.Last().Name}");
                        System.Console.WriteLine($"                 |           |----> Clothes:  {viewModel?._personalCareGrooming.Clothes}");
                        System.Console.WriteLine($"                 |           |----> Haircuts: {viewModel?._personalCareGrooming.Haircuts}");
                        System.Console.WriteLine($"                 |           |----> Hygiene Products:         {viewModel?._personalCareGrooming.HygieneProducts}");
                        System.Console.WriteLine($"                 |           |----> Health Insurance Company: {viewModel?._personalCareGrooming.HealthInsurance.Company}");
                        System.Console.WriteLine($"                 |           |----> Health Insurance Type:    {viewModel?._personalCareGrooming.HealthInsurance.Type}");
                        System.Console.WriteLine($"                 |           |----> Health Insurance Amount:  {viewModel?._personalCareGrooming.HealthInsurance.Amount}");
                        System.Console.WriteLine($"                 |           |----> Health Insurance Note:    {viewModel?._personalCareGrooming.HealthInsurance.Note}");
                        System.Console.WriteLine($"                 |           |----> Total:    {viewModel?._personalCareGrooming.Total}");
                        System.Console.WriteLine($"                 |           |----> Note:     {viewModel?._personalCareGrooming.Note}");
                        System.Console.WriteLine($"                 |");
                    #endif
                } catch(ArgumentNullException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(JsonException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    JsonException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(NotSupportedException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                }
            }
        }
        
        if(Directory.Exists($"{path}/Vehicle")) {
            var ListOfFiles = Directory.EnumerateFiles($"{path}/Vehicle");
            foreach (var file in ListOfFiles) {
                try {
                    #if DEBUG
                        System.Console.WriteLine($"                 |----> Deserialising JSON file:");
                        System.Console.WriteLine($"                 |           |----> Filename:        {file}");
                        System.Console.WriteLine($"                 |");
                    #endif

                    // This reads and deserializes object
                    string ReadFile = File.ReadAllText(file);
                    Vehicle? _vehicle = JsonSerializer.Deserialize<Vehicle>(ReadFile);
                    if(_vehicle is not null) {
                        Categories.FirstOrDefault(cat => cat.Name == "Vehicle" && cat.IsCategoryRoot == true)?.Children.Add(new VehicleViewModel(_vehicle) {
                                Name = Path.GetFileName(file),
                                CanDelete = true
                            }
                        );
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> _vehicle is NULL");
                        #endif
                        return false;
                    }
                    
                    #if DEBUG
                        VehicleViewModel? viewModel = Categories.FirstOrDefault(cat => cat.Name == "Vehicle" && cat.IsCategoryRoot == true)?.Children?.Last() as VehicleViewModel;
                        System.Console.WriteLine($"[OK]             |----> File deserialized:");
                        System.Console.WriteLine($"                 |           |----> Name:        {Categories.FirstOrDefault(cat => cat.Name == "Vehicle" && cat.IsCategoryRoot == true)?.Children.Last().Name}");
                        System.Console.WriteLine($"                 |           |----> Model:       {viewModel?._vehicle.Model}");
                        System.Console.WriteLine($"                 |           |----> NumberPlate: {viewModel?._vehicle.NumberPlate}");
                        System.Console.WriteLine($"                 |           |----> Fuel:        {viewModel?._vehicle.Fuel}");
                        System.Console.WriteLine($"                 |           |----> Repairs:     {viewModel?._vehicle.Repairs}");
                        System.Console.WriteLine($"                 |           |----> Maintenance: {viewModel?._vehicle.Maintenance}");
                        System.Console.WriteLine($"                 |           |----> Health Insurance Company: {viewModel?._vehicle.VehicleInsurance.Company}");
                        System.Console.WriteLine($"                 |           |----> Health Insurance Type:    {viewModel?._vehicle.VehicleInsurance.Type}");
                        System.Console.WriteLine($"                 |           |----> Health Insurance Amount:  {viewModel?._vehicle.VehicleInsurance.Amount}");
                        System.Console.WriteLine($"                 |           |----> Health Insurance Note:    {viewModel?._vehicle.VehicleInsurance.Note}");
                        System.Console.WriteLine($"                 |           |----> Total: {viewModel?._vehicle.Total}");
                        System.Console.WriteLine($"                 |           |----> Note:  {viewModel?._vehicle.Note}");
                        System.Console.WriteLine($"                 |");
                    #endif
                } catch(ArgumentNullException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(JsonException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    JsonException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(NotSupportedException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                }
            }
        }
        
        if(Directory.Exists($"{path}/Miscellaneous")) {
            var ListOfFiles = Directory.EnumerateFiles($"{path}/Miscellaneous");
            foreach (var file in ListOfFiles) {
                try {
                    #if DEBUG
                        System.Console.WriteLine($"                 |----> Deserialising JSON file:");
                        System.Console.WriteLine($"                 |           |----> Filename:        {file}");
                        System.Console.WriteLine($"                 |");
                    #endif

                    // This reads and deserializes object
                    string ReadFile = File.ReadAllText(file);
                    ExpenseMiscellaneous? _expenseMiscellaneous = JsonSerializer.Deserialize<ExpenseMiscellaneous>(ReadFile);
                    if(_expenseMiscellaneous is not null) {
                        Categories.FirstOrDefault(cat => cat.Name == "Miscellaneous" && cat.IsCategoryRoot == true)?.Children.Add(new ExpenseMiscellaneousViewModel(_expenseMiscellaneous) {
                                Name = Path.GetFileName(file),
                                CanDelete = true
                            }
                        );
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> _expenseMiscellaneous is NULL");
                        #endif
                        return false;
                    }
                    
                    #if DEBUG
                        ExpenseMiscellaneousViewModel? viewModel = Categories.FirstOrDefault(cat => cat.Name == "Miscellaneous" && cat.IsCategoryRoot == true)?.Children?.Last() as ExpenseMiscellaneousViewModel;
                        System.Console.WriteLine($"[OK]             |----> File deserialized:");
                        System.Console.WriteLine($"                 |           |----> Name:  {Categories.FirstOrDefault(cat => cat.Name == "Miscellaneous" && cat.IsCategoryRoot == true)?.Children.Last().Name}");
                        System.Console.WriteLine($"                 |           |----> TakeoutFood: {viewModel?._expenseMiscellaneous.TakeoutFood}");
                        System.Console.WriteLine($"                 |           |----> Total: {viewModel?._expenseMiscellaneous.Total}");
                        System.Console.WriteLine($"                 |           |----> Note:  {viewModel?._expenseMiscellaneous.Note}");
                        System.Console.WriteLine($"                 |");
                    #endif
                } catch(ArgumentNullException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(JsonException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    JsonException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(NotSupportedException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                }
            }
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]                 |----> Files Loaded");
        #endif
        return true;
    } 


    public ExpenseViewModel() {
        
        Categories.Add(new CategoryViewModel {
            Name = "Apartment",
            IsCategoryRoot = true,
        });

        Categories.Add(new CategoryViewModel {
            Name = "Groceries",
            IsCategoryRoot = true
        });

        Categories.Add(new CategoryViewModel {
            Name = "Entertainment",
            IsCategoryRoot = true
        });

        Categories.Add(new CategoryViewModel {
            Name = "Personal care & grooming",
            IsCategoryRoot = true
        });

        Categories.Add(new CategoryViewModel {
            Name = "Vehicle",
            IsCategoryRoot = true
        });

        Categories.Add(new CategoryViewModel {
            Name = "Miscellaneous",
            IsCategoryRoot = true
        });

        if(!LoadExpenseData(DateOnly.FromDateTime(PickedDate))) {
            #if DEBUG
                System.Console.WriteLine($"[Warning]            |----> No data loaded or found.");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[OK]                 |----> Data Successfully loaded.");
            #endif
        }
    }

    [RelayCommand]
    public void AddCategory(CategoryViewModel RootCategory) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    \"ExpenseViewModel.AddCategory(ExpenseViewModel RootCategory)\" function Called");
        #endif

        if (RootCategory is null) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]          |----> RootCategory = null.");
            #endif
            return;
        }

        int nextNumber = RootCategory.Children.Count + 1;

        #if DEBUG
            System.Console.WriteLine($"                 |----> RootCategory = {RootCategory}."); 
        #endif

        if(RootCategory.Name is "Apartment") {
            RootCategory.Children.Add(new ApartmentViewModel(new Apartment()) {
                Name = $"{RootCategory.Name} {nextNumber}",
                CanDelete = true,
            });
            
            #if DEBUG
                System.Console.WriteLine($"[OK]             |----> RootCategory type is of \"ApartmentViewModel\".");
                System.Console.WriteLine($"                             |----> New child category {RootCategory.Children.FirstOrDefault( f => f.Name == "{RootCategory.Name} {nextNumber}")?.Name} added to root category {RootCategory.Name}.");
                System.Console.WriteLine($"                             |----> New count is = {nextNumber}.");
            #endif

        } else if(RootCategory.Name is "Entertainment") {
            RootCategory.Children.Add(new EntertainmentViewModel(new Entertainment()) {
                Name = $"{RootCategory.Name} {nextNumber}",
                CanDelete = true,
            });

            #if DEBUG
                System.Console.WriteLine($"[OK]             |----> RootCategory type is of \"EntertainmentViewModel\".");
                System.Console.WriteLine($"                             |----> New child category {RootCategory.Children.FirstOrDefault( f => f.Name == "{RootCategory.Name} {nextNumber}")?.Name} added to root category {RootCategory.Name}.");
                System.Console.WriteLine($"                             |----> New count is = {nextNumber}");
            #endif

        } else if(RootCategory.Name is "Groceries") {
            RootCategory.Children.Add(new GroceriesViewModel(new Grocery()) {
                Name = $"{RootCategory.Name} {nextNumber}",
                CanDelete = true,
            });

            #if DEBUG
                System.Console.WriteLine($"[OK]             |----> RootCategory type is of \"GroceriesViewModel\".");
                System.Console.WriteLine($"                             |----> New child category {RootCategory.Children.FirstOrDefault( f => f.Name == "{RootCategory.Name} {nextNumber}")?.Name} added to root category {RootCategory.Name}.");
                System.Console.WriteLine($"                             |----> New count is = {nextNumber}");
            #endif

        } else if(RootCategory.Name is "Personal care & grooming") {
            RootCategory.Children.Add(new PersonalCareGroomingViewModel(new PersonalCareGrooming()) {
                Name = $"{RootCategory.Name} {nextNumber}",
                CanDelete = true,
            });

            #if DEBUG
                System.Console.WriteLine($"[OK]             |----> RootCategory type is of \"PersonalCareGroomingViewModel\".");
                System.Console.WriteLine($"                             |----> New child category {RootCategory.Children.FirstOrDefault( f => f.Name == "{RootCategory.Name} {nextNumber}")?.Name} added to root category {RootCategory.Name}.");
                System.Console.WriteLine($"                             |----> New count is = {nextNumber}");
            #endif

        } else if(RootCategory.Name is "Vehicle") {
            RootCategory.Children.Add(new VehicleViewModel(new Vehicle()) {
                Name = $"{RootCategory.Name} {nextNumber}",
                CanDelete = true,
            });
            
            #if DEBUG
                System.Console.WriteLine($"[OK]             |----> RootCategory type is of \"VehicleViewModel\".");
                System.Console.WriteLine($"                             |----> New child category {RootCategory.Children.FirstOrDefault( f => f.Name == "{RootCategory.Name} {nextNumber}")?.Name} added to root category {RootCategory.Name}.");
                System.Console.WriteLine($"                             |----> New count is = {nextNumber}");
            #endif

        } else if(RootCategory.Name is "Miscellaneous") {
            RootCategory.Children.Add(new ExpenseMiscellaneousViewModel(new ExpenseMiscellaneous()) {
                Name = $"{RootCategory.Name} {nextNumber}",
                CanDelete = true,
            });
            
            #if DEBUG
                System.Console.WriteLine($"[OK]             |----> RootCategory type is of \"ExpenseMiscellaneousViewModel\".");
                System.Console.WriteLine($"                             |----> New child category {RootCategory.Children.FirstOrDefault( f => f.Name == "{RootCategory.Name} {nextNumber}")?.Name} added to root category {RootCategory.Name}.");
                System.Console.WriteLine($"                             |----> New count is = {nextNumber}");
            #endif

        }

        #if DEBUG
            System.Console.WriteLine();
        #endif
    }

    [RelayCommand]
    public void RemoveCategory(CategoryViewModel category) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    \"ExpenseViewModel.RemoveCategory(ExpenseViewModel category)\" function is triggered.");
            System.Console.WriteLine($"                |----> Searching for parent category ...");
        #endif

        var parentCategory = Categories.FirstOrDefault(x => x.IsCategoryRoot && x.Children.Contains(category));

        if (parentCategory == null) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]         |----> Variable \"parentCategory\" = null.");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]            |----> Parent category found: \"{parentCategory.Name}\" is parent category of \"{category.Name}\".");
        #endif
        bool error = parentCategory.Children.Remove(category);

        #if DEBUG
            if(error == true) {
                System.Console.WriteLine($"[OK]    Child category \"{category.Name}\" removed from \"{parentCategory.Name}\".");
            } else {
                System.Console.WriteLine($"[ERROR] Child category \"{category.Name}\" could NOT be removed from \"{parentCategory.Name}\".");
                return;
            }
        #endif

        if (SelectedCategory == category) {
            SelectedCategory = null;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]    \"{category.Name}\" unselected.");
            #endif
        }
        #if DEBUG
            System.Console.WriteLine($"");
        #endif
    }
}