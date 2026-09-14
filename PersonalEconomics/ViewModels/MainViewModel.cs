using System;
using System.Text.Json;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Personal_Economy_Display.ViewModels;

public partial class MainViewModel : ViewModelBase {
    
    [ObservableProperty]
    public partial string GeneralBackgroundColor { get; set; } = "#ffffffff";
    
    [ObservableProperty]
    public partial string DatePickerBackgroundColor { get; set; } = "#dddddddd";

    [ObservableProperty]
    public partial string AddEditDataButtonBackgroundColor { get; set; } = "#eeeeeeee";
    

    [ObservableProperty]
    public partial DateOnly DateToday { get; set; } = DateOnly.FromDateTime(DateTime.Now);
    [ObservableProperty]
    public partial string TodaysDateStr { get; set; } = DateOnly.FromDateTime(DateTime.Now).ToString();


    [ObservableProperty]
    public partial string[] Months { get; set; } = { };
    [ObservableProperty]
    public partial string[] Year { get; set; } = { };


}
