using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using Avalonia.Controls;
using Personal_Economy_Display.ViewModels;

namespace Personal_Economy_Display.Views;

public partial class MainWindow : Window
{
    static AddEditEntryWindow? DataEntryWindow = null;


    public MainWindow()
    {
        InitializeComponent();

        LoadFinancialData();
    }


    // =====================================================
    // LOAD ALL FINANCIAL DATA
    // =====================================================
    private ScottPlot.Panels.LegendPanel? last10YearsLegend;
    private ScottPlot.Panels.LegendPanel? last365DaysLegend;

    private void LoadFinancialData()
    {
        string dataPath = Path.Combine(
            AppContext.BaseDirectory,
            "DataEntries"
        );

        Console.WriteLine($"Data path: {dataPath}");


        // =====================================================
        // RESET LAST 10 YEARS PLOT
        // =====================================================

        if (last10YearsLegend != null)
        {
            Last10Years.Plot.Remove(
                last10YearsLegend
            );

            last10YearsLegend = null;
        }

        Last10Years.Plot.Clear();

        Last10Years.Plot.Axes.Rules.Clear();


        // =====================================================
        // RESET LAST 365 DAYS PLOT
        // =====================================================

        if (last365DaysLegend != null)
        {
            Last365Days.Plot.Remove(
                last365DaysLegend
            );

            last365DaysLegend = null;
        }

        Last365Days.Plot.Clear();

        Last365Days.Plot.Axes.Rules.Clear();


        // =====================================================
        // LOAD DATA
        // =====================================================

        List<MonthlyFinancialData> monthlyData =
            GetMonthlyFinancialData(dataPath);

        List<DailyFinancialData> dailyData =
            GetDailyFinancialData(dataPath);


        Console.WriteLine(
            $"Months found: {monthlyData.Count}"
        );

        Console.WriteLine(
            $"Days found: {dailyData.Count}"
        );


        // =====================================================
        // LAST 10 YEARS
        // MONTHLY INCOME / SPENDING
        // =====================================================

        if (monthlyData.Count > 0)
        {
            List<MonthlyFinancialData> last10Years =
                monthlyData
                    .OrderBy(x => x.Month)
                    .TakeLast(120)
                    .ToList();


            double[] xs =
                last10Years
                    .Select(x => x.Month.ToOADate())
                    .ToArray();


            double[] spending =
                last10Years
                    .Select(x => x.SpendingTotal)
                    .ToArray();


            double[] income =
                last10Years
                    .Select(x => x.IncomeTotal)
                    .ToArray();


            // -------------------------------------------------
            // Spending line
            // -------------------------------------------------

            var spendingPlot =
                Last10Years.Plot.Add.Scatter(
                    xs,
                    spending
                );

            spendingPlot.LineWidth = 2;
            spendingPlot.MarkerSize = 5;

            spendingPlot.LegendText =
                "Expenses";


            // -------------------------------------------------
            // Income line
            // -------------------------------------------------

            var incomePlot =
                Last10Years.Plot.Add.Scatter(
                    xs,
                    income
                );

            incomePlot.LineWidth = 2;
            incomePlot.MarkerSize = 5;

            incomePlot.LegendText =
                "Income";


            // -------------------------------------------------
            // Legend
            // -------------------------------------------------

            last10YearsLegend =
                Last10Years.Plot.ShowLegend(
                    ScottPlot.Edge.Right
                );


            // -------------------------------------------------
            // Plot labels
            // -------------------------------------------------

            Last10Years.Plot.Title(
                "Monthly Income and Expenses"
            );

            Last10Years.Plot.XLabel(
                "Month"
            );

            Last10Years.Plot.YLabel(
                "Amount (kr)"
            );


            // -------------------------------------------------
            // Date axis
            // -------------------------------------------------

            Last10Years.Plot.Axes.DateTimeTicksBottom();


            // -------------------------------------------------
            // Automatically fit data
            // -------------------------------------------------

            Last10Years.Plot.Axes.AutoScale();


            double minY =
                Math.Min(
                    income.Min(),
                    spending.Min()
                );

            double maxY =
                Math.Max(
                    income.Max(),
                    spending.Max()
                );

            double xMin =
                xs.Min();

            double xMax =
                xs.Max();


            double yRange =
                maxY - minY;

            double xRange =
                xMax - xMin;


            // -------------------------------------------------
            // 10% padding around data
            // -------------------------------------------------

            double xPadding =
                xRange * 0.10;

            double yPadding =
                yRange * 0.10;


            double boundaryXMin =
                xMin - xPadding;

            double boundaryXMax =
                xMax + xPadding;

            double boundaryYMin =
                minY - yPadding;

            double boundaryYMax =
                maxY + yPadding;


            double xSpan =
                boundaryXMax - boundaryXMin;

            double ySpan =
                boundaryYMax - boundaryYMin;


            var boundary =
                new ScottPlot.AxisLimits(
                    boundaryXMin,
                    boundaryXMax,
                    boundaryYMin,
                    boundaryYMax
                );


            // -------------------------------------------------
            // Prevent zooming out farther than padded range
            // -------------------------------------------------

            Last10Years.Plot.Axes.Rules.Add(
                new ScottPlot.AxisRules.MaximumSpan(
                    Last10Years.Plot.Axes.Bottom,
                    Last10Years.Plot.Axes.Left,
                    xSpan,
                    ySpan
                )
            );


            // -------------------------------------------------
            // Prevent dragging outside padded range
            // -------------------------------------------------

            Last10Years.Plot.Axes.Rules.Add(
                new ScottPlot.AxisRules.MaximumBoundary(
                    Last10Years.Plot.Axes.Bottom,
                    Last10Years.Plot.Axes.Left,
                    boundary
                )
            );
        }
        else
        {
            Last10Years.Plot.Title(
                "No monthly data found"
            );
        }


        Last10Years.Refresh();


        // =====================================================
        // LAST 365 DAYS
        // DAILY INCOME / SPENDING
        // =====================================================

        if (dailyData.Count > 0)
        {
            DateTime lastDate =
                dailyData.Max(x => x.Day);


            DateTime firstDate =
                lastDate.AddDays(-364);


            // -------------------------------------------------
            // Create every calendar day
            // -------------------------------------------------

            List<DailyFinancialData> last365Days =
                new List<DailyFinancialData>();


            for (
                DateTime day = firstDate;
                day <= lastDate;
                day = day.AddDays(1))
            {
                DailyFinancialData? existingData =
                    dailyData.FirstOrDefault(
                        x => x.Day == day
                    );


                if (existingData != null)
                {
                    last365Days.Add(
                        existingData
                    );
                }
                else
                {
                    last365Days.Add(
                        new DailyFinancialData
                        {
                            Day = day,
                            SpendingTotal = 0,
                            IncomeTotal = 0
                        }
                    );
                }
            }


            double[] xs =
                last365Days
                    .Select(x => x.Day.ToOADate())
                    .ToArray();


            double[] spending =
                last365Days
                    .Select(x => x.SpendingTotal)
                    .ToArray();


            double[] income =
                last365Days
                    .Select(x => x.IncomeTotal)
                    .ToArray();


            // -------------------------------------------------
            // Spending line
            // -------------------------------------------------

            var spendingPlot =
                Last365Days.Plot.Add.Scatter(
                    xs,
                    spending
                );

            spendingPlot.LineWidth = 2;
            spendingPlot.MarkerSize = 4;

            spendingPlot.LegendText =
                "Expenses";


            // -------------------------------------------------
            // Income line
            // -------------------------------------------------

            var incomePlot =
                Last365Days.Plot.Add.Scatter(
                    xs,
                    income
                );

            incomePlot.LineWidth = 2;
            incomePlot.MarkerSize = 4;

            incomePlot.LegendText =
                "Income";


            // -------------------------------------------------
            // Legend
            // -------------------------------------------------

            last365DaysLegend =
                Last365Days.Plot.ShowLegend(
                    ScottPlot.Edge.Right
                );


            // -------------------------------------------------
            // Plot labels
            // -------------------------------------------------

            Last365Days.Plot.Title(
                "Daily Income and Expenses - Last 365 Days"
            );

            Last365Days.Plot.XLabel(
                "Date"
            );

            Last365Days.Plot.YLabel(
                "Amount (kr)"
            );


            // -------------------------------------------------
            // Date axis
            // -------------------------------------------------

            Last365Days.Plot.Axes.DateTimeTicksBottom();


            // -------------------------------------------------
            // Automatically fit data
            // -------------------------------------------------

            Last365Days.Plot.Axes.AutoScale();


            double minY =
                Math.Min(
                    income.Min(),
                    spending.Min()
                );

            double maxY =
                Math.Max(
                    income.Max(),
                    spending.Max()
                );

            double xMin =
                xs.Min();

            double xMax =
                xs.Max();


            double yRange =
                maxY - minY;

            double xRange =
                xMax - xMin;


            // -------------------------------------------------
            // 10% padding around data
            // -------------------------------------------------

            double xPadding =
                xRange * 0.10;

            double yPadding =
                yRange * 0.10;


            double boundaryXMin =
                xMin - xPadding;

            double boundaryXMax =
                xMax + xPadding;

            double boundaryYMin =
                minY - yPadding;

            double boundaryYMax =
                maxY + yPadding;


            double xSpan =
                boundaryXMax - boundaryXMin;

            double ySpan =
                boundaryYMax - boundaryYMin;


            var boundary =
                new ScottPlot.AxisLimits(
                    boundaryXMin,
                    boundaryXMax,
                    boundaryYMin,
                    boundaryYMax
                );


            // -------------------------------------------------
            // Prevent zooming out farther than padded range
            // -------------------------------------------------

            Last365Days.Plot.Axes.Rules.Add(
                new ScottPlot.AxisRules.MaximumSpan(
                    Last365Days.Plot.Axes.Bottom,
                    Last365Days.Plot.Axes.Left,
                    xSpan,
                    ySpan
                )
            );


            // -------------------------------------------------
            // Prevent dragging outside padded range
            // -------------------------------------------------

            Last365Days.Plot.Axes.Rules.Add(
                new ScottPlot.AxisRules.MaximumBoundary(
                    Last365Days.Plot.Axes.Bottom,
                    Last365Days.Plot.Axes.Left,
                    boundary
                )
            );
        }
        else
        {
            Last365Days.Plot.Title(
                "No daily data found"
            );
        }


        Last365Days.Refresh();
    }




