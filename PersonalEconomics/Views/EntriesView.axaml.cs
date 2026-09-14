using System;
using System.IO;
using System.Linq;
using System.Text.Json;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform.Storage;
using Personal_Economy_Display.ViewModels;

namespace Personal_Economy_Display.Views;

public partial class EntriesView : UserControl {
    public EntriesView() {
        InitializeComponent();
    }
}