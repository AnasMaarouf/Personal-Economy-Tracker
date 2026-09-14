
using Avalonia.Controls;
using Personal_Economy_Display.ViewModels;

namespace Personal_Economy_Display.Views;

public partial class VehicleView : UserControl {
    private void CalculateTotal(VehicleViewModel viewModel) {
        viewModel._vehicle.Total = 0;
        viewModel._vehicle.Total +=  viewModel._vehicle.VehicleInsurance.Amount;
        viewModel._vehicle.Total +=  viewModel._vehicle.Fuel;
        viewModel._vehicle.Total +=  viewModel._vehicle.Maintenance;
        viewModel._vehicle.Total +=  viewModel._vehicle.Repairs;
        viewModel.Total_TextBox = viewModel._vehicle.Total;
    }

    public VehicleView() {
        InitializeComponent();
    }

    private void VehicleInsurance_Company_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"VehicleInsurance_Company_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is VehicleViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in VehicleView.axaml.cs is VehicleViewModel.");
            #endif
            
            viewModel._vehicle.VehicleInsurance.Company = viewModel.VehicleInsurance_Company_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _vehicle.VehicleInsurance.Company object type \"{viewModel._vehicle.VehicleInsurance.Company.GetType()}\" matches \"{viewModel.VehicleInsurance_Company_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> VehicleInsurance_Company succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.VehicleInsurance_Company_TextBox:   {viewModel.VehicleInsurance_Company_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._vehicle.VehicleInsurance.Company:  {viewModel._vehicle.VehicleInsurance.Company}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in VehicleView.axaml.cs IS NOT VehicleViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void VehicleInsurance_Type_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"VehicleInsurance_Type_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is VehicleViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in VehicleView.axaml.cs is VehicleViewModel.");
            #endif
            
            viewModel._vehicle.VehicleInsurance.Type = viewModel.VehicleInsurance_Type_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _vehicle.VehicleInsurance object type \"{viewModel._vehicle.VehicleInsurance.GetType()}\" matches \"{viewModel.VehicleInsurance_Type_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> VehicleInsurance succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.VehicleInsurance_Type_TextBox:  {viewModel.VehicleInsurance_Type_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._vehicle.VehicleInsurance:      {viewModel._vehicle.VehicleInsurance}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in VehicleView.axaml.cs IS NOT VehicleViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void VehicleInsurance_Amount_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"VehicleInsurance_Amount_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is VehicleViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in VehicleView.axaml.cs is VehicleViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._vehicle.VehicleInsurance.Amount = viewModel.VehicleInsurance_Amount_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> VehicleView.VehicleInsurance_Amount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _vehicle.VehicleInsurance.Amount object type \"{viewModel._vehicle.VehicleInsurance.Amount.GetType()}\" matches \"{viewModel.VehicleInsurance_Amount_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> VehicleInsurance_Amount succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.VehicleInsurance_Amount_TextBox:    {viewModel.VehicleInsurance_Amount_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._vehicle.VehicleInsurance.Amount:   {viewModel._vehicle.VehicleInsurance.Amount}");
                        System.Console.WriteLine($"                                             |----> viewModel._vehicle.Total: {viewModel._vehicle.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.VehicleInsurance_Amount_TextBox = 0;
                    viewModel._vehicle.VehicleInsurance.Amount = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> VehicleView.VehicleInsurance_Amount_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in VehicleView.axaml.cs IS NOT VehicleViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void VehicleInsurance_Note_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"VehicleInsurance_Note_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is VehicleViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in VehicleView.axaml.cs is VehicleViewModel.");
            #endif
            
            viewModel._vehicle.VehicleInsurance.Note = viewModel.VehicleInsurance_Note_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _vehicle.VehicleInsurance.Note object type \"{viewModel._vehicle.VehicleInsurance.Note.GetType()}\" matches \"{viewModel.VehicleInsurance_Note_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> VehicleInsurance_Note succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.VehicleInsurance_Note_TextBox:  {viewModel.VehicleInsurance_Note_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._vehicle.VehicleInsurance.Note: {viewModel._vehicle.VehicleInsurance.Note}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in VehicleView.axaml.cs IS NOT VehicleViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }



    private void Model_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"Model_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is VehicleViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in VehicleView.axaml.cs is VehicleViewModel.");
            #endif
            
            viewModel._vehicle.Model = viewModel.Model_TextBox;
            viewModel.Name = $"{viewModel._vehicle.Model} - {viewModel._vehicle.NumberPlate}";
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _vehicle.Model object type \"{viewModel._vehicle.Model.GetType()}\" matches \"{viewModel.Model_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> Model succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.Model_TextBox:  {viewModel.Model_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._vehicle.Model: {viewModel._vehicle.Model}");
            #endif

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in VehicleView.axaml.cs IS NOT VehicleViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void NumberPlate_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"NumberPlate_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is VehicleViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in VehicleView.axaml.cs is VehicleViewModel.");
            #endif
            
            viewModel._vehicle.NumberPlate = viewModel.NumberPlate_TextBox;
            viewModel.Name = $"{viewModel._vehicle.Model} - {viewModel._vehicle.NumberPlate}";
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _vehicle.NumberPlate object type \"{viewModel._vehicle.NumberPlate.GetType()}\" matches \"{viewModel.NumberPlate_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> NumberPlate succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.NumberPlate_TextBox:    {viewModel.NumberPlate_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._vehicle.NumberPlate:   {viewModel._vehicle.NumberPlate}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in VehicleView.axaml.cs IS NOT VehicleViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Fuel_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"Fuel_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is VehicleViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in VehicleView.axaml.cs is VehicleViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._vehicle.Fuel = viewModel.Fuel_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> VehicleView.Fuel_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _vehicle.Fuel object type \"{viewModel._vehicle.Fuel.GetType()}\" matches \"{viewModel.Fuel_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Fuel succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Fuel_TextBox:   {viewModel.Fuel_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._vehicle.Fuel:  {viewModel._vehicle.Fuel}");
                        System.Console.WriteLine($"                                             |----> viewModel._vehicle.Total: {viewModel._vehicle.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Fuel_TextBox = 0;
                    viewModel._vehicle.Fuel = 0;

                    CalculateTotal(viewModel);


                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> VehicleView.Fuel_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in VehicleView.axaml.cs IS NOT VehicleViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Maintenance_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"Maintenance_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is VehicleViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in VehicleView.axaml.cs is VehicleViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._vehicle.Maintenance = viewModel.Maintenance_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> VehicleView.Maintenance_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _vehicle.Maintenance object type \"{viewModel._vehicle.Maintenance.GetType()}\" matches \"{viewModel.Maintenance_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Maintenance succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Maintenance_TextBox:    {viewModel.Maintenance_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._vehicle.Maintenance:   {viewModel._vehicle.Maintenance}");
                        System.Console.WriteLine($"                                             |----> viewModel._vehicle.Total:         {viewModel._vehicle.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Maintenance_TextBox = 0;
                    viewModel._vehicle.Maintenance = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> VehicleView.Maintenance_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in VehicleView.axaml.cs IS NOT VehicleViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

private void Repairs_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"Repairs_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is VehicleViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in VehicleView.axaml.cs is VehicleViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._vehicle.Repairs = viewModel.Repairs_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> VehicleView.Repairs_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _vehicle.Repairs object type \"{viewModel._vehicle.Repairs.GetType()}\" matches \"{viewModel.Repairs_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Repairs succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Repairs_TextBox:    {viewModel.Repairs_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._vehicle.Repairs:   {viewModel._vehicle.Repairs}");
                        System.Console.WriteLine($"                                             |----> viewModel._vehicle.Total:     {viewModel._vehicle.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Repairs_TextBox = 0;
                    viewModel._vehicle.Repairs = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> VehicleView.Repairs_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in VehicleView.axaml.cs IS NOT VehicleViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Total_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"Total_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is VehicleViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in VehicleView.axaml.cs is VehicleViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._vehicle.Total = viewModel.Total_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> VehicleView.Total_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);
                    
                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Total succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Total_TextBox:  {viewModel.Total_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._vehicle.Total: {viewModel._vehicle.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Total_TextBox = 0;
                    viewModel._vehicle.Total = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> VehicleView.Total_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in VehicleView.axaml.cs IS NOT VehicleViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Note_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"NoteTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is VehicleViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in VehicleView.axaml.cs is VehicleViewModel.");
            #endif
            
            viewModel._vehicle.Note = viewModel.Note_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> Note succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.NoteTextBox:    {viewModel.Note_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._vehicle.Note:  {viewModel._vehicle.Note}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in VehicleView.axaml.cs IS NOT VehicleViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

}