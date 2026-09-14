using System;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform.Storage;
using Personal_Economy_Display.ViewModels;
using Personal_Economy_Display;

namespace Personal_Economy_Display.Views;
public partial class ExpenseView : UserControl {
    public ExpenseView() {
        InitializeComponent();
        DataContext = new ExpenseViewModel();
    }
    private void AddEntryFiles_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]         Function \"ExpenseView.AddEntryExpense_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)\" Called.");
            System.Console.WriteLine($"                 |----> Sender:");
            System.Console.WriteLine($"                 |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"                 |          |----> Fullname:   {sender?.GetType().FullName}");
            System.Console.WriteLine($"                 |");
        #endif

        //  Checks if datacontext is set
        if (DataContext is not ExpenseViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]          |----> DataContext in ExpenseViewModel.axaml.cs IS NOT ExpenseViewModel.");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> Datacontext in ExpenseViewModel.axaml.cs is ExpenseViewModel.");
        #endif

        if(!Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}")) {
            #if DEBUG
                System.Console.WriteLine($"[WARNING]        |----> Directory does not exist.");
                System.Console.WriteLine($"                 |           |----> Directory: \"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}\"");
            #endif
            
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating directory ...");
                #endif
                
                Directory.CreateDirectory($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}");
                
                #if DEBUG
                    System.Console.WriteLine($"[OK]             |           |----> Directory successfully created.");
                #endif
            } catch(UnauthorizedAccessException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    UnauthorizedAccessException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentNullException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    ArgumentNullException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    ArgumentException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(PathTooLongException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    PathTooLongException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(DirectoryNotFoundException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    DirectoryNotFoundException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(NotSupportedException thrownException) {
                 #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    NotSupportedException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(IOException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    IOException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            }
        }

        if(!Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense")) {
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating subdirectory ...");
                    System.Console.WriteLine($"                 |           |           |----> Directory: DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense");
                    System.Console.WriteLine($"                 |           |");
                #endif
                
                Directory.CreateDirectory($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense");
            
                #if DEBUG
                    System.Console.WriteLine($"[OK]             |           |----> Directory successfully created.");
                    System.Console.WriteLine($"                 |           |");
                #endif
            } catch(UnauthorizedAccessException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    UnauthorizedAccessException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentNullException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    ArgumentNullException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    ArgumentException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(PathTooLongException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    PathTooLongException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(DirectoryNotFoundException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    DirectoryNotFoundException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(NotSupportedException thrownException) {
                 #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    NotSupportedException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(IOException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    IOException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            }
        }

        if(!Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Files")) {
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating subdirectory ...");
                    System.Console.WriteLine($"                 |           |           |----> Directory: \"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Files\"");
                    System.Console.WriteLine($"                 |           |");
                #endif
                
                Directory.CreateDirectory($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Files");
                
                #if DEBUG
                    System.Console.WriteLine($"[OK]             |           |----> Directory successfully created.");
                    System.Console.WriteLine($"                 |           |");
                #endif
            } catch(UnauthorizedAccessException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    UnauthorizedAccessException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentNullException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    ArgumentNullException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    ArgumentException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(PathTooLongException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    PathTooLongException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(DirectoryNotFoundException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    DirectoryNotFoundException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(NotSupportedException thrownException) {
                 #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    NotSupportedException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(IOException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    IOException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            }
        }


        // saves files to "Files" folder.
        string destinationDirectory = Path.Combine(
            "DataEntries",
            viewModel.PickedDate.Year.ToString(),
            viewModel.PickedDate.Month.ToString(),
            viewModel.PickedDate.Day.ToString(),
            "Expense",
            "Files"
        );

        Directory.CreateDirectory(destinationDirectory);

        foreach (var file in viewModel.Files)
        {
            string sourcePath = new Uri(file.FilePath).LocalPath;

            string destinationPath = Path.Combine(
                destinationDirectory,
                file.FileName
            );

            File.Copy(sourcePath, destinationPath, overwrite: true);
        }

        foreach (string filePath in Directory.EnumerateFiles(destinationDirectory))
        {
            string fileName = Path.GetFileName(filePath);

            bool shouldKeep = viewModel.Files.Any(x =>
                string.Equals(
                    x.FileName,
                    fileName,
                    StringComparison.OrdinalIgnoreCase));

            if (!shouldKeep)
            {
                File.Delete(filePath);
            }
        }



        if(Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Groceries")) {
            
            var dirFiles = Directory.EnumerateFiles($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Groceries");
            foreach (var file in dirFiles)
                File.Delete(file);
            
            Directory.Delete($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Groceries");
        }

        if(!Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Groceries")) {
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating subdirectory ...");
                    System.Console.WriteLine($"                 |           |           |----> Directory: \"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Groceries\"");
                    System.Console.WriteLine($"                 |           |");
                #endif
                
                Directory.CreateDirectory($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Groceries");
            
                #if DEBUG
                    System.Console.WriteLine($"[OK]             |           |----> Directory successfully created.");
                    System.Console.WriteLine($"                 |           |");
                #endif
            } catch(UnauthorizedAccessException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    UnauthorizedAccessException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentNullException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    ArgumentNullException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    ArgumentException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(PathTooLongException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    PathTooLongException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(DirectoryNotFoundException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    DirectoryNotFoundException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(NotSupportedException thrownException) {
                 #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    NotSupportedException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(IOException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]                      |----> Exception thrown:");
                    System.Console.WriteLine($"                                         |----> Exception name:    IOException");
                    System.Console.WriteLine($"                                         |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                                         |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            }
        }

        if(Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Apartment")) {
            var dirFiles = Directory.EnumerateFiles($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Apartment");
            foreach (var file in dirFiles)
                File.Delete(file);

            Directory.Delete($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Apartment");
        }

        if(!Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Apartment")) {
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating subdirectory ...");
                    System.Console.WriteLine($"                 |           |           |----> Directory: \"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Apartment\"");
                    System.Console.WriteLine($"                 |           |");
                #endif

                Directory.CreateDirectory($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Apartment");
            
                #if DEBUG
                    System.Console.WriteLine($"[OK]             |           |----> Directory successfully created.");
                    System.Console.WriteLine($"                 |           |");
                #endif
            } catch(UnauthorizedAccessException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    UnauthorizedAccessException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentNullException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    ArgumentException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(PathTooLongException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    PathTooLongException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(DirectoryNotFoundException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    DirectoryNotFoundException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(NotSupportedException thrownException) {
                 #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(IOException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    IOException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            }
        }


        if(Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Entertainment")) {
            var dirFiles = Directory.EnumerateFiles($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Entertainment");
            foreach (var file in dirFiles)
                File.Delete(file);
            
            Directory.Delete($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Entertainment");
        }
        
        if(!Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Entertainment")) {
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating subdirectory ...");
                    System.Console.WriteLine($"                 |           |           |----> Directory: \"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Entertainment\"");
                    System.Console.WriteLine($"                 |           |");
                #endif

                Directory.CreateDirectory($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Entertainment");
            
                #if DEBUG
                    System.Console.WriteLine($"[OK]             |           |----> Directory successfully created.");
                    System.Console.WriteLine($"                 |           |");
                #endif
            } catch(UnauthorizedAccessException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    UnauthorizedAccessException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentNullException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    ArgumentException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(PathTooLongException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    PathTooLongException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(DirectoryNotFoundException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    DirectoryNotFoundException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(NotSupportedException thrownException) {
                 #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(IOException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    IOException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            }
        }

        if(Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Personal care & grooming")) {
            var dirFiles = Directory.EnumerateFiles($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Personal care & grooming");
            foreach (var file in dirFiles)
                File.Delete(file);
            
            Directory.Delete($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Personal care & grooming");
        }
        
        if(!Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Personal care & grooming")) {
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating subdirectory ...");
                    System.Console.WriteLine($"                 |           |           |----> Directory: \"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Personal care & grooming\"");
                    System.Console.WriteLine($"                 |           |");
                #endif

                Directory.CreateDirectory($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Personal care & grooming");
            
                #if DEBUG
                    System.Console.WriteLine($"[OK]             |           |----> Directory successfully created.");
                    System.Console.WriteLine($"                 |           |");
                #endif
            } catch(UnauthorizedAccessException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    UnauthorizedAccessException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentNullException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    ArgumentException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(PathTooLongException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    PathTooLongException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(DirectoryNotFoundException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    DirectoryNotFoundException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(NotSupportedException thrownException) {
                 #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(IOException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    IOException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            }
        }

        if(Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Vehicle")) {
            var dirFiles = Directory.EnumerateFiles($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Vehicle");
            foreach (var file in dirFiles)
                File.Delete(file);
            
            Directory.Delete($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Vehicle");
        }

        if(!Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Vehicle")) {
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating subdirectory ...");
                    System.Console.WriteLine($"                 |           |           |----> Directory: \"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Vehicle\"");
                    System.Console.WriteLine($"                 |           |");
                #endif

                Directory.CreateDirectory($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Vehicle");
            
                #if DEBUG
                    System.Console.WriteLine($"[OK]             |           |----> Directory successfully created.");
                    System.Console.WriteLine($"                 |           |");
                #endif
            } catch(UnauthorizedAccessException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    UnauthorizedAccessException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentNullException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    ArgumentException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(PathTooLongException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    PathTooLongException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(DirectoryNotFoundException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    DirectoryNotFoundException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(NotSupportedException thrownException) {
                 #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(IOException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    IOException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            }
        }

        if(Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Miscellaneous")) {
            var dirFiles = Directory.EnumerateFiles($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Miscellaneous");
            foreach (var file in dirFiles)
                File.Delete(file);
            
            Directory.Delete($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Miscellaneous");
        }

        if(!Directory.Exists($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Miscellaneous")) {
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating subdirectory ...");
                    System.Console.WriteLine($"                 |           |           |----> Directory: \"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Miscellaneous\"");
                    System.Console.WriteLine($"                 |           |");
                #endif

                Directory.CreateDirectory($"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Miscellaneous");
            
                #if DEBUG
                    System.Console.WriteLine($"[OK]             |           |----> Directory successfully created.");
                    System.Console.WriteLine($"                 |");
                #endif
            } catch(UnauthorizedAccessException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    UnauthorizedAccessException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentNullException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(ArgumentException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    ArgumentException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(PathTooLongException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    PathTooLongException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(DirectoryNotFoundException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    DirectoryNotFoundException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(NotSupportedException thrownException) {
                 #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            } catch(IOException thrownException) {
                #if DEBUG
                    System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                    System.Console.WriteLine($"                             |----> Exception name:    IOException");
                    System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                    System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                    System.Console.WriteLine($"");
                #endif
                return;
            }
        }
        

        foreach (var category in viewModel.Categories) {
            if(category.Name is "Apartment") {
                #if DEBUG
                    System.Console.WriteLine($"                 |");
                    System.Console.WriteLine($"[OK]             |----> Root category is \"Apartment\"");
                    System.Console.WriteLine($"                 |           |----> Category:        {category.Name}");
                    System.Console.WriteLine($"                 |           |----> Child count:     {category.Children.Count}");
                #endif

                string path = $"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Apartment";
                
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Data entry path: {path}");
                    System.Console.WriteLine($"                 |");
                #endif

                foreach (var childCategory in category.Children) {
                    
                    if(childCategory is ApartmentViewModel) {
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Child category is ApartmentViewModel");
                            System.Console.WriteLine($"                 |           |----> Parent Category: {category.Name}");
                            System.Console.WriteLine($"                 |           |----> Child Category:  {childCategory.Name}");
                            System.Console.WriteLine($"                 |");
                        #endif
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Child category is not ApartmentViewModel");
                            System.Console.WriteLine($"                             |----> Parent Category: {category.Name}");
                            System.Console.WriteLine($"                             |----> Child Category:  {childCategory.Name}");
                            System.Console.WriteLine($"");
                        #endif
                        return;
                    }

                    try {
                        #if DEBUG
                            System.Console.WriteLine($"                 |----> Serializing data ...");
                        #endif
                        
                        ApartmentViewModel temp = (ApartmentViewModel)childCategory;
                        string json_category = JsonSerializer.Serialize(temp._apartment);
                        
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Data serialized.");
                        #endif

                        try {
                            #if DEBUG
                                System.Console.WriteLine($"                 |----> Creating and writing data ...");
                                System.Console.WriteLine($"                 |           |----> Filename: {childCategory.Name}");
                                System.Console.WriteLine($"                 |");
                            #endif
                            
                            File.WriteAllText($"{path}/{childCategory.Name}", json_category);
                            
                            #if DEBUG
                                System.Console.WriteLine($"[OK]             |----> File Written.");
                            #endif

                        } catch(UnauthorizedAccessException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    UnauthorizedAccessException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(ArgumentNullException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(ArgumentException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    ArgumentException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(PathTooLongException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    PathTooLongException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(DirectoryNotFoundException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    DirectoryNotFoundException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(NotSupportedException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(IOException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    IOException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(System.Security.SecurityException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    System.Security.SecurityException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        }

                    } catch(NotSupportedException thrownException) {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                            System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                            System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                            System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                            System.Console.WriteLine($"");
                        #endif
                        return;
                    }
                }
            } else if(category.Name is "Groceries") {
                #if DEBUG
                    System.Console.WriteLine($"                 |");
                    System.Console.WriteLine($"[OK]             |----> Root category is \"Groceries\"");
                    System.Console.WriteLine($"                 |           |----> Category:        {category.Name}");
                    System.Console.WriteLine($"                 |           |----> Child count:     {category.Children.Count}");
                #endif

                string path = $"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Groceries";
                
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Data entry path: {path}");
                    System.Console.WriteLine($"                 |");
                #endif

                foreach (var childCategory in category.Children) {
                    
                    if(childCategory is GroceriesViewModel) {
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Child category is GroceriesViewModel");
                            System.Console.WriteLine($"                 |           |----> Parent Category: {category.Name}");
                            System.Console.WriteLine($"                 |           |----> Child Category:  {childCategory.Name}");
                            System.Console.WriteLine($"                 |");
                        #endif
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Child category is not GroceriesViewModel");
                            System.Console.WriteLine($"                             |----> Parent Category: {category.Name}");
                            System.Console.WriteLine($"                             |----> Child Category:  {childCategory.Name}");
                            System.Console.WriteLine($"");
                        #endif
                        return;
                    }

                    try {
                        #if DEBUG
                            System.Console.WriteLine($"                 |----> Serializing data ...");
                        #endif

                        GroceriesViewModel temp = (GroceriesViewModel)childCategory;
                        string json_category = JsonSerializer.Serialize(temp._groceries);
                        
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Data serialized.");
                        #endif

                        try {
                            #if DEBUG
                                System.Console.WriteLine($"                 |----> Creating and writing data ...");
                                System.Console.WriteLine($"                 |           |----> Filename: {childCategory.Name}");
                                System.Console.WriteLine($"                 |");
                            #endif
                            
                            File.WriteAllText($"{path}/{childCategory.Name}", json_category);
                            
                            #if DEBUG
                                System.Console.WriteLine($"[OK]             |----> File Written.");
                            #endif

                        } catch(UnauthorizedAccessException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    UnauthorizedAccessException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(ArgumentNullException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(ArgumentException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    ArgumentException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(PathTooLongException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    PathTooLongException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(DirectoryNotFoundException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    DirectoryNotFoundException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(NotSupportedException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(IOException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    IOException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(System.Security.SecurityException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    System.Security.SecurityException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        }

                    } catch(NotSupportedException thrownException) {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                            System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                            System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                            System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                            System.Console.WriteLine($"");
                        #endif
                        return;
                    }
                }
            } else if(category.Name is "Entertainment") {
                #if DEBUG
                    System.Console.WriteLine($"                 |");
                    System.Console.WriteLine($"[OK]             |----> Root category is \"Entertainment\"");
                    System.Console.WriteLine($"                 |           |----> Category:        {category.Name}");
                    System.Console.WriteLine($"                 |           |----> Child count:     {category.Children.Count}");
                #endif

                string path = $"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Entertainment";
                
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Data entry path: {path}");
                    System.Console.WriteLine($"                 |");
                #endif

                foreach (var childCategory in category.Children) {
                    
                    if(childCategory is EntertainmentViewModel) {
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Child category is EntertainmentViewModel");
                            System.Console.WriteLine($"                 |           |----> Parent Category: {category.Name}");
                            System.Console.WriteLine($"                 |           |----> Child Category:  {childCategory.Name}");
                            System.Console.WriteLine($"                 |");
                        #endif
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Child category is not EntertainmentViewModel");
                            System.Console.WriteLine($"                             |----> Parent Category: {category.Name}");
                            System.Console.WriteLine($"                             |----> Child Category:  {childCategory.Name}");
                            System.Console.WriteLine($"");
                        #endif
                        return;
                    }

                    try {
                        #if DEBUG
                            System.Console.WriteLine($"                 |----> Serializing data ...");
                        #endif
                        
                        EntertainmentViewModel temp = (EntertainmentViewModel)childCategory;
                        string json_category = JsonSerializer.Serialize(temp._entertainment);
                        
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Data serialized.");
                        #endif

                        try {
                            #if DEBUG
                                System.Console.WriteLine($"                 |----> Creating and writing data ...");
                                System.Console.WriteLine($"                 |           |----> Filename: {childCategory.Name}");
                                System.Console.WriteLine($"                 |");
                            #endif
                            
                            File.WriteAllText($"{path}/{childCategory.Name}", json_category);
                            
                            #if DEBUG
                                System.Console.WriteLine($"[OK]             |----> File Written.");
                            #endif

                        } catch(UnauthorizedAccessException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    UnauthorizedAccessException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(ArgumentNullException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(ArgumentException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    ArgumentException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(PathTooLongException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    PathTooLongException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(DirectoryNotFoundException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    DirectoryNotFoundException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(NotSupportedException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(IOException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    IOException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(System.Security.SecurityException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    System.Security.SecurityException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        }

                    } catch(NotSupportedException thrownException) {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                            System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                            System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                            System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                            System.Console.WriteLine($"");
                        #endif
                        return;
                    }
                }
            } else if(category.Name is "Personal care & grooming") {
                #if DEBUG
                    System.Console.WriteLine($"                 |");
                    System.Console.WriteLine($"[OK]             |----> Root category is \"Personal care & grooming\"");
                    System.Console.WriteLine($"                 |           |----> Category:        {category.Name}");
                    System.Console.WriteLine($"                 |           |----> Child count:     {category.Children.Count}");
                #endif

                string path = $"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Personal care & grooming";
                
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Data entry path: {path}");
                    System.Console.WriteLine($"                 |");
                #endif

                foreach (var childCategory in category.Children) {
                    
                    if(childCategory is PersonalCareGroomingViewModel) {
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Child category is PersonalCareGroomingViewModel");
                            System.Console.WriteLine($"                 |           |----> Parent Category: {category.Name}");
                            System.Console.WriteLine($"                 |           |----> Child Category:  {childCategory.Name}");
                            System.Console.WriteLine($"                 |");
                        #endif
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Child category is not PersonalCareGroomingViewModel");
                            System.Console.WriteLine($"                             |----> Parent Category: {category.Name}");
                            System.Console.WriteLine($"                             |----> Child Category:  {childCategory.Name}");
                            System.Console.WriteLine($"");
                        #endif
                        return;
                    }

                    try {
                        #if DEBUG
                            System.Console.WriteLine($"                 |----> Serializing data ...");
                        #endif
                        
                        PersonalCareGroomingViewModel temp = (PersonalCareGroomingViewModel)childCategory;
                        string json_category = JsonSerializer.Serialize(temp._personalCareGrooming);
                        
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Data serialized.");
                        #endif

                        try {
                            #if DEBUG
                                System.Console.WriteLine($"                 |----> Creating and writing data ...");
                                System.Console.WriteLine($"                 |           |----> Filename: {childCategory.Name}");
                                System.Console.WriteLine($"                 |");
                            #endif
                            
                            File.WriteAllText($"{path}/{childCategory.Name}", json_category);
                            
                            #if DEBUG
                                System.Console.WriteLine($"[OK]             |----> File Written.");
                            #endif

                        } catch(UnauthorizedAccessException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    UnauthorizedAccessException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(ArgumentNullException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(ArgumentException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    ArgumentException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(PathTooLongException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    PathTooLongException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(DirectoryNotFoundException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    DirectoryNotFoundException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(NotSupportedException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(IOException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    IOException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(System.Security.SecurityException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    System.Security.SecurityException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        }

                    } catch(NotSupportedException thrownException) {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                            System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                            System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                            System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                            System.Console.WriteLine($"");
                        #endif
                        return;
                    }
                }
            } else if(category.Name is "Vehicle") {
                #if DEBUG
                    System.Console.WriteLine($"                 |");
                    System.Console.WriteLine($"[OK]             |----> Root category is \"Vehicle\"");
                    System.Console.WriteLine($"                 |           |----> Category:        {category.Name}");
                    System.Console.WriteLine($"                 |           |----> Child count:     {category.Children.Count}");
                #endif

                string path = $"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Vehicle";
                
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Data entry path: {path}");
                    System.Console.WriteLine($"                 |");
                #endif

                foreach (var childCategory in category.Children) {
                    
                    if(childCategory is VehicleViewModel) {
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Child category is VehicleViewModel");
                            System.Console.WriteLine($"                 |           |----> Parent Category: {category.Name}");
                            System.Console.WriteLine($"                 |           |----> Child Category:  {childCategory.Name}");
                            System.Console.WriteLine($"                 |");
                        #endif
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Child category is not VehicleViewModel");
                            System.Console.WriteLine($"                             |----> Parent Category: {category.Name}");
                            System.Console.WriteLine($"                             |----> Child Category:  {childCategory.Name}");
                            System.Console.WriteLine($"");
                        #endif
                        return;
                    }

                    try {
                        #if DEBUG
                            System.Console.WriteLine($"                 |----> Serializing data ...");
                        #endif
                        
                        VehicleViewModel temp = (VehicleViewModel)childCategory;
                        string json_category = JsonSerializer.Serialize(temp._vehicle);
                        
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Data serialized.");
                        #endif

                        try {
                            #if DEBUG
                                System.Console.WriteLine($"                 |----> Creating and writing data ...");
                                System.Console.WriteLine($"                 |           |----> Filename: {childCategory.Name}");
                                System.Console.WriteLine($"                 |");
                            #endif
                            
                            File.WriteAllText($"{path}/{childCategory.Name}", json_category);
                            
                            #if DEBUG
                                System.Console.WriteLine($"[OK]             |----> File Written.");
                            #endif

                        } catch(UnauthorizedAccessException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    UnauthorizedAccessException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(ArgumentNullException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(ArgumentException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    ArgumentException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(PathTooLongException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    PathTooLongException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(DirectoryNotFoundException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    DirectoryNotFoundException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(NotSupportedException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(IOException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    IOException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(System.Security.SecurityException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    System.Security.SecurityException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        }

                    } catch(NotSupportedException thrownException) {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                            System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                            System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                            System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                            System.Console.WriteLine($"");
                        #endif
                        return;
                    }
                }
            } else if(category.Name is "Miscellaneous") {
                #if DEBUG
                    System.Console.WriteLine($"                 |");
                    System.Console.WriteLine($"[OK]             |----> Root category is \"ExpenseMiscellaneous\"");
                    System.Console.WriteLine($"                 |           |----> Category:        {category.Name}");
                    System.Console.WriteLine($"                 |           |----> Child count:     {category.Children.Count}");
                #endif

                string path = $"DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Expense/Miscellaneous";
                
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Data entry path: {path}");
                    System.Console.WriteLine($"                 |");
                #endif

                foreach (var childCategory in category.Children) {
                    
                    if(childCategory is ExpenseMiscellaneousViewModel) {
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Child category is ExpenseMiscellaneousViewModel");
                            System.Console.WriteLine($"                 |           |----> Parent Category: {category.Name}");
                            System.Console.WriteLine($"                 |           |----> Child Category:  {childCategory.Name}");
                            System.Console.WriteLine($"                 |");
                        #endif
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Child category is not ExpenseMiscellaneousViewModel");
                            System.Console.WriteLine($"                             |----> Parent Category: {category.Name}");
                            System.Console.WriteLine($"                             |----> Child Category:  {childCategory.Name}");
                            System.Console.WriteLine($"");
                        #endif
                        return;
                    }

                    try {
                        #if DEBUG
                            System.Console.WriteLine($"                 |----> Serializing data ...");
                        #endif
                        
                        ExpenseMiscellaneousViewModel temp = (ExpenseMiscellaneousViewModel)childCategory;
                        string json_category = JsonSerializer.Serialize(temp._expenseMiscellaneous);
                        
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Data serialized.");
                        #endif

                        try {
                            #if DEBUG
                                System.Console.WriteLine($"                 |----> Creating and writing data ...");
                                System.Console.WriteLine($"                 |           |----> Filename: {childCategory.Name}");
                                System.Console.WriteLine($"                 |");
                            #endif
                            
                            File.WriteAllText($"{path}/{childCategory.Name}", json_category);
                            
                            #if DEBUG
                                System.Console.WriteLine($"[OK]             |----> File Written.");
                            #endif

                        } catch(UnauthorizedAccessException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    UnauthorizedAccessException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(ArgumentNullException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(ArgumentException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    ArgumentException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(PathTooLongException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    PathTooLongException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(DirectoryNotFoundException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    DirectoryNotFoundException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(NotSupportedException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(IOException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    IOException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        } catch(System.Security.SecurityException thrownException) {
                            #if DEBUG
                                System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                                System.Console.WriteLine($"                             |----> Exception name:    System.Security.SecurityException");
                                System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                                System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                                System.Console.WriteLine($"");
                            #endif
                            return;
                        }

                    } catch(NotSupportedException thrownException) {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                            System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                            System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                            System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                            System.Console.WriteLine($"");
                        #endif
                        return;
                    }
                }
            }
        }
        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> Data succesfully saved.");
            System.Console.WriteLine($"");
        #endif
    }

#region Files
    private void RemoveExpenseFile_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]        Function \"ExpenseView.RemoveExpenseFile_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)\" Called.");
            System.Console.WriteLine($"                 |----> Sender:");
            System.Console.WriteLine($"                 |           |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"                 |");
            System.Console.WriteLine($"                 |----> Event:");
            System.Console.WriteLine($"                 |           |----> Type: {e?.GetType().FullName}");
            System.Console.WriteLine($"                 |");
        #endif

        //  Checks if datacontext is set
        if (DataContext is not ExpenseViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine("[ERROR]                 |----> DataContext in ExpenseViewModel.axaml.cs IS NOT ExpenseViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> Datacontext in ExpenseViewModel.axaml.cs is ExpenseViewModel.");
        #endif

        if (sender is not Button button) {
            #if DEBUG
                System.Console.WriteLine("[ERROR]                 |----> Sender is not a Button.");
                System.Console.WriteLine($"");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine("[OK]          |----> Sender is a Button.");
        #endif

        if (button.DataContext is not PdfFile_Processor file) {
            #if DEBUG
                System.Console.WriteLine("[ERROR]                 |----> Button DataContext IS NOT PdfFile_Processor.");
                System.Console.WriteLine($"");
            #endif
            return;
        }

        if (file == null) {
            #if DEBUG
                System.Console.WriteLine("[ERROR]                 |----> File NON-EXISTENT.");
                System.Console.WriteLine($"");
            #endif
            return;
        } else {
            #if DEBUG
                System.Console.WriteLine($"[OK]             |----> File Valid/Exists.");
                System.Console.WriteLine($"[OK]             |           |----> \"File\":     {file.FileName}");
                System.Console.WriteLine($"[OK]             |           |----> \"Location\": {file.FilePath}");
                System.Console.WriteLine($"                     |");
            #endif
            viewModel.Files.Remove(file);
            #if DEBUG
                System.Console.WriteLine($"[OK]             |----> File removed from list.");
            #endif
        }
        System.Console.WriteLine($"");
    }

    private void Expense_OnDragOver(object? sender, Avalonia.Input.DragEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]        Function \"ExpenseView.Expense_OnDragOver(object? sender, Avalonia.Input.DragEventArgs e)\" Called.");
            System.Console.WriteLine($"                 |----> Sender:");
            System.Console.WriteLine($"                 |           |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"                 |");
            System.Console.WriteLine($"                 |----> Event:");
            System.Console.WriteLine($"                 |           |----> Type: {e?.GetType().FullName}");
            System.Console.WriteLine($"                 |");
        #endif

        //  Checks if datacontext is set
        if (DataContext is not ExpenseViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]          |----> DataContext in ExpenseViewModel.axaml.cs IS NOT ExpenseViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> Datacontext in ExpenseViewModel.axaml.cs is ExpenseViewModel.");
        #endif

        var files = e?.DataTransfer.TryGetFiles();

        if (files == null) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]          |----> No file(s) detected.");
                System.Console.WriteLine($"");
            #endif
            e?.DragEffects = DragDropEffects.None;
            return;
        }

        e?.DragEffects = DragDropEffects.Copy;

        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> File(s) dragged over & copied, Count: {files.Count()}");
            foreach (var item in files) {
                if(item.Equals(files.Last())) {
                    System.Console.WriteLine($"                         |----> {files.LastIndexOf(item)}. Filename: {item.Name}");
                } else {
                    System.Console.WriteLine($"                 |       |----> {files.LastIndexOf(item)}. Filename: {item.Name}");
                }
            }
            System.Console.WriteLine($"");
        #endif
    }

    private void Expense_OnDrop(object? sender, Avalonia.Input.DragEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]        Function \"ExpenseView.Expense_OnDrop(object? sender, Avalonia.Input.DragEventArgs e)\" Called.");
            System.Console.WriteLine($"                 |----> Sender:");
            System.Console.WriteLine($"                 |           |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"                 |");
            System.Console.WriteLine($"                 |----> Event:");
            System.Console.WriteLine($"                 |           |----> Type: {e?.GetType().FullName}");
            System.Console.WriteLine($"                 |");
        #endif

        if (DataContext is not ExpenseViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]          |----> DataContext in ExpenseViewModel.axaml.cs IS NOT ExpenseViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> Datacontext in ExpenseViewModel.axaml.cs is ExpenseViewModel.");
        #endif

        var files = e?.DataTransfer.TryGetFiles();

        if (files == null) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]          |----> No files received");
                System.Console.WriteLine($"");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> Files received: {files.Length}");
        #endif

        foreach (var item in files) {
            #if DEBUG
                if(item.Equals(files.Last())) {
                    System.Console.WriteLine($"                 |           |----> File: {viewModel.Files.Count}");
                    System.Console.WriteLine($"                 |                   |----> Item Name:     {item.Name}");
                    System.Console.WriteLine($"                 |                   |----> Item type:     {item.GetType().Name}");
                    System.Console.WriteLine($"                 |                   |----> Item Location: {item.Path.LocalPath}");
                } else {
                    System.Console.WriteLine($"                 |           |----> File: {viewModel.Files.Count}");
                    System.Console.WriteLine($"                 |           |       |----> Item Name:     {item.Name}");
                    System.Console.WriteLine($"                 |           |       |----> Item type:     {item.GetType().Name}");
                    System.Console.WriteLine($"                 |           |       |----> Item Location: {item.Path.LocalPath}");
                }
            #endif
            
            if (item is IStorageFile file) {
                var pdf = new PdfFile_Processor(file.Path.LocalPath);
                if (pdf.Thumbnail != null) {
                    pdf.Thumbnail = AvaloniaPdfThumbnailConverter.ToBitmap((PdfThumbnail)pdf.Thumbnail);
                }
                viewModel.Files.Add(pdf);

                #if DEBUG
                    if(item.Equals(files.Last())) {
                        System.Console.WriteLine($"[OK]             |                   |----> File added to list.");
                        System.Console.WriteLine($"                 |                               |----> Item Name:     {item.Name}");
                        System.Console.WriteLine($"                 |                               |----> Item type:     {item.GetType().Name}");
                        System.Console.WriteLine($"                 |                               |----> Item Location: {item.Path.LocalPath}");
                    } else {
                        System.Console.WriteLine($"[OK]             |           |       |----> File added to list.");
                        System.Console.WriteLine($"                 |           |                   |----> Item Name:     {item.Name}");
                        System.Console.WriteLine($"                 |           |                   |----> Item type:     {item.GetType().Name}");
                        System.Console.WriteLine($"                 |           |                   |----> Item Location: {item.Path.LocalPath}");
                    }
                #endif
            } else {
                #if DEBUG
                    if(item.Equals(files.Last()))
                        System.Console.WriteLine($"[ERROR]          |                   |----> Item IS NOT of type \"IStorageFile\".");
                    else
                        System.Console.WriteLine($"[ERROR]          |           |       |----> Item IS NOT of type \"IStorageFile\".");
                #endif
            }

            #if DEBUG
                if(item.Equals(files.Last()))
                    System.Console.WriteLine($"                 |");
                else
                    System.Console.WriteLine($"                 |           |");
            #endif
        }

        viewModel.Expense_DragNDrop_Box_BackgroundColor = "#FFFFFFFF";
        
        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> Drag'N'Drop image background changed color to {viewModel.Expense_DragNDrop_Box_BackgroundColor}.");
            System.Console.WriteLine($"");
        #endif
    }

    private void Expense_OnDragEnter(object? sender, Avalonia.Input.DragEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Dragged files entered the Drag'N'Drop Section");
        #endif

        if (DataContext is not ExpenseViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine("[ERROR] DataContext in ExpenseViewModel.axaml.cs IS NOT ExpenseViewModel.");
            #endif
            return;
        } else {
            #if DEBUG
                System.Console.WriteLine("[OK]    Datacontext in ExpenseViewModel.axaml.cs is ExpenseViewModel.");
            #endif
        }

        viewModel.Expense_DragNDrop_Box_BackgroundColor = "#AAAAAAAA";

        #if DEBUG
            System.Console.WriteLine($"[OK]    Drag'N'Drop image background changed color to {viewModel.Expense_DragNDrop_Box_BackgroundColor}.");
        #endif

        var files = e.DataTransfer.TryGetFiles();
        if(files == null) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR] No Drag'N'Dropped files found, variable \"files\" = null.");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]    Dragged file(s) entered {files.Count()}");
            foreach (var item in files)
                System.Console.WriteLine($"[OK]                 |----> {files.LastIndexOf(item)}. Filename: {item.Name}");

            System.Console.WriteLine();
        #endif
    }
    private void Expense_OnDragLeave(object? sender, Avalonia.Input.DragEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Dragged files left the Drag'N'Drop section");
            System.Console.WriteLine($"                     |----> Triggered Event: {e.RoutedEvent}");
            System.Console.WriteLine($"                     |----> Object receiving the event: {this.GetType()}");
            System.Console.WriteLine();
        #endif

        if (DataContext is not ExpenseViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine("[ERROR] DataContext in ExpenseViewModel.axaml.cs IS NOT ExpenseViewModel.");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine("[OK]    Datacontext in ExpenseViewModel.axaml.cs is ExpenseViewModel.");
        #endif

        viewModel.Expense_DragNDrop_Box_BackgroundColor = "#FFFFFFFF";

        #if DEBUG
            System.Console.WriteLine($"[OK]    Drag'N'Drop image background changed back to default color = {viewModel.Expense_DragNDrop_Box_BackgroundColor}.");
        #endif
        
        var files = e.DataTransfer.TryGetFiles();
        if(files == null) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR] No Drag'N'Dropped files found, variable \"files\" = null.");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]         File(s) leaving {files.Count()}");
            foreach (var item in files)
            System.Console.WriteLine($"[OK]                 |----> {files.LastIndexOf(item)}. Filename: {item.Name}");

            System.Console.WriteLine();
        #endif
    }
#endregion

    /*
    ********************************************************************************************************
    ********************************             Selecting category           ******************************
    ********************************************************************************************************
    */
    private void OnSelectedCategoryChanged(object? sender, Avalonia.Input.TappedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]         Function \"ExpenseView.OnSelectedCategoryChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"                     |----> Sender:");
            System.Console.WriteLine($"                     |           |----> Type:     {sender?.GetType()}");
            System.Console.WriteLine($"                     |           |----> Fullname: {sender?.GetType().FullName}");
            System.Console.WriteLine($"                     |");
        #endif
        
        if (DataContext is not ExpenseViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]              |----> DataContext in ExpenseViewModel.axaml.cs IS NOT ExpenseViewModel.");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> Datacontext in ExpenseViewModel.axaml.cs is ExpenseViewModel.");
            System.Console.WriteLine($"[OK]             |----> Event source type is \"TreeView\".");
        #endif

        if (viewModel.SelectedCategory is CategoryViewModel category) {
            #if DEBUG
                System.Console.WriteLine($"[OK]                 |----> Selected item \"{viewModel.SelectedCategory.GetType()}\" type is \"{category.GetType()}\".");
                System.Console.WriteLine($"                                    |----> Item name: \"{viewModel.SelectedCategory.Name}\".");
            #endif
            if(viewModel.SelectedCategory.IsCategoryRoot is true) {
                #if DEBUG
                    System.Console.WriteLine($"                                    |----> Selected item is parent category.");
                #endif
                if(viewModel.SelectedCategory.Children.Count == 0) {
                    #if DEBUG
                        System.Console.WriteLine($"                                    |----> Item has no child category.");
                    #endif
                    viewModel.SelectedCategory = null;
                } else {
                    #if DEBUG
                        System.Console.WriteLine($"                                    |----> Item has {viewModel.SelectedCategory.Children.Count()} child(ren) category.");
                    #endif
                    
                    viewModel.SelectedCategory = viewModel.SelectedCategory.Children.First();   
                    
                    #if DEBUG
                        System.Console.WriteLine($"[OK]                                            |----> Child selected {viewModel.SelectedCategory.Name}.");
                    #endif
                }
            }

        } else {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]               |----> Selected item does not belong to \"CategoryViewModel\".");
                System.Console.WriteLine($"                                |----> \"SelectedItem\" = \"{viewModel.SelectedCategory?.GetType()}\".");
                System.Console.WriteLine($"");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"");
        #endif
    }

    private void selectedDate_Changed(object? sender, Avalonia.Controls.SelectionChangedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]         Function \"ExpenseView.OnSelectedCategoryChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"                     |----> Sender:");
            System.Console.WriteLine($"                     |          |----> Type:     {sender?.GetType()}");
            System.Console.WriteLine($"                     |          |----> Fullname: {sender?.GetType().FullName}");
            System.Console.WriteLine($"                     |");
        #endif
        
        if (DataContext is not ExpenseViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]              |----> DataContext in ExpenseViewModel.axaml.cs IS NOT ExpenseViewModel.");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine($"[OK]                 |----> Datacontext in ExpenseViewModel.axaml.cs is ExpenseViewModel.");
            System.Console.WriteLine($"[OK]                 |----> Event source type is \"TreeView\".");
        #endif


        foreach( var category in viewModel.Categories) {
            category.Children.Clear();
        }
        viewModel.Files.Clear();

        if(!viewModel.LoadExpenseData(DateOnly.FromDateTime(viewModel.PickedDate))) {
            #if DEBUG
                System.Console.WriteLine($"[Warning]            |----> No data loaded or found.");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[OK]                 |----> Data Successfully loaded.");
                System.Console.WriteLine($"");
            #endif
        }
    }
}
