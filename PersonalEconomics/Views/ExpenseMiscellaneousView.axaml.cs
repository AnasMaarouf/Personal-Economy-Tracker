using System;
using Avalonia.Controls;
using Personal_Economy_Display.ViewModels;

namespace Personal_Economy_Display.Views;
public partial class ExpenseMiscellaneousView : UserControl {
    private void CalculateTotal(ExpenseMiscellaneousViewModel viewModel) {
        viewModel._expenseMiscellaneous.Total = 0;
        viewModel._expenseMiscellaneous.Total +=  viewModel._expenseMiscellaneous.PhoneSubscription;
        viewModel._expenseMiscellaneous.Total +=  viewModel._expenseMiscellaneous.FitnessSubscription;
        viewModel._expenseMiscellaneous.Total +=  viewModel._expenseMiscellaneous.TakeoutFood;
        viewModel._expenseMiscellaneous.Total +=  viewModel._expenseMiscellaneous.Electronics;
        viewModel._expenseMiscellaneous.Total +=  viewModel._expenseMiscellaneous.Other;
        
        viewModel.Total_TextBox = viewModel._expenseMiscellaneous.Total;
    }

    public ExpenseMiscellaneousView() {
        InitializeComponent();
    }


    private void PhoneSubscription_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ExpenseMiscellaneousView.PhoneSubscription_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ExpenseMiscellaneousViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ExpenseMiscellaneousView.axaml.cs is ExpenseMiscellaneousViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._expenseMiscellaneous.PhoneSubscription = viewModel.PhoneSubscription_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ExpenseMiscellaneousView.PhoneSubscription_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> PhoneSubscription succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.PhoneSubscription_TextBox:               {viewModel.PhoneSubscription_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._expenseMiscellaneous.PhoneSubscription: {viewModel._expenseMiscellaneous.PhoneSubscription}");
                        System.Console.WriteLine($"                                             |----> viewModel._expenseMiscellaneous.Total: {viewModel._expenseMiscellaneous.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.PhoneSubscription_TextBox = 0;
                    viewModel._expenseMiscellaneous.PhoneSubscription = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ExpenseMiscellaneousView.PhoneSubscription_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ExpenseMiscellaneousView.axaml.cs IS NOT ExpenseMiscellaneousViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void FitnessSubscription_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ExpenseMiscellaneousView.FitnessSubscription_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ExpenseMiscellaneousViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ExpenseMiscellaneousView.axaml.cs is ExpenseMiscellaneousViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._expenseMiscellaneous.FitnessSubscription = viewModel.FitnessSubscription_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ExpenseMiscellaneousView.FitnessSubscription_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> FitnessSubscription succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.FitnessSubscription_TextBox:               {viewModel.FitnessSubscription_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._expenseMiscellaneous.FitnessSubscription: {viewModel._expenseMiscellaneous.FitnessSubscription}");
                        System.Console.WriteLine($"                                             |----> viewModel._expenseMiscellaneous.Total: {viewModel._expenseMiscellaneous.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.FitnessSubscription_TextBox = 0;
                    viewModel._expenseMiscellaneous.FitnessSubscription = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ExpenseMiscellaneousView.FitnessSubscription_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ExpenseMiscellaneousView.axaml.cs IS NOT ExpenseMiscellaneousViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void TakeoutFood_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ExpenseMiscellaneousView.TakeoutFood_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ExpenseMiscellaneousViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ExpenseMiscellaneousView.axaml.cs is ExpenseMiscellaneousViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._expenseMiscellaneous.TakeoutFood = viewModel.TakeoutFood_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ExpenseMiscellaneousView.TakeoutFood_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> TakeoutFood succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.TakeoutFood_TextBox:               {viewModel.TakeoutFood_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._expenseMiscellaneous.TakeoutFood: {viewModel._expenseMiscellaneous.TakeoutFood}");
                        System.Console.WriteLine($"                                             |----> viewModel._expenseMiscellaneous.Total:       {viewModel._expenseMiscellaneous.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.TakeoutFood_TextBox = 0;
                    viewModel._expenseMiscellaneous.TakeoutFood = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ExpenseMiscellaneousView.TakeoutFood_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ExpenseMiscellaneousView.axaml.cs IS NOT ExpenseMiscellaneousViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Electronics_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ExpenseMiscellaneousView.Electronics_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ExpenseMiscellaneousViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ExpenseMiscellaneousView.axaml.cs is ExpenseMiscellaneousViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._expenseMiscellaneous.Electronics = viewModel.Electronics_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ExpenseMiscellaneousView.Electronics_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Electronics succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Electronics_TextBox:               {viewModel.Electronics_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._expenseMiscellaneous.Electronics: {viewModel._expenseMiscellaneous.Electronics}");
                        System.Console.WriteLine($"                                             |----> viewModel._expenseMiscellaneous.Total:       {viewModel._expenseMiscellaneous.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Electronics_TextBox = 0;
                    viewModel._expenseMiscellaneous.Electronics = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ExpenseMiscellaneousView.Electronics_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ExpenseMiscellaneousView.axaml.cs IS NOT ExpenseMiscellaneousViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Other_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ExpenseMiscellaneousView.Other_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ExpenseMiscellaneousViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ExpenseMiscellaneousView.axaml.cs is ExpenseMiscellaneousViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._expenseMiscellaneous.Other = viewModel.Other_TextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> ExpenseMiscellaneousView.Other_TextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Other succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.Other_TextBox:               {viewModel.Other_TextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._expenseMiscellaneous.Other: {viewModel._expenseMiscellaneous.Other}");
                        System.Console.WriteLine($"                                             |----> viewModel._expenseMiscellaneous.Total: {viewModel._expenseMiscellaneous.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.Other_TextBox = 0;
                    viewModel._expenseMiscellaneous.Other = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> ExpenseMiscellaneousView.Other_TextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ExpenseMiscellaneousView.axaml.cs IS NOT ExpenseMiscellaneousViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void Note_TextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"ExpenseMiscellaneousView.Note_TextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is ExpenseMiscellaneousViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in ExpenseMiscellaneousView.axaml.cs is ExpenseMiscellaneousViewModel.");
            #endif
            
            viewModel._expenseMiscellaneous.Note = viewModel.Note_TextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> Note succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.Note_TextBox:               {viewModel.Note_TextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._expenseMiscellaneous.Note: {viewModel._expenseMiscellaneous.Note}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in ExpenseMiscellaneousView.axaml.cs IS NOT ExpenseMiscellaneousViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

}