    // =====================================================
    // GET MONTHLY FINANCIAL DATA
    // =====================================================

    private List<MonthlyFinancialData>
        GetMonthlyFinancialData(
            string rootPath)
    {
        var monthlyData =
            new Dictionary<DateTime, MonthlyFinancialData>();


        if (!Directory.Exists(rootPath))
            return new List<MonthlyFinancialData>();


        string[] files =
            Directory.GetFiles(
                rootPath,
                "*.json",
                SearchOption.AllDirectories
            );


        foreach (string file in files)
        {
            try
            {
                DateTime? date =
                    GetDateFromPath(file);


                if (date == null)
                    continue;


                string? category =
                    GetCategoryFromPath(file);


                if (category == null)
                    continue;


                string json =
                    File.ReadAllText(file);


                using JsonDocument document =
                    JsonDocument.Parse(json);


                JsonElement root =
                    document.RootElement;


                DateTime month =
                    new DateTime(
                        date.Value.Year,
                        date.Value.Month,
                        1
                    );


                if (!monthlyData.ContainsKey(month))
                {
                    monthlyData[month] =
                        new MonthlyFinancialData
                        {
                            Month = month
                        };
                }


                MonthlyFinancialData data =
                    monthlyData[month];


                // ==========================================
                // EXPENSE
                // ==========================================

                if (category == "Expense")
                {
                    AddExpenseData(
                        data,
                        root
                    );
                }


                // ==========================================
                // INCOME
                // ==========================================

                else if (category == "Income")
                {
                    AddIncomeData(
                        data,
                        root
                    );
                }
            }
            catch (JsonException)
            {
                continue;
            }
            catch (Exception)
            {
                continue;
            }
        }


        return monthlyData
            .OrderBy(x => x.Key)
            .Select(x => x.Value)
            .ToList();
    }


