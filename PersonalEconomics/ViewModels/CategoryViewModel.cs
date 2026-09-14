
using System.Collections.ObjectModel;
using CommunityToolkit.Mvvm.ComponentModel;
public partial class CategoryViewModel : ObservableObject {
    [ObservableProperty]
    public partial string Name { get; set; }

    [ObservableProperty]
    public partial bool IsCategoryRoot { get; set; }

    [ObservableProperty]
    public partial bool CanDelete { get; set; }

    public ObservableCollection<CategoryViewModel> Children { get; } = new();
}