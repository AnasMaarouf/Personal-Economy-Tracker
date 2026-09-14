using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Insurance : INotifyPropertyChanged {
    private string _company = string.Empty;
    private string _type = string.Empty;
    private double _amount;
    private string _note = string.Empty;

    public string Company {
        get => _company;
        set {
            if (_company == value)
                return;

            _company = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Name));
        }
    }

    public string Type {
        get => _type;
        set {
            if (_type == value)
                return;

            _type = value;
            OnPropertyChanged();
            OnPropertyChanged(nameof(Name));
        }
    }

    public double Amount {
        get => _amount;
        set {
            if (_amount == value)
                return;

            _amount = value;
            OnPropertyChanged();
        }
    }

    public string Note {
        get => _note;
        set {
            if (_note == value)
                return;

            _note = value;
            OnPropertyChanged();
        }
    }

    public string Name => $"{Company} - {Type}";

    public event PropertyChangedEventHandler? PropertyChanged;

    protected void OnPropertyChanged(
        [CallerMemberName] string? propertyName = null) {
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));
    }
}