    // =====================================================
    // GET DAILY FINANCIAL DATA
    // =====================================================

    private List<DailyFinancialData>
        GetDailyFinancialData(
            string rootPath)
    {
        var dailyData =
            new Dictionary<DateTime, DailyFinancialData>();


        if (!Directory.Exists(rootPath))
            return new List<DailyFinancialData>();


        string[] files =
            Directory.GetFiles(
                rootPath,
                "*.json",
                SearchOption.AllDirectories
            );


        foreach (string file in files)
        {
            try
            {
                DateTime? date =
                    GetDateFromPath(file);


                if (date == null)
                    continue;


                string? category =
                    GetCategoryFromPath(file);


                if (category == null)
                    continue;


                string json =
                    File.ReadAllText(file);


                using JsonDocument document =
                    JsonDocument.Parse(json);


                JsonElement root =
                    document.RootElement;


                DateTime day =
                    date.Value.Date;


                if (!dailyData.ContainsKey(day))
                {
                    dailyData[day] =
                        new DailyFinancialData
                        {
                            Day = day
                        };
                }


                DailyFinancialData data =
                    dailyData[day];


                // ==========================================
                // EXPENSE
                // ==========================================

                if (category == "Expense")
                {
                    if (root.TryGetProperty(
                        "Total",
                        out JsonElement total))
                    {
                        data.SpendingTotal +=
                            total.GetDouble();
                    }
                }


                // ==========================================
                // INCOME
                // ==========================================

                else if (category == "Income")
                {
                    // Work
                    if (root.TryGetProperty(
                        "Total",
                        out JsonElement total))
                    {
                        data.IncomeTotal +=
                            total.GetDouble();
                    }

                    // Government Support
                    else if (root.TryGetProperty(
                        "Amount",
                        out JsonElement amount))
                    {
                        data.IncomeTotal +=
                            amount.GetDouble();
                    }
                }
            }
            catch (JsonException)
            {
                continue;
            }
            catch (Exception)
            {
                continue;
            }
        }


        return dailyData
            .OrderBy(x => x.Key)
            .Select(x => x.Value)
            .ToList();
    }


