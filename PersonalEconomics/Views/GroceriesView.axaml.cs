using Avalonia.Controls;
using Personal_Economy_Display.ViewModels;

namespace Personal_Economy_Display.Views;

public partial class GroceriesView : UserControl {
    public GroceriesView() {
        InitializeComponent();
    }

    private void CalculateTotal(GroceriesViewModel viewModel) {
        viewModel._groceries.Total = 0;
        viewModel._groceries.Total +=  viewModel._groceries.Vegetables;
        viewModel._groceries.Total +=  viewModel._groceries.Meat;
        viewModel._groceries.Total +=  viewModel._groceries.Fish;
        viewModel._groceries.Total +=  viewModel._groceries.CannedProducts;
        viewModel._groceries.Total +=  viewModel._groceries.Candy;
        viewModel._groceries.Total +=  viewModel._groceries.Soda;
        viewModel._groceries.Total +=  viewModel._groceries.HouseholdItems;
        viewModel._groceries.Total +=  viewModel._groceries.OtherItems;
        viewModel.TotalTextBox = viewModel._groceries.Total;
    }

    private void VegetablesTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GroceriesView.GroceriesView.VegetablesTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GroceriesViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GroceriesView.axaml.cs is GroceriesViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._groceries.Vegetables = viewModel.VegetablesTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> GroceriesView.VegetablesTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Vegetables succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.VegetablesTextBox:      {viewModel.VegetablesTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Vegetables:  {viewModel._groceries.Vegetables}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Total:       {viewModel._groceries.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.VegetablesTextBox = 0;
                    viewModel._groceries.Vegetables = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> GroceriesView.VegetablesTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GroceriesView.axaml.cs IS NOT GroceriesViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void MeatTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GroceriesView.MeatTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GroceriesViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GroceriesView.axaml.cs is GroceriesViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._groceries.Meat = viewModel.MeatTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> GroceriesView.MeatTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Meat succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.MeatTextBox:      {viewModel.MeatTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Meat:  {viewModel._groceries.Meat}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Total: {viewModel._groceries.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.MeatTextBox = 0;
                    viewModel._groceries.Meat = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> GroceriesView.MeatTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GroceriesView.axaml.cs IS NOT GroceriesViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void FishTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GroceriesView.FishTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GroceriesViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GroceriesView.axaml.cs is GroceriesViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._groceries.Fish = viewModel.FishTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> GroceriesView.FishTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Fish succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.FishTextBox:      {viewModel.FishTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Fish:  {viewModel._groceries.Fish}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Total: {viewModel._groceries.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.FishTextBox = 0;
                    viewModel._groceries.Fish = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> GroceriesView.FishTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GroceriesView.axaml.cs IS NOT GroceriesViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void CannedProductsTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GroceriesView.CannedProductsTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GroceriesViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GroceriesView.axaml.cs is GroceriesViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._groceries.CannedProducts = viewModel.CannedProductsTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> GroceriesView.CannedProductsTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> CannedProducts succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.CannedProductsTextBox:      {viewModel.CannedProductsTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.CannedProducts:  {viewModel._groceries.CannedProducts}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Total:           {viewModel._groceries.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.CannedProductsTextBox = 0;
                    viewModel._groceries.CannedProducts = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> GroceriesView.CannedProductsTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GroceriesView.axaml.cs IS NOT GroceriesViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void CandyTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GroceriesView.CandyTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GroceriesViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GroceriesView.axaml.cs is GroceriesViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._groceries.Candy = viewModel.CandyTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> GroceriesView.CandyTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Candy succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.CandyTextBox:      {viewModel.CandyTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Candy:  {viewModel._groceries.Candy}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Total:  {viewModel._groceries.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.CandyTextBox = 0;
                    viewModel._groceries.Candy = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> GroceriesView.CandyTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GroceriesView.axaml.cs IS NOT GroceriesViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void SodaTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GroceriesView.SodaTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GroceriesViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GroceriesView.axaml.cs is GroceriesViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._groceries.Soda = viewModel.SodaTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> GroceriesView.SodaTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Soda succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.SodaTextBox:      {viewModel.SodaTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Soda:  {viewModel._groceries.Soda}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Total: {viewModel._groceries.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.SodaTextBox = 0;
                    viewModel._groceries.Soda = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> GroceriesView.SodaTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GroceriesView.axaml.cs IS NOT GroceriesViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void HouseholdItemsTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GroceriesView.HouseholdItemsTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GroceriesViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GroceriesView.axaml.cs is GroceriesViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._groceries.HouseholdItems = viewModel.HouseholdItemsTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> GroceriesView.HouseholdItemsTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> HouseholdItems succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.HouseholdItemsTextBox:      {viewModel.HouseholdItemsTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.HouseholdItems:  {viewModel._groceries.HouseholdItems}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Total:           {viewModel._groceries.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.HouseholdItemsTextBox = 0;
                    viewModel._groceries.HouseholdItems = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> GroceriesView.HouseholdItemsTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GroceriesView.axaml.cs IS NOT GroceriesViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void OtherItemsTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GroceriesView.GroceriesView.OtherItemsTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GroceriesViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GroceriesView.axaml.cs is GroceriesViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._groceries.OtherItems = viewModel.OtherItemsTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> GroceriesView.OtherItemsTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> OtherItems succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.OtherItemsTextBox:      {viewModel.OtherItemsTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.OtherItems:  {viewModel._groceries.OtherItems}");
                        System.Console.WriteLine($"                                             |----> viewModel._groceries.Total:       {viewModel._groceries.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.OtherItemsTextBox = 0;
                    viewModel._groceries.OtherItems = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> GroceriesView.OtherItemsTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GroceriesView.axaml.cs IS NOT GroceriesViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void NoteTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"GroceriesView.NoteTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is GroceriesViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in GroceriesView.axaml.cs is GroceriesViewModel.");
            #endif
            
            viewModel._groceries.Note = viewModel.NoteTextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> Note succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.NoteTextBox:        {viewModel.NoteTextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._groceries.Note:    {viewModel._groceries.Note}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in GroceriesView.axaml.cs IS NOT GroceriesViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }
}