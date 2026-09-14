using System.Linq;
using Avalonia.Controls;
using Personal_Economy_Display.ViewModels;

namespace Personal_Economy_Display.Views;


public partial class ApartmentView : UserControl {
    public ApartmentView() {
        InitializeComponent();
    }
    private void CalculateTotal(ApartmentViewModel viewModel) {
        viewModel._apartment.Total = 0;
        viewModel._apartment.Utilities.Total = 0;
        viewModel._apartment.Utilities.Total += viewModel._apartment.Utilities.WaterBill;
        viewModel._apartment.Utilities.Total += viewModel._apartment.Utilities.HeatingBill;
        viewModel._apartment.Utilities.Total += viewModel._apartment.Utilities.InternetBill;
        viewModel._apartment.Utilities.Total += viewModel._apartment.Utilities.LaundromatSubscription;
        viewModel._apartment.Utilities.Total += viewModel._apartment.Utilities.ElectricityBill;
        viewModel._apartment.Total +=  viewModel._apartment.Utilities.Total;

        foreach (var insurance in viewModel._apartment.Insurances) {
            viewModel._apartment.Total += insurance.Amount;
        }

        viewModel._apartment.Total +=  viewModel._apartment.Furniture;
        viewModel._apartment.Total +=  viewModel._apartment.Repairs;
        viewModel._apartment.Total +=  viewModel._apartment.Mortgage;
        viewModel._apartment.Total +=  viewModel._apartment.Rent;
        viewModel.TotalTextBox = viewModel._apartment.Total;
    }

    private void LandlordTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.LandlordTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            
            viewModel._apartment.Landlord = viewModel.LandlordTextBox;
            viewModel.Name = $"{viewModel._apartment.Landlord} - {viewModel._apartment.Address}";
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _apartment.Landlord object type \"{viewModel._apartment.Landlord.GetType()}\" matches \"{viewModel.LandlordTextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> Landlord succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.LandlordTextBox:        {viewModel.LandlordTextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._apartment.Landlord:    {viewModel._apartment.Landlord}");
            #endif

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void AddressTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.AddressTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            
            viewModel._apartment.Address = viewModel.AddressTextBox;
            viewModel.Name = $"{viewModel._apartment.Landlord} - {viewModel._apartment.Address}";
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _apartment.Address object type \"{viewModel._apartment.Address.GetType()}\" matches \"{viewModel.AddressTextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> Address succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.AddressTextBox:        {viewModel.AddressTextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._apartment.Address:    {viewModel._apartment.Address}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void FurnitureTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.FurnitureTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._apartment.Furniture = viewModel.FurnitureTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ApartmentView.InsuranceAmount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _apartment.Furniture object type \"{viewModel._apartment.Furniture.GetType()}\" matches \"{viewModel.FurnitureTextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Furniture succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.FurnitureTextBox:       {viewModel.FurnitureTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Furniture:   {viewModel._apartment.Furniture}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Total:       {viewModel._apartment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.FurnitureTextBox = 0;
                    viewModel._apartment.Furniture = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ApartmentView.FurnitureTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void RepairsTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.RepairsTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._apartment.Repairs = viewModel.RepairsTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ApartmentView.InsuranceAmount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _apartment.Repairs object type \"{viewModel._apartment.Repairs.GetType()}\" matches \"{viewModel.RepairsTextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Repairs succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.RepairsTextBox:     {viewModel.RepairsTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Repairs: {viewModel._apartment.Repairs}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Total:   {viewModel._apartment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.RepairsTextBox = 0;
                    viewModel._apartment.Repairs = 0;

                    CalculateTotal(viewModel);


                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ApartmentView.RepairsTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void MortgageTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.MortgageTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._apartment.Mortgage = viewModel.MortgageTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ApartmentView.InsuranceAmount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _apartment.Mortgage object type \"{viewModel._apartment.Mortgage.GetType()}\" matches \"{viewModel.MortgageTextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Mortgage succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.MortgageTextBox:     {viewModel.MortgageTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Mortgage: {viewModel._apartment.Mortgage}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Total:    {viewModel._apartment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.MortgageTextBox = 0;
                    viewModel._apartment.Mortgage = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ApartmentView.MortgageTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void RentTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.RentTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._apartment.Rent = viewModel.RentTextBox;
                    
                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ApartmentView.InsuranceAmount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);
                    
                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _apartment.Rent object type \"{viewModel._apartment.Rent.GetType()}\" matches \"{viewModel.RentTextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Rent succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.RentTextBox:        {viewModel.RentTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Rent:    {viewModel._apartment.Rent}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Total:   {viewModel._apartment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.RentTextBox = 0;
                    viewModel._apartment.Rent = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ApartmentView.RentTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void NoteTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.NoteTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            
            viewModel._apartment.Note = viewModel.NoteTextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _apartment.NoteTextBox object type \"{viewModel._apartment.Note.GetType()}\" matches \"{viewModel.NoteTextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> Note succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.NoteTextBox:        {viewModel.NoteTextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._apartment.Note:    {viewModel._apartment.Note}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

