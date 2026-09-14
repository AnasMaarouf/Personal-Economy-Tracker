using Avalonia.Controls;
using Personal_Economy_Display.ViewModels;

namespace Personal_Economy_Display.Views;
public partial class WorkView : UserControl {
    public WorkView() {
        InitializeComponent();
    }

    private void CalculateTotal(WorkViewModel viewModel) {
        viewModel._work.Total   = 0;
        viewModel._work.Total  += viewModel._work.Salary;
        viewModel._work.Total  += viewModel._work.Bonus;
        viewModel.Total_TextBox = viewModel._work.Total;
    }

    private void Company_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"WorkView.Company_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is WorkViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in WorkView.axaml.cs is WorkViewModel.");
            #endif
            
            viewModel._work.Company = viewModel.Company_TextBox;
            viewModel.Name = $"{viewModel._work.Company} - {viewModel._work.Position}";
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _work.Company object type \"{viewModel._work.Company.GetType()}\" matches \"{viewModel.Company_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> Company succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.Company_TextBox: {viewModel.Company_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._work.Company:   {viewModel._work.Company}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in WorkView.axaml.cs IS NOT WorkViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Position_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"WorkView.Position_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is WorkViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in WorkView.axaml.cs is WorkViewModel.");
            #endif
            
            viewModel._work.Position = viewModel.Position_TextBox;
            viewModel.Name = $"{viewModel._work.Company} - {viewModel._work.Position}";
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _work object type \"{viewModel._work.GetType()}\" matches \"{viewModel.Position_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> Position succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.Position_TextBox: {viewModel.Position_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._work.Position:   {viewModel._work.Position}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in WorkView.axaml.cs IS NOT WorkViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Salary_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"WorkView.Salary_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is WorkViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in WorkView.axaml.cs is WorkViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._work.Salary = viewModel.Salary_TextBox;
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> WorkView.Salary_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                        System.Console.WriteLine($"[OK]                     |----> _work.Salary object type \"{viewModel._work.Salary.GetType()}\" matches \"{viewModel.Salary_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                     |----> Salary succesfully changed:");
                        System.Console.WriteLine($"                                     |----> viewModel.Salary_TextBox: {viewModel.Salary_TextBox}");
                        System.Console.WriteLine($"                                     |----> viewModel._work.Salary:   {viewModel._work.Salary}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Salary_TextBox = 0;
                    viewModel._work.Salary = 0;

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> WorkView.Salary_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in WorkView.axaml.cs IS NOT WorkViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Bonus_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"WorkView.Bonus_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is WorkViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in WorkView.axaml.cs is WorkViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._work.Bonus = viewModel.Bonus_TextBox;
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> WorkView.Bonus_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                        System.Console.WriteLine($"[OK]                     |----> _work.Bonus object type \"{viewModel._work.Bonus.GetType()}\" matches \"{viewModel.Bonus_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                     |----> Bonus succesfully changed:");
                        System.Console.WriteLine($"                                     |----> viewModel.Bonus_TextBox: {viewModel.Bonus_TextBox}");
                        System.Console.WriteLine($"                                     |----> viewModel._work.Bonus:   {viewModel._work.Bonus}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Bonus_TextBox = 0;
                    viewModel._work.Bonus = 0;

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> WorkView.Bonus_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in WorkView.axaml.cs IS NOT WorkViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void TaxedAmount_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"WorkView.TaxedAmount_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is WorkViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in WorkView.axaml.cs is WorkViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._work.TaxedAmount = viewModel.TaxedAmount_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> WorkView.TaxedAmount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                        System.Console.WriteLine($"[OK]                     |----> _work.TaxedAmount object type \"{viewModel._work.TaxedAmount.GetType()}\" matches \"{viewModel.TaxedAmount_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                     |----> TaxedAmount succesfully changed:");
                        System.Console.WriteLine($"                                     |----> viewModel.TaxedAmount_TextBox: {viewModel.TaxedAmount_TextBox}");
                        System.Console.WriteLine($"                                     |----> viewModel._work.TaxedAmount:   {viewModel._work.TaxedAmount}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.TaxedAmount_TextBox = 0;
                    viewModel._work.TaxedAmount = 0;

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> WorkView.TaxedAmount_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in WorkView.axaml.cs IS NOT WorkViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Total_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"WorkView.Total_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is WorkViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in WorkView.axaml.cs is WorkViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._work.Total = viewModel.Total_TextBox;
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> WorkView.Total_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                        System.Console.WriteLine($"[OK]                     |----> _work.Total object type \"{viewModel._work.Total.GetType()}\" matches \"{viewModel.Total_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                     |----> Total succesfully changed:");
                        System.Console.WriteLine($"                                     |----> viewModel.Total_TextBox: {viewModel.Total_TextBox}");
                        System.Console.WriteLine($"                                     |----> viewModel._work.Total:   {viewModel._work.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Total_TextBox = 0;
                    viewModel._work.Total = 0;

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> WorkView.Total_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in WorkView.axaml.cs IS NOT WorkViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Note_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"WorkView.Note_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is WorkViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in WorkView.axaml.cs is WorkViewModel.");
            #endif
            
            viewModel._work.Note = viewModel.Note_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _work.Note object type \"{viewModel._work.Note.GetType()}\" matches \"{viewModel.Note_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> Note succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.Note_TextBox: {viewModel.Note_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._work.Note:   {viewModel._work.Note}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in WorkView.axaml.cs IS NOT WorkViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

}
