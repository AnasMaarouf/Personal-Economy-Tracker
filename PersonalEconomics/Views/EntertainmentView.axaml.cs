
using Avalonia.Controls;
using Personal_Economy_Display.ViewModels;

namespace Personal_Economy_Display.Views;

public partial class EntertainmentView : UserControl {
    public EntertainmentView() {
        InitializeComponent();
    }

    private void CalculateTotal(EntertainmentViewModel viewModel) {
        viewModel._entertainment.Total = 0;
        viewModel._entertainment.Total +=  viewModel._entertainment.StreamingServicesSubscriptions;
        viewModel._entertainment.Total +=  viewModel._entertainment.ConcertTickets;
        viewModel._entertainment.Total +=  viewModel._entertainment.SportingEvents;
        viewModel._entertainment.Total +=  viewModel._entertainment.Movies;
        viewModel._entertainment.Total +=  viewModel._entertainment.Books;
        viewModel._entertainment.Total +=  viewModel._entertainment.Hobbies;
        viewModel._entertainment.Total +=  viewModel._entertainment.Vacation;
        viewModel._entertainment.Total +=  viewModel._entertainment.BarHopping;
        viewModel.TotalTextBox = viewModel._entertainment.Total;
    }

    private void StreamingServicesSubscriptionsTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"EntertainmentView.StreamingServicesSubscriptionsTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is EntertainmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in EntertainmentView.axaml.cs is EntertainmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._entertainment.StreamingServicesSubscriptions = viewModel.StreamingServicesSubscriptionsTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> EntertainmentView.StreamingServicesSubscriptionsTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> StreamingServicesSubscriptions succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.StreamingServicesSubscriptionsTextBox:          {viewModel.StreamingServicesSubscriptionsTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.StreamingServicesSubscriptions:  {viewModel._entertainment.StreamingServicesSubscriptions}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.Total:                           {viewModel._entertainment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.StreamingServicesSubscriptionsTextBox = 0;
                    viewModel._entertainment.StreamingServicesSubscriptions = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> EntertainmentView.StreamingServicesSubscriptionsTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in EntertainmentView.axaml.cs IS NOT EntertainmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void BarHoppingTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"EntertainmentView.BarHoppingTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is EntertainmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in EntertainmentView.axaml.cs is EntertainmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._entertainment.BarHopping = viewModel.BarHoppingTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> EntertainmentView.BarHoppingTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> BarHopping succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.BarHoppingTextBox:         {viewModel.BarHoppingTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.BarHopping: {viewModel._entertainment.BarHopping}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.Total:      {viewModel._entertainment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.BarHoppingTextBox = 0;
                    viewModel._entertainment.BarHopping = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> EntertainmentView.BarHoppingTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in EntertainmentView.axaml.cs IS NOT EntertainmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void ConcertTicketsTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"EntertainmentView.ConcertTicketsTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is EntertainmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in EntertainmentView.axaml.cs is EntertainmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._entertainment.ConcertTickets = viewModel.ConcertTicketsTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> EntertainmentView.ConcertTicketsTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> ConcertTickets succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.ConcertTicketsTextBox:          {viewModel.ConcertTicketsTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.ConcertTickets:  {viewModel._entertainment.ConcertTickets}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.Total:           {viewModel._entertainment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.ConcertTicketsTextBox = 0;
                    viewModel._entertainment.ConcertTickets = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> EntertainmentView.ConcertTicketsTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in EntertainmentView.axaml.cs IS NOT EntertainmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void SportingEventsTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"EntertainmentView.SportingEventsTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is EntertainmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in EntertainmentView.axaml.cs is EntertainmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._entertainment.SportingEvents = viewModel.SportingEventsTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> EntertainmentView.SportingEventsTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> SportingEvents succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.SportingEventsTextBox:          {viewModel.SportingEventsTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.SportingEvents:  {viewModel._entertainment.SportingEvents}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.Total:           {viewModel._entertainment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.SportingEventsTextBox = 0;
                    viewModel._entertainment.SportingEvents = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> EntertainmentView.SportingEventsTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in EntertainmentView.axaml.cs IS NOT EntertainmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void MoviesTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"EntertainmentView.MoviesTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is EntertainmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in EntertainmentView.axaml.cs is EntertainmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._entertainment.Movies = viewModel.MoviesTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> EntertainmentView.MoviesTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Movies succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.MoviesTextBox:          {viewModel.MoviesTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.Movies:  {viewModel._entertainment.Movies}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.Total:   {viewModel._entertainment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.MoviesTextBox = 0;
                    viewModel._entertainment.Movies = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> EntertainmentView.MoviesTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in EntertainmentView.axaml.cs IS NOT EntertainmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void BooksTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"EntertainmentView.BooksTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is EntertainmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in EntertainmentView.axaml.cs is EntertainmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._entertainment.Books = viewModel.BooksTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> EntertainmentView.BooksTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Books succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.BooksTextBox:          {viewModel.BooksTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.Books:  {viewModel._entertainment.Books}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.Total:  {viewModel._entertainment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.BooksTextBox = 0;
                    viewModel._entertainment.Books = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> EntertainmentView.BooksTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in EntertainmentView.axaml.cs IS NOT EntertainmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void HobbiesTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"EntertainmentView.HobbiesTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is EntertainmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in EntertainmentView.axaml.cs is EntertainmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._entertainment.Hobbies = viewModel.HobbiesTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> EntertainmentView.HobbiesTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Hobbies succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.HobbiesTextBox:         {viewModel.HobbiesTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.Hobbies: {viewModel._entertainment.Hobbies}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.Total:   {viewModel._entertainment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.HobbiesTextBox = 0;
                    viewModel._entertainment.Hobbies = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> EntertainmentView.HobbiesTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in EntertainmentView.axaml.cs IS NOT EntertainmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void VacationTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"EntertainmentView.VacationTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is EntertainmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in EntertainmentView.axaml.cs is EntertainmentViewModel.");
            #endif
            
            if(e.Source is TextBox textBox) {
                if (double.TryParse(textBox.Text, out double amount)) {
                    // Valid value
                    textBox.Text = amount.ToString();
                    viewModel._entertainment.Vacation = viewModel.VacationTextBox;

                    #if DEBUG
                        System.Console.WriteLine($"[OK]         |----> EntertainmentView.VacationTextBox string to double parse/cast is valid.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                    
                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[OK]                             |----> Vacation succesfully changed:");
                        System.Console.WriteLine($"                                             |----> viewModel.VacationTextBox:            {viewModel.VacationTextBox}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.Vacation:    {viewModel._entertainment.Vacation}");
                        System.Console.WriteLine($"                                             |----> viewModel._entertainment.Total:       {viewModel._entertainment.Total}");
                        System.Console.WriteLine($"");
                    #endif

                } else {
                    // Invalid/empty input - don't throw
                    textBox.Text = "0";
                    viewModel.VacationTextBox = 0;
                    viewModel._entertainment.Vacation = 0;

                    CalculateTotal(viewModel);

                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]      |----> EntertainmentView.VacationTextBox string to double parse/cast is INVALID.");
                        System.Console.WriteLine($"                         |----> Text: {textBox.Text}");
                    #endif
                }
            }

            #if DEBUG
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in EntertainmentView.axaml.cs IS NOT EntertainmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

    private void NoteTextBox_changed(object? sender, TextChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"EntertainmentView.NoteTextBox_changed(object? sender, TextChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        if (DataContext is EntertainmentViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[OK]         |----> Datacontext in EntertainmentView.axaml.cs is EntertainmentViewModel.");
            #endif
            
            viewModel._entertainment.Note = viewModel.NoteTextBox;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]                             |----> Note succesfully changed:");
                System.Console.WriteLine($"                                             |----> viewModel.NoteTextBox:         {viewModel.NoteTextBox}");
                System.Console.WriteLine($"                                             |----> viewModel._entertainment.Note: {viewModel._entertainment.Note}");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]      |----> DataContext in EntertainmentView.axaml.cs IS NOT EntertainmentViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
    }

}