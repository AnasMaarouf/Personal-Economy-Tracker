
using Avalonia.Controls;
using Personal_Economy_Display.ViewModels;

namespace Personal_Economy_Display.Views;

public partial class PersonalCareGroomingView : UserControl {
    public PersonalCareGroomingView() {
        InitializeComponent();
    }

    private void CalculateTotal(PersonalCareGroomingViewModel viewModel) {
        viewModel._personalCareGrooming.Total = 0;
        viewModel._personalCareGrooming.Total +=  viewModel._personalCareGrooming.HealthInsurance.Amount;
        viewModel._personalCareGrooming.Total +=  viewModel._personalCareGrooming.LifeInsurance.Amount;
        viewModel._personalCareGrooming.Total +=  viewModel._personalCareGrooming.HygieneProducts;
        viewModel._personalCareGrooming.Total +=  viewModel._personalCareGrooming.Clothes;
        viewModel._personalCareGrooming.Total +=  viewModel._personalCareGrooming.Haircuts;
        viewModel.Total_TextBox = viewModel._personalCareGrooming.Total;
    }

    private void HealthInsurance_Company_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.HealthInsurance_Company_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            viewModel._personalCareGrooming.HealthInsurance.Company = viewModel.HealthInsurance_Company_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _personalCareGrooming.HealthInsurance.Company object type \"{viewModel._personalCareGrooming.HealthInsurance.Company.GetType()}\" matches \"{viewModel.HealthInsurance_Company_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> HealthInsurance_Company succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.HealthInsurance_Company_TextBox:        {viewModel.HealthInsurance_Company_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.HealthInsurance.Company:    {viewModel._personalCareGrooming.HealthInsurance.Company}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void HealthInsurance_Type_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.HealthInsurance_Type_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            viewModel._personalCareGrooming.HealthInsurance.Type = viewModel.HealthInsurance_Type_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _personalCareGrooming.HealthInsurance object type \"{viewModel._personalCareGrooming.HealthInsurance.GetType()}\" matches \"{viewModel.HealthInsurance_Type_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> HealthInsurance succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.HealthInsurance_Type_TextBox:        {viewModel.HealthInsurance_Type_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.HealthInsurance:    {viewModel._personalCareGrooming.HealthInsurance}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void HealthInsurance_Amount_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.HealthInsurance_Amount_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._personalCareGrooming.HealthInsurance.Amount = viewModel.HealthInsurance_Amount_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> PersonalCareGroomingView.HealthInsurance_Amount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _personalCareGrooming.HealthInsurance.Amount object type \"{viewModel._personalCareGrooming.HealthInsurance.Amount.GetType()}\" matches \"{viewModel.HealthInsurance_Amount_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> HealthInsurance_Amount succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.HealthInsurance_Amount_TextBox:       {viewModel.HealthInsurance_Amount_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.HealthInsurance.Amount:   {viewModel._personalCareGrooming.HealthInsurance.Amount}");
                        System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.Total:       {viewModel._personalCareGrooming.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.HealthInsurance_Amount_TextBox = 0;
                    viewModel._personalCareGrooming.HealthInsurance.Amount = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> PersonalCareGroomingView.HealthInsurance_Amount_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void HealthInsurance_Note_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.HealthInsurance_Note_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            viewModel._personalCareGrooming.HealthInsurance.Note = viewModel.HealthInsurance_Note_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _personalCareGrooming.HealthInsurance.Note object type \"{viewModel._personalCareGrooming.HealthInsurance.Note.GetType()}\" matches \"{viewModel.HealthInsurance_Note_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> HealthInsurance_Note succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.HealthInsurance_Note_TextBox:        {viewModel.HealthInsurance_Note_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.HealthInsurance.Note:    {viewModel._personalCareGrooming.HealthInsurance.Note}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }


    private void LifeInsurance_Company_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.LifeInsurance_Company_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            viewModel._personalCareGrooming.LifeInsurance.Company = viewModel.LifeInsurance_Company_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _personalCareGrooming.LifeInsurance.Company object type \"{viewModel._personalCareGrooming.LifeInsurance.Company.GetType()}\" matches \"{viewModel.LifeInsurance_Company_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> LifeInsurance_Company succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.LifeInsurance_Company_TextBox:        {viewModel.LifeInsurance_Company_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.LifeInsurance.Company:    {viewModel._personalCareGrooming.LifeInsurance.Company}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void LifeInsurance_Type_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.LifeInsurance_Type_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            viewModel._personalCareGrooming.LifeInsurance.Type = viewModel.LifeInsurance_Type_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _personalCareGrooming.LifeInsurance.Type object type \"{viewModel._personalCareGrooming.LifeInsurance.Type.GetType()}\" matches \"{viewModel.LifeInsurance_Type_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> LifeInsurance_Type succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.LifeInsurance_Type_TextBox:        {viewModel.LifeInsurance_Type_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.LifeInsurance.Type:    {viewModel._personalCareGrooming.LifeInsurance.Type}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void LifeInsurance_Amount_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.LifeInsurance_Amount_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._personalCareGrooming.LifeInsurance.Amount = viewModel.LifeInsurance_Amount_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> PersonalCareGroomingView.LifeInsuranceAmount_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _personalCareGrooming.LifeInsurance.Amount object type \"{viewModel._personalCareGrooming.LifeInsurance.Amount.GetType()}\" matches \"{viewModel.LifeInsurance_Amount_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> LifeInsurance_Amount succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.LifeInsurance_Amount_TextBox:       {viewModel.LifeInsurance_Amount_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.LifeInsurance.Amount:   {viewModel._personalCareGrooming.LifeInsurance.Amount}");
                        System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.Total:       {viewModel._personalCareGrooming.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.LifeInsurance_Amount_TextBox = 0;
                    viewModel._personalCareGrooming.LifeInsurance.Amount = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> PersonalCareGroomingView.LifeInsurance_Amount_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void LifeInsurance_Note_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.LifeInsurance_Note_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            viewModel._personalCareGrooming.LifeInsurance.Note = viewModel.LifeInsurance_Note_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> _personalCareGrooming.LifeInsurance.Note object type \"{viewModel._personalCareGrooming.LifeInsurance.Note.GetType()}\" matches \"{viewModel.LifeInsurance_Note_TextBox.GetType()}\".");
                System.Console.WriteLine($"[OK]                             |----> LifeInsurance_Note succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.LifeInsurance_Note_TextBox:        {viewModel.LifeInsurance_Note_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.LifeInsurance.Note:    {viewModel._personalCareGrooming.LifeInsurance.Note}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }


    private void HygieneProducts_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.HygieneProducts_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._personalCareGrooming.HygieneProducts = viewModel.HygieneProducts_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> PersonalCareGroomingView.HygieneProducts_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _personalCareGrooming.HygieneProducts object type \"{viewModel._personalCareGrooming.HygieneProducts.GetType()}\" matches \"{viewModel.HygieneProducts_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> HygieneProducts succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.HygieneProducts_TextBox:       {viewModel.HygieneProducts_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.HygieneProducts:   {viewModel._personalCareGrooming.HygieneProducts}");
                        System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.Total:       {viewModel._personalCareGrooming.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.HygieneProducts_TextBox = 0;
                    viewModel._personalCareGrooming.HygieneProducts = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> PersonalCareGroomingView.HygieneProducts_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }


    private void Clothes_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.Clothes_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._personalCareGrooming.Clothes = viewModel.Clothes_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> HygieneProducts_TextBox.Clothes_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _personalCareGrooming.Clothes object type \"{viewModel._personalCareGrooming.Clothes.GetType()}\" matches \"{viewModel.Clothes_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Clothes succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Clothes_TextBox:     {viewModel.Clothes_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.Clothes: {viewModel._personalCareGrooming.Clothes}");
                        System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.Total:   {viewModel._personalCareGrooming.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Clothes_TextBox = 0;
                    viewModel._personalCareGrooming.Clothes = 0;

                    CalculateTotal(viewModel);


                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> PersonalCareGroomingView.Clothes_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Haircuts_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.Haircuts_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._personalCareGrooming.Haircuts = viewModel.Haircuts_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> PersonalCareGroomingView.Haircuts_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> _personalCareGrooming.Haircuts object type \"{viewModel._personalCareGrooming.Haircuts.GetType()}\" matches \"{viewModel.Haircuts_TextBox.GetType()}\".");
                        System.Console.WriteLine($"[OK]                             |----> Haircuts succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Haircuts_TextBox:     {viewModel.Haircuts_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.Haircuts: {viewModel._personalCareGrooming.Haircuts}");
                        System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.Total:    {viewModel._personalCareGrooming.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Haircuts_TextBox = 0;
                    viewModel._personalCareGrooming.Haircuts = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> PersonalCareGroomingView.Haircuts_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Total_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.Total_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._personalCareGrooming.Total = viewModel.Total_TextBox;
                    
                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> Total_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);
                    
                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Total succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Total_TextBox:        {viewModel.Total_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.Total:    {viewModel._personalCareGrooming.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Total_TextBox = 0;
                    viewModel._personalCareGrooming.Total = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> PersonalCareGroomingView.Total_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Note_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"PersonalCareGroomingView.NoteTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is PersonalCareGroomingViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in PersonalCareGroomingView.axaml.cs is PersonalCareGroomingViewModel.");
            #endif
            
            viewModel._personalCareGrooming.Note = viewModel.Note_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> Note succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.NoteTextBox:        {viewModel.Note_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._personalCareGrooming.Note:    {viewModel._personalCareGrooming.Note}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in PersonalCareGroomingView.axaml.cs IS NOT PersonalCareGroomingViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

}