using System;
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
using System.Linq;
using CommunityToolkit.Mvvm.Input;
using System.Text.Json;
using System.IO;
using Microsoft.VisualBasic;
namespace Personal_Economy_Display.ViewModels;

public partial class IncomeViewModel : ObservableObject {

    public IncomeViewModel() {
        
        Categories.Add(new CategoryViewModel {
            Name = "Government Support",
            IsCategoryRoot = true,
        });

        Categories.Add(new CategoryViewModel {
            Name = "Work",
            IsCategoryRoot = true,
        });

        if(!LoadIncomeData(DateOnly.FromDateTime(PickedDate))) {
            #if DEBUG
                System.Console.WriteLine($"[Warning]        |---> No data loaded or found.");
                System.Console.WriteLine($"");
            #endif
        } else {
            #if DEBUG
                System.Console.WriteLine($"[OK]             |---> Data Successfully loaded.");
                System.Console.WriteLine($"");
            #endif
        }
    }

    

    [ObservableProperty]
    public partial DateTime PickedDate { get; set; } = DateTime.Now;
    [ObservableProperty]
    public partial string Files_DragNDrop_Box_BackgroundColor { get; set; } = "#FFFFFFFF";

    public ObservableCollection<PdfFile_Processor> Files { get; } = new();

    public ObservableCollection<CategoryViewModel> Categories { get; } = new();

    [ObservableProperty]
    public partial CategoryViewModel? SelectedCategory { get; set; } = null;

    public bool LoadIncomeData(DateOnly day) {
        string path = string.Concat($"DataEntries/{day.Year.ToString()}/{day.Month.ToString()}/{day.Day.ToString()}/Income");
        
        if(!Directory.Exists(path)) {
            return false;
        }

        if(Directory.Exists($"{path}/Files")) {
            var ListOfFiles = Directory.EnumerateFiles($"{path}/Files");
            foreach (var file in ListOfFiles) {
                var pdf = new PdfFile_Processor(file);
                if (pdf.Thumbnail != null) {
                    pdf.Thumbnail = AvaloniaPdfThumbnailConverter.ToBitmap((PdfThumbnail)pdf.Thumbnail);
                }
                Files.Add(pdf);
            }
        }

        if(Directory.Exists($"{path}/Government Support")) {
            var ListOfFiles = Directory.EnumerateFiles($"{path}/Government Support");
            foreach (var file in ListOfFiles) {
                try {
                    #if DEBUG
                        System.Console.WriteLine($"                 |----> Deserialising JSON file:");
                        System.Console.WriteLine($"                 |           |----> Filename:        {file}");
                        System.Console.WriteLine($"                 |");
                    #endif

                    string ReadFile = File.ReadAllText(file);
                    GovernmentSupport? _governmentSupport = JsonSerializer.Deserialize<GovernmentSupport>(ReadFile);
                    if(_governmentSupport is not null) {
                        Categories.FirstOrDefault(cat => cat.Name == "Government Support" && cat.IsCategoryRoot == true)?.Children.Add(new GovernmentSupportViewModel(_governmentSupport) {
                                Name = Path.GetFileName(file),
                                CanDelete = true
                            }
                        );
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> _governmentSupport is NULL");
                        #endif
                        return false;
                    }

                    #if DEBUG
                        GovernmentSupportViewModel? viewModel = Categories.FirstOrDefault(cat => cat.Name == "Government Support" && cat.IsCategoryRoot == true)?.Children.Last() as GovernmentSupportViewModel;
                        System.Console.WriteLine($"[OK]             |----> File deserialized:");
                        System.Console.WriteLine($"                 |           |----> Name:   {Categories.FirstOrDefault(cat => cat.Name == "GovernmentSupport" && cat.IsCategoryRoot == true)?.Children.Last().Name}");
                        System.Console.WriteLine($"                 |           |----> Government Name: {viewModel?._governmentSupport.GovernmentName}");
                        System.Console.WriteLine($"                 |           |----> Support Type:    {viewModel?._governmentSupport.SupportType}");
                        System.Console.WriteLine($"                 |           |----> Amount: {viewModel?._governmentSupport.Amount}");
                        System.Console.WriteLine($"                 |           |----> Note:   {viewModel?._governmentSupport.Note}");
                        System.Console.WriteLine($"                 |");
                    #endif
                } catch(ArgumentNullException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(JsonException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    JsonException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(NotSupportedException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                }
            }
        }
        
        if(Directory.Exists($"{path}/Work")) {
            var ListOfFiles = Directory.EnumerateFiles($"{path}/Work");
            foreach (var file in ListOfFiles) {
                try {
                    #if DEBUG
                        System.Console.WriteLine($"                 |----> Deserialising JSON file:");
                        System.Console.WriteLine($"                 |           |----> Filename: {file}");
                        System.Console.WriteLine($"                 |");
                    #endif
                    
                    // This reads and deserializes object
                    string ReadFile = File.ReadAllText(file);
                    Work? _work = JsonSerializer.Deserialize<Work>(ReadFile);
                    if(_work is not null) {
                        Categories.FirstOrDefault(cat => cat.Name == "Work" && cat.IsCategoryRoot == true)?.Children.Add(new WorkViewModel(_work) {
                                Name = Path.GetFileName(file),
                                CanDelete = true
                            }
                        );
                    } else {
                        #if DEBUG
                            System.Console.WriteLine($"[ERROR]          |----> _work is NULL");
                        #endif
                        return false;
                    }

                    #if DEBUG
                        WorkViewModel? viewModel = Categories.FirstOrDefault(cat => cat.Name == "Work" && cat.IsCategoryRoot)?.Children?.LastOrDefault() as WorkViewModel;
                        System.Console.WriteLine($"[OK]             |----> File deserialized:");
                        System.Console.WriteLine($"                 |           |----> Name:         {Categories.FirstOrDefault(cat => cat.Name == "Work" && cat.IsCategoryRoot == true)?.Children.Last().Name}");
                        System.Console.WriteLine($"                 |           |----> Company:      {viewModel?._work.Company}");
                        System.Console.WriteLine($"                 |           |----> Position:     {viewModel?._work.Position}");
                        System.Console.WriteLine($"                 |           |----> Salary:       {viewModel?._work.Salary}");
                        System.Console.WriteLine($"                 |           |----> Bonus:        {viewModel?._work.Bonus}");
                        System.Console.WriteLine($"                 |           |----> Taxed Amount: {viewModel?._work.TaxedAmount}");
                        System.Console.WriteLine($"                 |           |----> Total:        {viewModel?._work.Total}");
                        System.Console.WriteLine($"                 |           |----> Note:         {viewModel?._work.Note}");
                        System.Console.WriteLine($"                 |");
                    
                    #endif
                } catch(ArgumentNullException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    ArgumentNullException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(JsonException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    JsonException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                } catch(NotSupportedException thrownException) {
                    #if DEBUG
                        System.Console.WriteLine($"[ERROR]          |----> Exception thrown:");
                        System.Console.WriteLine($"                             |----> Exception name:    NotSupportedException");
                        System.Console.WriteLine($"                             |----> Exception data:    {thrownException.Data}");
                        System.Console.WriteLine($"                             |----> Exception message: {thrownException.Message}");
                        System.Console.WriteLine($"");
                    #endif
                    return false;
                }
            }
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> Files Loaded");
        #endif
        return true;
    }

    [RelayCommand]
    private void AddCategory(CategoryViewModel RootCategory) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    \"IncomeViewModel.AddCategory(IncomeViewModel RootCategory)\" function Called");
        #endif

        if (RootCategory is null) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]          |----> RootCategory = null.");
            #endif
            return;
        }

        int nextNumber = RootCategory.Children.Count + 1;

        #if DEBUG
            System.Console.WriteLine($"                 |----> RootCategory = {RootCategory}."); 
        #endif

        if(RootCategory.Name is "Government Support") {
            RootCategory.Children.Add(new GovernmentSupportViewModel(new GovernmentSupport()) {
                Name = $"{RootCategory.Name} {nextNumber}",
                CanDelete = true,
            });
            
            #if DEBUG
                System.Console.WriteLine($"                |----> RootCategory type is of \"GovernmentSupportViewModel\".");
                System.Console.WriteLine($"[OK]                        |----> New child category {RootCategory.Children.FirstOrDefault( f => f.Name == "{RootCategory.Name} {nextNumber}")?.Name} added to root category {RootCategory.Name}.");
                System.Console.WriteLine($"                            |----> New count is = {nextNumber}.");
            #endif

        } else if(RootCategory.Name is "Work") {
            RootCategory.Children.Add(new WorkViewModel(new Work()) {
                Name = $"{RootCategory.Name} {nextNumber}",
                CanDelete = true,
            });

            #if DEBUG
                System.Console.WriteLine($"[OK]             |----> RootCategory type is of \"WorkViewModel\".");
                System.Console.WriteLine($"                             |----> New child category {RootCategory.Children.FirstOrDefault( f => f.Name == "{RootCategory.Name} {nextNumber}")?.Name} added to root category {RootCategory.Name}.");
                System.Console.WriteLine($"                             |----> New count is = {nextNumber}");
            #endif

        }

        #if DEBUG
            System.Console.WriteLine();
        #endif
    }