    // =====================================================
    // EXPENSE DATA
    // =====================================================

    private void AddExpenseData(
        MonthlyFinancialData data,
        JsonElement root)
    {
        // ==========================================
        // OVERALL EXPENSE TOTAL
        // ==========================================

        if (root.TryGetProperty(
            "Total",
            out JsonElement total))
        {
            data.SpendingTotal +=
                total.GetDouble();
        }


        // ==========================================
        // GROCERY
        // ==========================================

        AddProperty(
            root,
            "Vegetables",
            value => data.Vegetables += value
        );

        AddProperty(
            root,
            "Meat",
            value => data.Meat += value
        );

        AddProperty(
            root,
            "Fish",
            value => data.Fish += value
        );

        AddProperty(
            root,
            "CannedProducts",
            value => data.CannedProducts += value
        );

        AddProperty(
            root,
            "Candy",
            value => data.Candy += value
        );

        AddProperty(
            root,
            "Soda",
            value => data.Soda += value
        );

        AddProperty(
            root,
            "HouseholdItems",
            value => data.HouseholdItems += value
        );

        AddProperty(
            root,
            "OtherItems",
            value => data.OtherItems += value
        );


        // ==========================================
        // ENTERTAINMENT
        // ==========================================

        AddProperty(
            root,
            "StreamingServicesSubscriptions",
            value => data.StreamingServicesSubscriptions += value
        );

        AddProperty(
            root,
            "ConcertTickets",
            value => data.ConcertTickets += value
        );

        AddProperty(
            root,
            "SportingEvents",
            value => data.SportingEvents += value
        );

        AddProperty(
            root,
            "Movies",
            value => data.Movies += value
        );

        AddProperty(
            root,
            "Books",
            value => data.Books += value
        );

        AddProperty(
            root,
            "Hobbies",
            value => data.Hobbies += value
        );

        AddProperty(
            root,
            "Vacation",
            value => data.Vacation += value
        );

        AddProperty(
            root,
            "BarHopping",
            value => data.BarHopping += value
        );


        // ==========================================
        // MISCELLANEOUS
        // ==========================================

        AddProperty(
            root,
            "TakeoutFood",
            value => data.TakeoutFood += value
        );

        AddProperty(
            root,
            "Electronics",
            value => data.Electronics += value
        );


        // ==========================================
        // PERSONAL CARE / GROOMING
        // ==========================================

        AddProperty(
            root,
            "HygieneProducts",
            value => data.HygieneProducts += value
        );

        AddProperty(
            root,
            "Clothes",
            value => data.Clothes += value
        );

        AddProperty(
            root,
            "Haircuts",
            value => data.Haircuts += value
        );


        // ==========================================
        // VEHICLE
        // ==========================================

        AddProperty(
            root,
            "Fuel",
            value => data.Fuel += value
        );

        AddProperty(
            root,
            "Maintenance",
            value => data.Maintenance += value
        );

        AddProperty(
            root,
            "Repairs",
            value => data.Repairs += value
        );
    }