#region Utilities
    /*
    ********************************************************************************************************
    *********************************            Utilities Section           *******************************
    *********************************            Utilities Section           *******************************
    ********************************************************************************************************
    */
    private void Utilities_WaterTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.Utilities_WaterTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._apartment.Utilities.WaterBill = viewModel.Utilities_WaterTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ApartmentView.InsuranceAmount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _apartment.Utilities.WaterBill object type \"{viewModel._apartment.Utilities.WaterBill.GetType()}\" matches \"{viewModel.Utilities_WaterTextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Utilities.WaterBill succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Utilities_WaterTextBox:         {viewModel.Utilities_WaterTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Utilities.WaterBill: {viewModel._apartment.Utilities.WaterBill}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Utilities.Total:     {viewModel._apartment.Utilities.Total}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Total:               {viewModel._apartment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Utilities_WaterTextBox = 0;
                    viewModel._apartment.Utilities.WaterBill = 0;
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ApartmentView.Utilities_WaterTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Utilities_HeatingTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.Utilities_HeatingTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._apartment.Utilities.HeatingBill = viewModel.Utilities_HeatingTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ApartmentView.InsuranceAmount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _apartment.Utilities.HeatingBill object type \"{viewModel._apartment.Utilities.HeatingBill.GetType()}\" matches \"{viewModel.Utilities_HeatingTextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Utilities.HeatingBill succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Utilities_HeatingTextBox:         {viewModel.Utilities_HeatingTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Utilities.HeatingBill: {viewModel._apartment.Utilities.HeatingBill}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Utilities.Total:       {viewModel._apartment.Utilities.Total}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Total:                 {viewModel._apartment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Utilities_HeatingTextBox = 0;
                    viewModel._apartment.Utilities.HeatingBill = 0;
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ApartmentView.Utilities_HeatingTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Utilities_InternetTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.Utilities_InternetTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._apartment.Utilities.InternetBill = viewModel.Utilities_InternetTextBox;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ApartmentView.InsuranceAmount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _apartment.Utilities.InternetBill object type \"{viewModel._apartment.Utilities.InternetBill.GetType()}\" matches \"{viewModel.Utilities_InternetTextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Utilities.InternetBill succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Utilities_InternetTextBox:          {viewModel.Utilities_InternetTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Utilities.InternetBill:  {viewModel._apartment.Utilities.InternetBill}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Utilities.Total:         {viewModel._apartment.Utilities.Total}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Total:                   {viewModel._apartment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Utilities_InternetTextBox = 0;
                    viewModel._apartment.Utilities.InternetBill = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ApartmentView.Utilities_InternetTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Utilities_LaundromatTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.Utilities_LaundromatTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._apartment.Utilities.LaundromatSubscription = viewModel.Utilities_LaundromatTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ApartmentView.InsuranceAmount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _apartment.Utilities.LaundromatSubscribtion object type \"{viewModel._apartment.Utilities.LaundromatSubscription.GetType()}\" matches \"{viewModel.Utilities_LaundromatTextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Utilities.LaundromatSubscribtion succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Utilities_LaundromatTextBox:                    {viewModel.Utilities_LaundromatTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Utilities.LaundromatSubscribtion:    {viewModel._apartment.Utilities.LaundromatSubscription}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Utilities.Total:                     {viewModel._apartment.Utilities.Total}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Total:                               {viewModel._apartment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Utilities_LaundromatTextBox = 0;
                    viewModel._apartment.Utilities.LaundromatSubscription = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ApartmentView.Utilities_LaundromatTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Utilities_ElectricityTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.Utilities_ElectricityTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._apartment.Utilities.ElectricityBill = viewModel.Utilities_ElectricityTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ApartmentView.InsuranceAmount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _apartment.Utilities.ElectricityBill object type \"{viewModel._apartment.Utilities.ElectricityBill.GetType()}\" matches \"{viewModel.Utilities_ElectricityTextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Utilities.ElectricityBill succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Utilities.ElectricityBill:   {viewModel._apartment.Utilities.ElectricityBill}");
                        System.Console.WriteLine($"                                             |----> viewModel.Utilities_ElectricityTextBox:           {viewModel.Utilities_ElectricityTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Utilities.Total:             {viewModel._apartment.Utilities.Total}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Total:                       {viewModel._apartment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Utilities_ElectricityTextBox = 0;
                    viewModel._apartment.Utilities.ElectricityBill = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ApartmentView.Utilities_ElectricityTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Utilities_NoteTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.Utilities_NoteTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            
            viewModel._apartment.Utilities.Note = viewModel.Utilities_NoteTextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _apartment.Utilities.Note object type \"{viewModel._apartment.Utilities.Note.GetType()}\" matches \"{viewModel.Utilities_NoteTextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> Utilities.Note succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.Utilities_NoteTextBox:        {viewModel.Utilities_NoteTextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._apartment.Utilities.Note:    {viewModel._apartment.Utilities.Note}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }
#endregion

#region Insurance Section
    /*
    ********************************************************************************************************
    *********************************            Insurance Section           *******************************
    *********************************            Insurance Section           *******************************
    ********************************************************************************************************
    */
    private void SelectedHomeInsurancesExpenseListBox_SelectionChanged(object? sender, SelectionChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.SelectedHomeInsurancesExpenseListBox_SelectionChanged(object? sender, SelectionChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif

            if (e.Source is ListBox listBox) {
                #if DEBUG
                    System.Console.WriteLine($"[OK]         |----> Event source is \"ListBox\".");
                #endif

                if ((viewModel.SelectedHomeInsurancesExpenseListBox is Insurance insurance) && (viewModel.SelectedHomeInsurancesExpenseListBox is not null)) {
                    viewModel.InsuranceSectionVisible = true;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                     |----> Insurance section set to be visible.");
                        System.Console.WriteLine($"                         |           |----> ApartmentViewModel.InsuranceSectionVisible = true");
                        System.Console.WriteLine($"                         |");
                        System.Console.WriteLine($"[OK]                     |----> Selected item type \"{viewModel.SelectedHomeInsurancesExpenseListBox.GetType()}\" is \"{insurance.GetType()}\".");
                        System.Console.WriteLine($"                                     |----> Insurance company:    {viewModel.SelectedHomeInsurancesExpenseListBox.Company}");
                        System.Console.WriteLine($"                                     |----> Insurance type:       {viewModel.SelectedHomeInsurancesExpenseListBox.Type}");
                        System.Console.WriteLine($"                                     |----> Insurance amount:     {viewModel.SelectedHomeInsurancesExpenseListBox.Amount}");
                        System.Console.WriteLine($"                                     |----> Insurance note:       {viewModel.SelectedHomeInsurancesExpenseListBox.Note}");
                    #endif
                    viewModel.InsuranceCompany_TextBox  = viewModel.SelectedHomeInsurancesExpenseListBox.Company;
                    viewModel.InsuranceType_TextBox     = viewModel.SelectedHomeInsurancesExpenseListBox.Type;
                    viewModel.InsuranceAmount_TextBox   = viewModel.SelectedHomeInsurancesExpenseListBox.Amount;
                    viewModel.InsuranceNote_TextBox     = viewModel.SelectedHomeInsurancesExpenseListBox.Note;

                } else {
                    #if DEBUG
                        if(viewModel.SelectedHomeInsurancesExpenseListBox is not null) {
                            System.Console.WriteLine($"[ERROR]                  |----> Selected item does not belong to \"CategoryViewModel\".");
                            System.Console.WriteLine($"                                     |----> \"SelectedItem\" = \"{viewModel.SelectedHomeInsurancesExpenseListBox.GetType()}\".");
                        } else {
                            System.Console.WriteLine($"                         |----> No items selected.");
                            System.Console.WriteLine($"                                     |----> viewModel.SelectedHomeInsurancesExpenseListBox is 'null'.");
                        }
                        System.Console.WriteLine($"");
                    #endif
                    viewModel.InsuranceSectionVisible = false;
                    return;
                }
            } else {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]      |----> Event source type IS NOT \"TreeView\".");
                #endif
            }
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"");
        #endif
    }

    private void InsuranceCompany_TextBox_TextChanged(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.InsuranceCompany_TextBox_TextChanged(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is not ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
        #endif

        if ((viewModel.SelectedHomeInsurancesExpenseListBox is Insurance insurance) && (viewModel.SelectedHomeInsurancesExpenseListBox is not null)) {
            #if DEBUG
                System.Console.WriteLine($"[OK]                     |----> viewModel.SelectedHomeInsurancesExpenseListBox object type \"{viewModel.SelectedHomeInsurancesExpenseListBox.GetType()}\" matches \"{insurance.GetType()}\".");
            #endif

            viewModel.SelectedHomeInsurancesExpenseListBox.Company = viewModel.InsuranceCompany_TextBox;
            viewModel._apartment.Insurances.First(  sel =>
                sel.Type == viewModel.SelectedHomeInsurancesExpenseListBox.Type &&
                sel.Amount == viewModel.SelectedHomeInsurancesExpenseListBox.Amount &&
                sel.Note == viewModel.SelectedHomeInsurancesExpenseListBox.Note
            ).Company = viewModel.InsuranceCompany_TextBox;

            if((insurance.Company is string) && (viewModel.InsuranceCompany_TextBox is string)) {
                #if DEBUG
                    System.Console.WriteLine($"[OK]                             |----> Insurance.Company object type \"{insurance.Company.GetType()}\" matches \"{viewModel.InsuranceCompany_TextBox}\".");
                    System.Console.WriteLine($"[OK]                             |----> Company succesfully changed:");
                    System.Console.WriteLine($"                                             |----> viewModel.SelectedHomeInsurancesExpenseListBox.Company: {viewModel.SelectedHomeInsurancesExpenseListBox.Company}");
                    System.Console.WriteLine($"                                             |----> viewModel._apartment.Insurances.Company:  {viewModel._apartment.Insurances.First(sel => sel.Type == viewModel.SelectedHomeInsurancesExpenseListBox.Type && sel.Amount == viewModel.SelectedHomeInsurancesExpenseListBox.Amount && sel.Note == viewModel.SelectedHomeInsurancesExpenseListBox.Note).Company}");
                    System.Console.WriteLine($"                                             |----> viewModel.InsuranceCompany_TextBox:       {viewModel.InsuranceCompany_TextBox}");
                #endif
            } else {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                          |----> Insurance.Company object type \"{insurance.Company.GetType()}\" DOES NOT match \"{viewModel.SelectedHomeInsurancesExpenseListBox.GetType()}\".");
                    System.Console.WriteLine($"[ERROR]                          |----> viewModel.SelectedHomeInsurancesExpenseListBox.Company UNSUCCESSFULLY changed to \"{viewModel.InsuranceCompany_TextBox}\"");
                    System.Console.WriteLine($"");
                #endif
                return;
            }
        
        } else {
            #if DEBUG
                if (viewModel.SelectedHomeInsurancesExpenseListBox is not null)
                    System.Console.WriteLine($"[ERROR]                  |----> viewModel.SelectedHomeInsurancesExpenseListBox object type \"{viewModel.SelectedHomeInsurancesExpenseListBox.GetType()}\" DOES NOT match \"Insurance\".");
                else
                    System.Console.WriteLine($"[ERROR]                  |----> viewModel.SelectedHomeInsurancesExpenseListBox is 'null'.");

                System.Console.WriteLine($"");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine($"");
        #endif
    }

    private void InsuranceType_TextBox_TextChanged(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.InsuranceType_TextBox_TextChanged(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is not ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
        #endif

        if ((viewModel.SelectedHomeInsurancesExpenseListBox is Insurance insurance) && (viewModel.SelectedHomeInsurancesExpenseListBox is not null)) {
            #if DEBUG
                System.Console.WriteLine($"[OK]                     |----> viewModel.SelectedHomeInsurancesExpenseListBox object type \"{viewModel.SelectedHomeInsurancesExpenseListBox.GetType()}\" matches \"{insurance.GetType()}\".");
            #endif
            
            viewModel.SelectedHomeInsurancesExpenseListBox.Type = viewModel.InsuranceType_TextBox;
            viewModel._apartment.Insurances.First(  sel =>
                sel.Company == viewModel.SelectedHomeInsurancesExpenseListBox.Company   &&
                sel.Amount  == viewModel.SelectedHomeInsurancesExpenseListBox.Amount    &&
                sel.Note    == viewModel.SelectedHomeInsurancesExpenseListBox.Note
            ).Type = viewModel.InsuranceType_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> Insurance.Type object type \"{insurance.Type.GetType()}\" matches \"{viewModel.InsuranceType_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> Type succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.SelectedHomeInsurancesExpenseListBox.Type: {viewModel.SelectedHomeInsurancesExpenseListBox.Type}");
                System.Console.WriteLine($"                                             |----> viewModel.ThisApartment.Insurances.Type:  {viewModel.Insurances.First(sel => sel.Company == viewModel.SelectedHomeInsurancesExpenseListBox.Company && sel.Amount == viewModel.SelectedHomeInsurancesExpenseListBox.Amount && sel.Note == viewModel.SelectedHomeInsurancesExpenseListBox.Note).Type}");
                System.Console.WriteLine($"                                             |----> viewModel.InsuranceType_TextBox:          {viewModel.InsuranceType_TextBox}");
            #endif
            
        } else {
            #if DEBUG
                if (viewModel.SelectedHomeInsurancesExpenseListBox is not null)
                    System.Console.WriteLine($"[ERROR]                  |----> viewModel.SelectedHomeInsurancesExpenseListBox object type \"{viewModel.SelectedHomeInsurancesExpenseListBox.GetType()}\" DOES NOT match \"Insurance\".");
                else
                    System.Console.WriteLine($"[ERROR]                  |----> viewModel.SelectedHomeInsurancesExpenseListBox is 'null'.");

                System.Console.WriteLine($"");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine($"");
        #endif
    }

    private void InsuranceAmount_TextBox_TextChanged(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.InsuranceAmount_TextBox_TextChanged(object? sender, SelectionChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is not ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
        #endif

        if(e.Source is TextBox textBox) {
            if (double.TryParse(textBox.Text, out double amount)) {
                // Valid value Insurance
                textBox.Text = amount.ToString();
                viewModel.InsuranceAmount_TextBox = amount;

                #if DEBUG
                    System.Console.WriteLine($"[OK]         |----> ApartmentView.InsuranceAmount_TextBox string to double parse/cast is valid.");
                    System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                #endif
                if (viewModel.SelectedHomeInsurancesExpenseListBox is Insurance insurance) {
                    #if DEBUG
                        System.Console.WriteLine($"[OK]                     |----> viewModel.SelectedHomeInsurancesExpenseListBox object type \"{viewModel.SelectedHomeInsurancesExpenseListBox.GetType()}\" matches \"{insurance.GetType()}\".");
                    #endif

                    viewModel.SelectedHomeInsurancesExpenseListBox.Amount = viewModel.InsuranceAmount_TextBox;
                    viewModel._apartment.Insurances.First( sel =>
                        sel.Type    == viewModel.SelectedHomeInsurancesExpenseListBox.Type      &&
                        sel.Company == viewModel.SelectedHomeInsurancesExpenseListBox.Company   &&
                        sel.Note    == viewModel.SelectedHomeInsurancesExpenseListBox.Note
                    ).Amount = viewModel.InsuranceAmount_TextBox;
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Insurance.Amount object type \"{insurance.Amount.GetType()}\" matches \"{viewModel.InsuranceAmount_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Amount succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.SelectedHomeInsurancesExpenseListBox.Amount: {viewModel.SelectedHomeInsurancesExpenseListBox.Amount}");
                        System.Console.WriteLine($"                                             |----> viewModel.InsuranceAmount_TextBox:        {viewModel.InsuranceAmount_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel.Insurances.Amount:              {viewModel.Insurances.First(sel => sel.Type == viewModel.SelectedHomeInsurancesExpenseListBox.Type && sel.Company == viewModel.SelectedHomeInsurancesExpenseListBox.Company && sel.Note == viewModel.SelectedHomeInsurancesExpenseListBox.Note).Amount}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Insurances.Amount:   {viewModel._apartment.Insurances.First(sel => sel.Type == viewModel.SelectedHomeInsurancesExpenseListBox.Type && sel.Company == viewModel.SelectedHomeInsurancesExpenseListBox.Company && sel.Note == viewModel.SelectedHomeInsurancesExpenseListBox.Note).Amount}");
                        System.Console.WriteLine($"                                             |----> viewModel._apartment.Total:               {viewModel._apartment.Total}");
                    #endif
                } else {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]                  |----> viewModel.SelectedHomeInsurancesExpenseListBox object type \"{viewModel.SelectedHomeInsurancesExpenseListBox?.GetType()}\" DOES NOT match \"Insurance\".");
                        System.Console.WriteLine($"");
                    #endif
                    return;
                }
            } else {
                // Invalid/empty input - don't throw
                textBox.Text = "0";
                viewModel.InsuranceAmount_TextBox = 0;
                if (viewModel.SelectedHomeInsurancesExpenseListBox is Insurance insurance) {
                    viewModel._apartment.Insurances.First( sel =>
                        sel.Type    == viewModel.SelectedHomeInsurancesExpenseListBox.Type      &&
                        sel.Company == viewModel.SelectedHomeInsurancesExpenseListBox.Company   &&
                        sel.Note    == viewModel.SelectedHomeInsurancesExpenseListBox.Note
                    ).Amount = 0;
                }

                CalculateTotal(viewModel);
                
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]      |----> ApartmentView.InsuranceAmount_TextBox string to double parse/cast is INVALID.");
                    System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                #endif
            }
        }

        #if DEBUG
            System.Console.WriteLine($"");
        #endif
    }


    private void InsuranceNote_TextBox_TextChanged(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ApartmentView.InsuranceNote_TextBox_TextChanged(object? sender, SelectionChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ApartmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ApartmentView.axaml.cs is ApartmentViewModel.");
            #endif
            if(viewModel.SelectedHomeInsurancesExpenseListBox is not null) {
                viewModel.SelectedHomeInsurancesExpenseListBox.Note = viewModel.InsuranceNote_TextBox ?? string.Empty;
                
                viewModel._apartment.Insurances.First( sel =>
                    sel.Company == viewModel.SelectedHomeInsurancesExpenseListBox.Company   &&
                    sel.Type    == viewModel.SelectedHomeInsurancesExpenseListBox.Type      &&
                    sel.Amount  == viewModel.SelectedHomeInsurancesExpenseListBox.Amount
                ).Note = viewModel.InsuranceNote_TextBox ?? string.Empty;

                if((viewModel.SelectedHomeInsurancesExpenseListBox.Note is string) && (viewModel.InsuranceNote_TextBox is string)) {
                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Insurance.Note object type \"{viewModel.SelectedHomeInsurancesExpenseListBox.Note.GetType()}\" matches \"{viewModel.InsuranceNote_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Note succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.InsuranceNote_TextBox: {viewModel.InsuranceNote_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel.SelectedHomeInsurancesExpenseListBox.Note: {viewModel.SelectedHomeInsurancesExpenseListBox.Note}");
                        System.Console.WriteLine($"                                             |----> viewModel.Insurances.Note: {viewModel.Insurances.First(sel => sel.Company == viewModel.SelectedHomeInsurancesExpenseListBox.Company && sel.Type == viewModel.SelectedHomeInsurancesExpenseListBox.Type && sel.Amount == viewModel.SelectedHomeInsurancesExpenseListBox.Amount).Note}");
                    #endif
                } else {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]                          |----> Insurance.Note object type \"{viewModel.SelectedHomeInsurancesExpenseListBox.Note.GetType()}\" DOES NOT match \"{viewModel.SelectedHomeInsurancesExpenseListBox.GetType()}\".");
                        System.Console.WriteLine($"[ERROR]                          |----> viewModel.SelectedHomeInsurancesExpenseListBox.Note UNSUCCESSFULLY changed to \"{viewModel.InsuranceNote_TextBox}\"");
                        System.Console.WriteLine($"");
                    #endif
                    return;
                }
            } else {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]      |----> viewModel.SelectedHomeInsurancesExpenseListBox = null.");
                #endif
                viewModel.InsuranceSectionVisible = false;
            }
            
            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ApartmentView.axaml.cs IS NOT ApartmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }
#endregion
}