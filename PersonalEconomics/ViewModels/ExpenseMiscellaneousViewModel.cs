using CommunityToolkit.Mvvm.ComponentModel;

namespace Personal_Economy_Display.ViewModels;

public partial class ExpenseMiscellaneousViewModel : CategoryViewModel {
    static int instances = 0;
    public ExpenseMiscellaneous _expenseMiscellaneous;
    public ExpenseMiscellaneousViewModel(ExpenseMiscellaneous ExpenseMiscellaneous) {
        instances++;
        
        _expenseMiscellaneous = ExpenseMiscellaneous;
        TakeoutFood_TextBox = _expenseMiscellaneous.TakeoutFood;
        Electronics_TextBox = _expenseMiscellaneous.Electronics;
        Total_TextBox = _expenseMiscellaneous.Total;
        Note_TextBox = _expenseMiscellaneous.Note;
    }
    [ObservableProperty]
    public partial double TakeoutFood_TextBox{ get; set; }

    [ObservableProperty]
    public partial double Electronics_TextBox{ get; set; }

    [ObservableProperty]
    public partial double Total_TextBox      { get; set; }
    [ObservableProperty]
    public partial string Note_TextBox       { get; set; }
}
