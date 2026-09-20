using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform.Storage;
using Personal_Economy_Display.ViewModels;

namespace Personal_Economy_Display.Views;

public partial class IncomeView : UserControl {
    public IncomeView() {
        InitializeComponent();
        DataContext = new IncomeViewModel();
    }

    private void AddEntry_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]         Function \"IncomeView.AddEntry_Button_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)\" Called.");
            System.Console.WriteLine($"                 |----> Sender:");
            System.Console.WriteLine($"                 |           |----> Type:     {sender?.GetType()}");
            System.Console.WriteLine($"                 |           |----> Fullname: {sender?.GetType().FullName}");
            System.Console.WriteLine($"                 |");
        #endif

        //  Checks if datacontext is set
        if (DataContext is not IncomeViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]          |----> DataContext in IncomeViewModel.axaml.cs IS NOT IncomeViewModel.");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> Datacontext in IncomeViewModel.axaml.cs is IncomeViewModel.");
        #endif

        string destinationDirectory = Path.Combine(
            AppContext.BaseDirectory,
            "DataEntries",
            viewModel.PickedDate.Year.ToString(),
            viewModel.PickedDate.Month.ToString(),
            viewModel.PickedDate.Day.ToString()
        );

        if(!Directory.Exists($"{destinationDirectory}/")) {
            #if DEBUG
                System.Console.WriteLine($"[WARNING]        |----> Directory does not exist.");
                System.Console.WriteLine($"                 |           |----> Directory: \"{destinationDirectory}/\"");
            #endif
            
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating directory ...");
                #endif
                
                Directory.CreateDirectory($"{destinationDirectory}/");
                
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

        if(!Directory.Exists($"{destinationDirectory}/Income")) {
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating subdirectory ...");
                    System.Console.WriteLine($"                 |                       |----> Directory: DataEntries/{viewModel.PickedDate.Year.ToString()}/{viewModel.PickedDate.Month.ToString()}/{viewModel.PickedDate.Day.ToString()}/Income");
                    System.Console.WriteLine($"                 |");
                #endif
                
                Directory.CreateDirectory($"{destinationDirectory}/Income");
            
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

        if(!Directory.Exists($"{destinationDirectory}/Income/Files")) {
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating subdirectory ...");
                    System.Console.WriteLine($"                 |                       |----> Directory: \"{destinationDirectory}/Income/Files\"");
                    System.Console.WriteLine($"                 |");
                #endif
                
                Directory.CreateDirectory($"{destinationDirectory}/Income/Files");
                
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

        destinationDirectory = Path.Combine(
            AppContext.BaseDirectory,
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
        
        destinationDirectory = Path.Combine(
            AppContext.BaseDirectory,
            "DataEntries",
            viewModel.PickedDate.Year.ToString(),
            viewModel.PickedDate.Month.ToString(),
            viewModel.PickedDate.Day.ToString()
        );

        if(Directory.Exists($"{destinationDirectory}/Income/Work")) {
            
            var dirFiles = Directory.EnumerateFiles($"{destinationDirectory}/Income/Work");
            foreach (var file in dirFiles)
                File.Delete(file);
            
            Directory.Delete($"{destinationDirectory}/Income/Work");
        }

        if(!Directory.Exists($"{destinationDirectory}/Income/Work")) {
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating subdirectory ...");
                    System.Console.WriteLine($"                 |                       |----> Directory: \"{destinationDirectory}/Income/Work\"");
                    System.Console.WriteLine($"                 |");
                #endif
                
                Directory.CreateDirectory($"{destinationDirectory}/Income/Work");
            
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


        if(Directory.Exists($"{destinationDirectory}/Income/Government Support")) {
            
            var dirFiles = Directory.EnumerateFiles($"{destinationDirectory}/Income/Government Support");
            foreach (var file in dirFiles)
                File.Delete(file);
            
            Directory.Delete($"{destinationDirectory}/Income/Government Support");
        }

        if(!Directory.Exists($"{destinationDirectory}/Income/Government Support")) {
            try {
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Creating subdirectory ...");
                    System.Console.WriteLine($"                 |                       |----> Directory: \"{destinationDirectory}/Income/Government Support\"");
                    System.Console.WriteLine($"                 |");
                #endif

                Directory.CreateDirectory($"{destinationDirectory}/Income/Government Support");
            
                #if DEBUG
                    System.Console.WriteLine($"[OK]             |           |----> Directory successfully created.");
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
            if(category.Name is "Government Support") {
                #if DEBUG
                    System.Console.WriteLine($"[OK]             |----> Root category is \"Government Support\"");
                    System.Console.WriteLine($"                 |           |----> Category:        {category.Name}");
                    System.Console.WriteLine($"                 |           |----> Child count:     {category.Children.Count}");
                #endif

                string path = $"{destinationDirectory}/Income/Government Support";
                
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Data entry path: {path}");
                    System.Console.WriteLine($"                 |");
                #endif

                foreach (var childCategory in category.Children) {
                    
                    if(childCategory is GovernmentSupportViewModel) {
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Child category is GovernmentSupportViewModel");
                            System.Console.WriteLine($"                 |           |----> Category:       {category.Name}");
                            System.Console.WriteLine($"                 |           |----> Child Category: {childCategory.Name}");
                        #endif
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Child category is not GovernmentSupportViewModel");
                            System.Console.WriteLine($"                             |----> Category:       {category.Name}");
                            System.Console.WriteLine($"                             |----> Child Category: {childCategory.Name}");
                        #endif
                    }

                    try {
                        #if DEBUG
                            System.Console.WriteLine($"                 |----> Serializing data ...");
                        #endif
                        
                        GovernmentSupportViewModel temp = (GovernmentSupportViewModel)childCategory;
                        string json_category = JsonSerializer.Serialize(temp._governmentSupport);
                        
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Data serialized.");
                            System.Console.WriteLine($"                 |");
                        #endif

                        try {
                            #if DEBUG
                                System.Console.WriteLine($"                 |----> Creating and writing data ...");
                                System.Console.WriteLine($"                 |           |----> Filename: {childCategory.Name}");
                            #endif
                            
                            File.WriteAllText(
                                Path.Combine(path, $"{childCategory.Name}.json"),
                                json_category
                            );
                            
                            #if DEBUG
                                System.Console.WriteLine($"[OK]             |----> File Written.");
                                System.Console.WriteLine($"");
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
            } else if(category.Name is "Work") {
                #if DEBUG
                    System.Console.WriteLine($"[OK]             |----> Root category is \"Work\"");
                    System.Console.WriteLine($"                 |           |----> Category:        {category.Name}");
                    System.Console.WriteLine($"                 |           |----> Child count:     {category.Children.Count}");
                #endif

                string path = $"{destinationDirectory}/Income/Work";
                
                #if DEBUG
                    System.Console.WriteLine($"                 |           |----> Data entry path: {path}");
                    System.Console.WriteLine($"                 |");
                #endif

                foreach (var childCategory in category.Children) {
                    
                    if(childCategory is WorkViewModel) {
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Child category is WorkViewModel");
                            System.Console.WriteLine($"                 |           |----> Category: {category.Name}");
                            System.Console.WriteLine($"                 |           |----> Category: {childCategory.Name}");
                        #endif
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> Child category is not WorkViewModel");
                            System.Console.WriteLine($"                             |----> Category: {category.Name}");
                            System.Console.WriteLine($"                             |----> Category: {childCategory.Name}");
                        #endif
                    }

                    try {
                        #if DEBUG
                            System.Console.WriteLine($"                 |----> Serializing data ...");
                        #endif
                        
                        WorkViewModel temp = (WorkViewModel)childCategory;
                        string json_category = JsonSerializer.Serialize(temp._work);
                        
                        #if DEBUG
                            System.Console.WriteLine($"[OK]             |----> Data serialized.");
                            System.Console.WriteLine($"                 |");
                        #endif

                        try {
                            #if DEBUG
                                System.Console.WriteLine($"                 |----> Creating and writing data ...");
                                System.Console.WriteLine($"                 |           |----> Filename: {childCategory.Name}");
                            #endif
                            
                            File.WriteAllText(
                                Path.Combine(path, $"{childCategory.Name}.json"),
                                json_category
                            );
                            
                            #if DEBUG
                                System.Console.WriteLine($"[OK]             |----> File Written.");
                                System.Console.WriteLine($"");
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
    private void RemoveFile_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]        Function \"IncomeView.RemoveFile_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)\" Called.");
            System.Console.WriteLine($"                |----> Sender:");
            System.Console.WriteLine($"                |           |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"                |");
            System.Console.WriteLine($"                |----> Event:");
            System.Console.WriteLine($"                |           |----> Type: {e?.GetType().FullName}");
            System.Console.WriteLine($"                |");
        #endif

        //  Checks if datacontext is set
        if (DataContext is not IncomeViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine("[ERROR]      |----> DataContext in IncomeViewModel.axaml.cs IS NOT IncomeViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine($"[OK]        |----> Datacontext in IncomeViewModel.axaml.cs is IncomeViewModel.");
        #endif

        if (sender is not Button button) {
            #if DEBUG
                System.Console.WriteLine("[ERROR]      |----> Sender is not a Button.");
                System.Console.WriteLine($"");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine("[OK]         |----> Sender is a Button.");
        #endif

        if (button.DataContext is not PdfFile_Processor file) {
            #if DEBUG
                System.Console.WriteLine("[ERROR]      |----> Button DataContext IS NOT PdfFile_Processor.");
                System.Console.WriteLine($"");
            #endif
            return;
        }

        if (file == null) {
            #if DEBUG
                System.Console.WriteLine("[ERROR]      |----> File NON-EXISTENT.");
                System.Console.WriteLine($"");
            #endif
            return;
        } else {
            #if DEBUG
                System.Console.WriteLine($"[OK]        |----> File Valid/Exists.");
                System.Console.WriteLine($"[OK]        |           |----> \"File\":     {file.FileName}");
                System.Console.WriteLine($"[OK]        |           |----> \"Location\": {file.FilePath}");
                System.Console.WriteLine($"                     |");
            #endif
            viewModel.Files.Remove(file);
            #if DEBUG
                System.Console.WriteLine($"[OK]        |----> File removed from list.");
            #endif
        }
        System.Console.WriteLine($"");
    }

    private void Files_OnDragOver(object? sender, Avalonia.Input.DragEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]        Function \"IncomeView.Income_OnDragOver(object? sender, Avalonia.Input.DragEventArgs e)\" Called.");
            System.Console.WriteLine($"                |----> Sender:");
            System.Console.WriteLine($"                |           |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"                |");
            System.Console.WriteLine($"                |----> Event:");
            System.Console.WriteLine($"                |           |----> Type: {e?.GetType().FullName}");
            System.Console.WriteLine($"                |");
        #endif

        //  Checks if datacontext is set
        if (DataContext is not IncomeViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]         |----> DataContext in IncomeViewModel.axaml.cs IS NOT IncomeViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine($"[OK]            |----> Datacontext in IncomeViewModel.axaml.cs is IncomeViewModel.");
        #endif

        var files = e?.DataTransfer.TryGetFiles();

        if (files == null) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]         |----> No file(s) detected.");
                System.Console.WriteLine($"");
            #endif
            e?.DragEffects = DragDropEffects.None;
            return;
        }

        e?.DragEffects = DragDropEffects.Copy;

        #if DEBUG
            System.Console.WriteLine($"[OK]            |----> File(s) dragged over & copied, Count: {files.Count()}");
            foreach (var item in files) {
                if(item.Equals(files.Last())) {
                    System.Console.WriteLine($"                        |----> {files.LastIndexOf(item)}. Filename: {item.Name}");
                }
            }
            System.Console.WriteLine($"");
        #endif
    }

    private void Files_OnDrop(object? sender, Avalonia.Input.DragEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]        Function \"IncomeView.Income_OnDrop(object? sender, Avalonia.Input.DragEventArgs e)\" Called.");
            System.Console.WriteLine($"                |----> Sender:");
            System.Console.WriteLine($"                |           |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"                |");
            System.Console.WriteLine($"                |----> Event:");
            System.Console.WriteLine($"                |           |----> Type: {e?.GetType().FullName}");
            System.Console.WriteLine($"                |");
        #endif

        if (DataContext is not IncomeViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]         |----> DataContext in IncomeViewModel.axaml.cs IS NOT IncomeViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]            |----> Datacontext in IncomeViewModel.axaml.cs is IncomeViewModel.");
        #endif

        var files = e?.DataTransfer.TryGetFiles();

        if (files == null) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]         |----> No files received");
                System.Console.WriteLine($"");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]            |----> Files received: {files.Length}");
        #endif

        foreach (var item in files) {
            #if DEBUG
                if(item.Equals(files.Last())) {
                    System.Console.WriteLine($"                |           |----> File: {viewModel.Files.Count}");
                    System.Console.WriteLine($"                |                   |----> Item Name:     {item.Name}");
                    System.Console.WriteLine($"                |                   |----> Item type:     {item.GetType().Name}");
                    System.Console.WriteLine($"                |                   |----> Item Location: {item.Path}");
                } else {
                    System.Console.WriteLine($"                |           |----> File: {viewModel.Files.Count}");
                    System.Console.WriteLine($"                |           |       |----> Item Name:     {item.Name}");
                    System.Console.WriteLine($"                |           |       |----> Item type:     {item.GetType().Name}");
                    System.Console.WriteLine($"                |           |       |----> Item Location: {item.Path}");
                }
            #endif
            
            if (item is IStorageFile file) {
                var pdf = new PdfFile_Processor(file.Path.LocalPath);
                if (pdf.Thumbnail != null) {
                    pdf.Thumbnail = AvaloniaPdfThumbnailConverter.ToBitmap((PdfThumbnail)pdf.Thumbnail);
                }
                viewModel.Files.Add(pdf);

                #if DEBUG
                    if(item.Equals(files.Last()))
                        System.Console.WriteLine($"[OK]            |                   |----> File added to list.");
                    else
                        System.Console.WriteLine($"[OK]            |           |       |----> File added to list.");
                #endif
            } else {
                #if DEBUG
                if(item.Equals(files.Last()))
                    System.Console.WriteLine($"[ERROR]         |                   |----> Item IS NOT of type \"IStorageFile\".");
                else
                    System.Console.WriteLine($"[ERROR]         |           |       |----> Item IS NOT of type \"IStorageFile\".");
                #endif
            }

            #if DEBUG
                if(item.Equals(files.Last()))
                    System.Console.WriteLine($"                |");
                else
                    System.Console.WriteLine($"                |           |");
            #endif
        }

        viewModel.Files_DragNDrop_Box_BackgroundColor = "#FFFFFFFF";
        
        #if DEBUG
            System.Console.WriteLine($"[OK]            |----> Drag'N'Drop image background changed color to {viewModel.Files_DragNDrop_Box_BackgroundColor}.");
            System.Console.WriteLine($"");
        #endif
    }

    private void Files_OnDragEnter(object? sender, Avalonia.Input.DragEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]         Function \"IncomeView.Income_OnDragEnter(object? sender, Avalonia.Input.DragEventArgs e)\" Called.");
            System.Console.WriteLine($"                     |----> Sender:");
            System.Console.WriteLine($"                     |           |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"                     |");
            System.Console.WriteLine($"                     |----> Event:");
            System.Console.WriteLine($"                     |           |----> Type: {e?.GetType().FullName}");
            System.Console.WriteLine($"                     |");
            System.Console.WriteLine($"[OK]                 |----> Dragged files entered the Drag'N'Drop Section");
            System.Console.WriteLine($"                     |");
        #endif

        if (DataContext is not IncomeViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]              |----> DataContext in IncomeViewModel.axaml.cs IS NOT IncomeViewModel.");
                System.Console.WriteLine($"");
            #endif
            return;
        } else {
            #if DEBUG
                System.Console.WriteLine($"[OK]                 |----> Datacontext in IncomeViewModel.axaml.cs is IncomeViewModel.");
                System.Console.WriteLine($"                     |");
            #endif
        }

        viewModel.Files_DragNDrop_Box_BackgroundColor = "#AAAAAAAA";

        #if DEBUG
            System.Console.WriteLine($"[OK]                 |----> Drag'N'Drop image background changed color to {viewModel.Files_DragNDrop_Box_BackgroundColor}.");
            System.Console.WriteLine($"                     |");
        #endif

        var files = e?.DataTransfer.TryGetFiles();
        if(files == null) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]              |----> No Drag'N'Dropped files found, variable \"files\" = null.");
                System.Console.WriteLine($"                     |");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]                 |----> Number of file(s) entered: {files.Count()}");
            foreach (var item in files)
                System.Console.WriteLine($"[OK]                         |----> {files.LastIndexOf(item)}. Filename: {item.Name}");

            System.Console.WriteLine();
        #endif
    }
    private void Files_OnDragLeave(object? sender, Avalonia.Input.DragEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]         Function \"IncomeView.Income_OnDragLeave(object? sender, Avalonia.Input.DragEventArgs e)\" Called.");
            System.Console.WriteLine($"                     |----> Sender:");
            System.Console.WriteLine($"                     |           |----> Type: {sender?.GetType()}");
            System.Console.WriteLine($"                     |");
            System.Console.WriteLine($"                     |----> Event:");
            System.Console.WriteLine($"                     |           |----> Type: {e?.GetType().FullName}");
            System.Console.WriteLine($"                     |");
            System.Console.WriteLine($"[OK]                 |----> Dragged files left the Drag'N'Drop section");
        #endif

        if (DataContext is not IncomeViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine("[ERROR]              |----> DataContext in IncomeViewModel.axaml.cs IS NOT IncomeViewModel.");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine("[OK]                  |----> Datacontext in IncomeViewModel.axaml.cs is IncomeViewModel.");
        #endif

        viewModel.Files_DragNDrop_Box_BackgroundColor = "#FFFFFFFF";

        #if DEBUG
            System.Console.WriteLine($"[OK]                 |----> Drag'N'Drop image background changed back to default color = {viewModel.Files_DragNDrop_Box_BackgroundColor}.");
        #endif
        
        var files = e?.DataTransfer.TryGetFiles();
        if(files == null) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]              |----> No Drag'N'Dropped files found, variable \"files\" = null.");
                System.Console.WriteLine();
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]                 |----> File(s) leaving {files.Count()}");
            foreach (var item in files)
                System.Console.WriteLine($"[OK]                             |----> {files.LastIndexOf(item)}. Filename: {item.Name}");

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
            System.Console.WriteLine($"[OK]    Function \"IncomeView.OnSelectedCategoryChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"                     |----> Sender:");
            System.Console.WriteLine($"                     |          |----> Type:     {sender?.GetType()}");
            System.Console.WriteLine($"                     |          |----> Fullname: {sender?.GetType().FullName}");
            System.Console.WriteLine($"                     |");
        #endif
        
        if (DataContext is not IncomeViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]     |----> DataContext in IncomeView.axaml.cs IS NOT IncomeViewModel.");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine($"[OK]        |----> Datacontext in IncomeView.axaml.cs is IncomeViewModel.");
            System.Console.WriteLine($"[OK]        |----> Event source type is \"TreeView\".");
        #endif

        if (viewModel.SelectedCategory is CategoryViewModel category) {
            #if DEBUG
                System.Console.WriteLine($"[OK]                  |----> Selected item \"{viewModel.SelectedCategory.GetType()}\" type is \"{category.GetType()}\".");
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
                System.Console.WriteLine($"[ERROR]               |----> Selected item does not belong to \"CategoryViewModel\".\"{viewModel.SelectedCategory?.GetType()}\".");
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
            System.Console.WriteLine($"[OK]     Function \"ExpenseView.OnSelectedCategoryChanged(object? sender, Avalonia.Controls.SelectionChangedEventArgs e)\" Called.");
            System.Console.WriteLine($"                 |----> Sender:");
            System.Console.WriteLine($"                 |          |----> Type:     {sender?.GetType()}");
            System.Console.WriteLine($"                 |          |----> Fullname: {sender?.GetType().FullName}");
            System.Console.WriteLine($"                 |");
        #endif
        
        if (DataContext is not IncomeViewModel viewModel) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]          |----> DataContext in ExpenseViewModel.axaml.cs IS NOT ExpenseViewModel.");
            #endif
            return;
        }
        
        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> Datacontext in ExpenseViewModel.axaml.cs is ExpenseViewModel.");
            System.Console.WriteLine($"[OK]             |----> Event source type is \"TreeView\".");
        #endif


        foreach( var category in viewModel.Categories) {
            category.Children.Clear();
        }

        if(!viewModel.LoadIncomeData(DateOnly.FromDateTime(viewModel.PickedDate))) {
            #if DEBUG
                System.Console.WriteLine($"[Warning]        |----> No data loaded or found.");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[OK]             |----> Data Successfully loaded.");
            #endif
        }

        #if DEBUG
            System.Console.WriteLine($"");
        #endif
    }
}