    [RelayCommand]
    private void RemoveCategory(CategoryViewModel category) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    \"IncomeViewModel.RemoveCategory(CategoryViewModel category)\" function is triggered.");
            System.Console.WriteLine($"                |----> Searching for parent category ...");
        #endif

        var parentCategory = Categories.FirstOrDefault(x => x.IsCategoryRoot && x.Children.Contains(category));

        if (parentCategory == null) {
            #if DEBUG
                System.Console.WriteLine($"[ERROR]         |----> Variable \"parentCategory\" = null.");
            #endif
            return;
        }

        #if DEBUG
            System.Console.WriteLine($"[OK]             |----> Parent category found: \"{parentCategory.Name}\" is parent category of \"{category.Name}\".");
        #endif
        bool error = parentCategory.Children.Remove(category);

        #if DEBUG
            if(error == true) {
                System.Console.WriteLine($"[OK]                         |----> Child category \"{category.Name}\" removed from \"{parentCategory.Name}\".");
            } else {
                System.Console.WriteLine($"[ERROR]                      |----> Child category \"{category.Name}\" could NOT be removed from \"{parentCategory.Name}\".");
                return;
            }
        #endif

        if (SelectedCategory == category) {
            SelectedCategory = null;
            
            #if DEBUG
                System.Console.WriteLine($"[OK]             |----> \"{category.Name}\" unselected.");
            #endif
        }
        #if DEBUG
            System.Console.WriteLine($"");
        #endif
    }

}