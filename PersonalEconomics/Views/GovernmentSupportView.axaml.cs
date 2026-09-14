using Avalonia.Controls;
using Personal_Economy_Display.ViewModels;

namespace Personal_Economy_Display.Views;
public partial class GovernmentSupportView : UserControl {
    public GovernmentSupportView() {
        InitializeComponent();
    }

    private void GovernmentName_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GovernmentSupportView.GovernmentName_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GovernmentSupportViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GovernmentSupportView.axaml.cs is GovernmentSupportViewModel.");
            #endif
            
            viewModel._governmentSupport.GovernmentName = viewModel.GovernmentName_TextBox;
            viewModel.Name = $"{viewModel._governmentSupport.GovernmentName} - {viewModel._governmentSupport.SupportType}";
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _governmentSupport.GovernmentName object type \"{viewModel._governmentSupport.GovernmentName.GetType()}\" matches \"{viewModel.GovernmentName_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> GovernmentName succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.GovernmentName_TextBox:            {viewModel.GovernmentName_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._governmentSupport.GovernmentName: {viewModel._governmentSupport.GovernmentName}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GovernmentSupportView.axaml.cs IS NOT GovernmentSupportViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void SupportType_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GovernmentSupportView.SupportType_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GovernmentSupportViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GovernmentSupportView.axaml.cs is GovernmentSupportViewModel.");
            #endif
            
            viewModel._governmentSupport.SupportType = viewModel.SupportType_TextBox;
            viewModel.Name = $"{viewModel._governmentSupport.GovernmentName} - {viewModel._governmentSupport.SupportType}";
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _governmentSupport object type \"{viewModel._governmentSupport.GetType()}\" matches \"{viewModel.SupportType_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> SupportType succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.SupportType_TextBox:            {viewModel.SupportType_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._governmentSupport.SupportType: {viewModel._governmentSupport.SupportType}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GovernmentSupportView.axaml.cs IS NOT GovernmentSupportViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Amount_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GovernmentSupportView.Amount_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GovernmentSupportViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GovernmentSupportView.axaml.cs is GovernmentSupportViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._governmentSupport.Amount = viewModel.Amount_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> GovernmentSupportView.Amount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                        System.Console.WriteLine($"[OK]                     |----> _governmentSupport.Amount object type \"{viewModel._governmentSupport.Amount.GetType()}\" matches \"{viewModel.Amount_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                     |----> Amount succesfully changed:");
                        System.Console.WriteLine($"                                     |----> viewModel.Amount_TextBox:            {viewModel.Amount_TextBox}");
                        System.Console.WriteLine($"                                     |----> viewModel._governmentSupport.Amount: {viewModel._governmentSupport.Amount}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Amount_TextBox = 0;
                    viewModel._governmentSupport.Amount = 0;

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> GovernmentSupportView.Amount_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GovernmentSupportView.axaml.cs IS NOT GovernmentSupportViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Note_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GovernmentSupportView.Note_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GovernmentSupportViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GovernmentSupportView.axaml.cs is GovernmentSupportViewModel.");
            #endif
            
            viewModel._governmentSupport.Note = viewModel.Note_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _governmentSupport.Note object type \"{viewModel._governmentSupport.Note.GetType()}\" matches \"{viewModel.Note_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> Note succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.Note_TextBox:            {viewModel.Note_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._governmentSupport.Note: {viewModel._governmentSupport.Note}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GovernmentSupportView.axaml.cs IS NOT GovernmentSupportViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

}