    // =====================================================
    // INCOME DATA
    // =====================================================

    private void AddIncomeData(
        MonthlyFinancialData data,
        JsonElement root)
    {
        // ==========================================
        // WORK
        // ==========================================

        if (root.TryGetProperty(
            "Total",
            out JsonElement total))
        {
            data.IncomeTotal +=
                total.GetDouble();

            data.Work +=
                total.GetDouble();
        }


        // ==========================================
        // GOVERNMENT SUPPORT
        // ==========================================

        else if (root.TryGetProperty(
            "Amount",
            out JsonElement amount))
        {
            data.IncomeTotal +=
                amount.GetDouble();

            data.GovernmentSupport +=
                amount.GetDouble();
        }
    }


    // =====================================================
    // ADD JSON PROPERTY
    // =====================================================

    private void AddProperty(
        JsonElement root,
        string propertyName,
        Action<double> addValue)
    {
        if (root.TryGetProperty(
            propertyName,
            out JsonElement property))
        {
            if (property.ValueKind ==
                JsonValueKind.Number)
            {
                addValue(
                    property.GetDouble()
                );
            }
        }
    }


    // =====================================================
    // GET EXPENSE / INCOME FROM PATH
    // =====================================================

    private string? GetCategoryFromPath(
        string filePath)
    {
        string normalizedPath =
            filePath.Replace('\\', '/');


        string[] parts =
            normalizedPath.Split(
                '/',
                StringSplitOptions.RemoveEmptyEntries
            );


        foreach (string part in parts)
        {
            if (part.Equals(
                "Expense",
                StringComparison.OrdinalIgnoreCase))
            {
                return "Expense";
            }


            if (part.Equals(
                "Income",
                StringComparison.OrdinalIgnoreCase))
            {
                return "Income";
            }
        }


        return null;
    }


    // =====================================================
    // GET DATE FROM PATH
    // =====================================================

