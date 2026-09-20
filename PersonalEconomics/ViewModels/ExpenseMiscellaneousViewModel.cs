using CommunityToolkit.Mvvm.ComponentModel;

namespace Personal_Economy_Display.ViewModels;

public partial class ExpenseMiscellaneousViewModel : CategoryViewModel {
    static int instances = 0;
    public ExpenseMiscellaneous _expenseMiscellaneous;
    public ExpenseMiscellaneousViewModel(ExpenseMiscellaneous ExpenseMiscellaneous) {
        instances++;
        
        _expenseMiscellaneous = ExpenseMiscellaneous;
        PhoneSubscription_TextBox = _expenseMiscellaneous.PhoneSubscription;
        FitnessSubscription_TextBox = _expenseMiscellaneous.FitnessSubscription;
        TakeoutFood_TextBox = _expenseMiscellaneous.TakeoutFood;
        Electronics_TextBox = _expenseMiscellaneous.Electronics;
        Other_TextBox = _expenseMiscellaneous.Other;
        Total_TextBox = _expenseMiscellaneous.Total;
        Note_TextBox = _expenseMiscellaneous.Note;
    }

    [ObservableProperty]
    public partial double PhoneSubscription_TextBox{ get; set; }

    [ObservableProperty]
    public partial double FitnessSubscription_TextBox{ get; set; }

    [ObservableProperty]
    public partial double TakeoutFood_TextBox{ get; set; }

    [ObservableProperty]
    public partial double Electronics_TextBox{ get; set; }

    [ObservableProperty]
    public partial double Other_TextBox      { get; set; }

    [ObservableProperty]
    public partial double Total_TextBox      { get; set; }

    [ObservableProperty]
    public partial string Note_TextBox       { get; set; }
}
