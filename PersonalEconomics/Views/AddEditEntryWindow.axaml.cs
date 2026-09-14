using System;
using System.Linq;
using Avalonia.Controls;
using Avalonia.Input;
using Avalonia.Platform.Storage;
using Personal_Economy_Display.ViewModels;
using ScottPlot;

namespace Personal_Economy_Display.Views;

public partial class AddEditEntryWindow : Window {
    public AddEditEntryWindow() {
        InitializeComponent();
        DataContext = new AddEditEntryViewModel();
    }

    ~AddEditEntryWindow() {
    }

    /*
    ******************************************************************************************************
    *********************************            Expense Section           *******************************
    *********************************            Expense Section           *******************************
    ******************************************************************************************************
    */
    

    /*
    ****************************************************************************************************
    ********************************             Income Section           ******************************
    ********************************             Income Section           ******************************
    ********************************             Income Section           ******************************
    ****************************************************************************************************
    */
    

}


