using CommunityToolkit.Mvvm.ComponentModel;

namespace Personal_Economy_Display.ViewModels;

public partial class GroceriesViewModel : CategoryViewModel {
    static int instances = 0;
    public Grocery _groceries;
    public GroceriesViewModel(Grocery Groceries) {
        instances++;
        _groceries = Groceries;
        
        VegetablesTextBox = Groceries.Vegetables;
        CannedProductsTextBox = Groceries.CannedProducts;
        HouseholdItemsTextBox = Groceries.HouseholdItems;
        OtherItemsTextBox = Groceries.OtherItems;
        CandyTextBox = Groceries.Candy;
        SodaTextBox  = Groceries.Soda;
        MeatTextBox  = Groceries.Meat;
        FishTextBox  = Groceries.Fish;
        TotalTextBox = Groceries.Total;
        NoteTextBox  = Groceries.Note;
    }

    [ObservableProperty]
    public partial double VegetablesTextBox     { get; set; }
    [ObservableProperty]
    public partial double MeatTextBox           { get; set; }
    [ObservableProperty]
    public partial double FishTextBox           { get; set; }
    [ObservableProperty]
    public partial double CannedProductsTextBox { get; set; }
    [ObservableProperty]
    public partial double CandyTextBox          { get; set; }
    [ObservableProperty]
    public partial double SodaTextBox           { get; set; }
    [ObservableProperty]
    public partial double HouseholdItemsTextBox { get; set; }
    [ObservableProperty]
    public partial double OtherItemsTextBox     { get; set; }
    [ObservableProperty]
    public partial double TotalTextBox          { get; set; }
    [ObservableProperty]
    public partial string NoteTextBox           { get; set; }
}
