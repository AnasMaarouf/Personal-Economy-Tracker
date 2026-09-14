using System;
using CommunityToolkit.Mvvm.ComponentModel;

namespace Personal_Economy_Display.ViewModels;

public partial class EntertainmentViewModel : CategoryViewModel {
    static int instances = 0;
    public Entertainment _entertainment;
    public EntertainmentViewModel(Entertainment Entertainment) {
        instances++;
        _entertainment = Entertainment;
        StreamingServicesSubscriptionsTextBox = Entertainment.StreamingServicesSubscriptions;
        ConcertTicketsTextBox = Entertainment.ConcertTickets;
        SportingEventsTextBox = Entertainment.SportingEvents;
        MoviesTextBox   = Entertainment.Movies;
        BooksTextBox    = Entertainment.Books;
        HobbiesTextBox  = Entertainment.Hobbies;
        VacationTextBox = Entertainment.Vacation;
        BarHoppingTextBox = Entertainment.BarHopping;
        TotalTextBox    = Entertainment.Total;
        NoteTextBox     = Entertainment.Note;
    }

    [ObservableProperty]
    public partial double StreamingServicesSubscriptionsTextBox { get; set; }
    [ObservableProperty]
    public partial double ConcertTicketsTextBox { get; set; }
    [ObservableProperty]
    public partial double SportingEventsTextBox { get; set; }
    [ObservableProperty]
    public partial double MoviesTextBox     { get; set; }
    [ObservableProperty]
    public partial double BooksTextBox      { get; set; }
    [ObservableProperty]
    public partial double HobbiesTextBox    { get; set; }
    [ObservableProperty]
    public partial double VacationTextBox   { get; set; }
    [ObservableProperty]
    public partial double BarHoppingTextBox   { get; set; }
    [ObservableProperty]
    public partial double TotalTextBox      { get; set; }
    [ObservableProperty]
    public partial string NoteTextBox       { get; set; }
}
