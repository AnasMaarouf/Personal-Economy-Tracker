using CommunityToolkit.Mvvm.ComponentModel;
namespace Personal_Economy_Display.ViewModels;
public partial class GovernmentSupportViewModel : CategoryViewModel {
    static int instances = 0;
    public GovernmentSupport _governmentSupport;
    public GovernmentSupportViewModel(GovernmentSupport GovernmentSupport) {
        instances++;
        _governmentSupport = GovernmentSupport;
        
        GovernmentName_TextBox  = GovernmentSupport.GovernmentName;
        SupportType_TextBox  = GovernmentSupport.SupportType;
        Amount_TextBox  = GovernmentSupport.Amount;
        Note_TextBox  = GovernmentSupport.Note;
    }

    [ObservableProperty]
    public partial string GovernmentName_TextBox{ get; set; }
    [ObservableProperty]
    public partial string SupportType_TextBox   { get; set; }
    [ObservableProperty]
    public partial double Amount_TextBox        { get; set; }
    [ObservableProperty]
    public partial string Note_TextBox           { get; set; }

}