    private DateTime? GetDateFromPath(
        string filePath)
    {
        DirectoryInfo? fileDirectory =
            Directory.GetParent(filePath);


        DirectoryInfo? expenseIncomeDirectory =
            fileDirectory?.Parent;


        DirectoryInfo? dayDirectory =
            expenseIncomeDirectory?.Parent;


        DirectoryInfo? monthDirectory =
            dayDirectory?.Parent;


        DirectoryInfo? yearDirectory =
            monthDirectory?.Parent;


        if (dayDirectory == null ||
            monthDirectory == null ||
            yearDirectory == null)
        {
            return null;
        }


        if (!int.TryParse(
            dayDirectory.Name,
            out int day))
        {
            return null;
        }


        if (!int.TryParse(
            monthDirectory.Name,
            out int month))
        {
            return null;
        }


        if (!int.TryParse(
            yearDirectory.Name,
            out int year))
        {
            return null;
        }


        try
        {
            return new DateTime(
                year,
                month,
                day
            );
        }
        catch
        {
            return null;
        }
    }



    // =====================================================
    // MONTHLY DATA CLASS
    // =====================================================

    private class MonthlyFinancialData
    {
        public DateTime Month { get; set; }


        // Overall totals

        public double SpendingTotal { get; set; } = 0;

        public double IncomeTotal { get; set; } = 0;


        // Grocery

        public double Vegetables { get; set; } = 0;
        public double Meat { get; set; } = 0;
        public double Fish { get; set; } = 0;
        public double CannedProducts { get; set; } = 0;
        public double Candy { get; set; } = 0;
        public double Soda { get; set; } = 0;
        public double HouseholdItems { get; set; } = 0;
        public double OtherItems { get; set; } = 0;


        // Entertainment

        public double StreamingServicesSubscriptions { get; set; } = 0;
        public double ConcertTickets { get; set; } = 0;
        public double SportingEvents { get; set; } = 0;
        public double Movies { get; set; } = 0;
        public double Books { get; set; } = 0;
        public double Hobbies { get; set; } = 0;
        public double Vacation { get; set; } = 0;
        public double BarHopping { get; set; } = 0;


        // Miscellaneous

        public double TakeoutFood { get; set; } = 0;
        public double Electronics { get; set; } = 0;


        // Personal Care & Grooming

        public double HealthInsurance { get; set; } = 0;
        public double LifeInsurance { get; set; } = 0;
        public double HygieneProducts { get; set; } = 0;
        public double Clothes { get; set; } = 0;
        public double Haircuts { get; set; } = 0;


        // Vehicle

        public double VehicleInsurance { get; set; } = 0;
        public double Fuel { get; set; } = 0;
        public double Maintenance { get; set; } = 0;
        public double Repairs { get; set; } = 0;


        // Income

        public double Work { get; set; } = 0;
        public double GovernmentSupport { get; set; } = 0;
    }


    // =====================================================
    // DAILY DATA CLASS
    // =====================================================

    private class DailyFinancialData
    {
        public DateTime Day { get; set; }

        public double SpendingTotal { get; set; } = 0;

        public double IncomeTotal { get; set; } = 0;
    }



    // =====================================================
    // ADD / EDIT DATA BUTTON
    // =====================================================

    private void OpenAddEditDataButton_Click( object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
        #if DEBUG
            Console.WriteLine(
                $"[OK] Function " +
                $"\"MainWindow.OpenAddEditDataButton_Click\" " +
                $"called"
            );

            Console.WriteLine(
                $"[OK] New Window Opened: " +
                $"AddEditEntryWindow"
            );
        #endif

        DataEntryWindow = new AddEditEntryWindow();

        DataEntryWindow.Show();
    }

    private void ReloadData_Click( object? sender, Avalonia.Interactivity.RoutedEventArgs e) {
        #if DEBUG
            System.Console.WriteLine($"[OK]    Function \"MainView.ReloadData_Click(object? sender, Avalonia.Interactivity.RoutedEventArgs e)\" Called.");
            System.Console.WriteLine($"             |----> Sender:");
            System.Console.WriteLine($"             |          |----> Type:       {sender?.GetType()}");
            System.Console.WriteLine($"             |");
        #endif

        LoadFinancialData();
    }

}