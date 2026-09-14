using CommunityToolkit.Mvvm.ComponentModel;
namespace Personal_Economy_Display.ViewModels;
public partial class WorkViewModel : CategoryViewModel {
    static int instances = 0;
    public Work _work;
    public WorkViewModel(Work Work) {
        instances++;
        
        _work = Work;
        
        Company_TextBox     = Work.Company;
        Position_TextBox    = Work.Position;
        Salary_TextBox      = Work.Salary;
        Bonus_TextBox       = Work.Bonus;
        TaxedAmount_TextBox = Work.TaxedAmount;
        Total_TextBox       = Work.Total;
        Note_TextBox        = Work.Note;
    }

    [ObservableProperty]
    public partial string Company_TextBox       { get; set; }
    [ObservableProperty]
    public partial string Position_TextBox      { get; set; }
    [ObservableProperty]
    public partial double Salary_TextBox        { get; set; }
    [ObservableProperty]
    public partial double Bonus_TextBox         { get; set; }
    [ObservableProperty]
    public partial double TaxedAmount_TextBox   { get; set; }
    [ObservableProperty]
    public partial double Total_TextBox         { get; set; }
    [ObservableProperty]
    public partial string Note_TextBox          { get; set; }

}