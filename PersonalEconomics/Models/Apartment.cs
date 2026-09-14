using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;

public class Apartment : INotifyPropertyChanged {
    private string _landlord = string.Empty;
    private string _address = string.Empty;
    private Utility _utilities = new();
    private List<Insurance> _insurances = new();
    private double _rent;
    private double _furniture;
    private double _repairs;
    private double _mortgage;
    private double _total;
    private string _note = string.Empty;

    public string Landlord {
        get => _landlord;
        set => SetField(ref _landlord, value);
    }

    public string Address {
        get => _address;
        set => SetField(ref _address, value);
    }

    public Utility Utilities {
        get => _utilities;
        set => SetField(ref _utilities, value);
    }

    public List<Insurance> Insurances {
        get => _insurances;
        set => SetField(ref _insurances, value);
    }

    public double Rent {
        get => _rent;
        set => SetField(ref _rent, value);
    }

    public double Furniture {
        get => _furniture;
        set => SetField(ref _furniture, value);
    }

    public double Repairs {
        get => _repairs;
        set => SetField(ref _repairs, value);
    }

    public double Mortgage {
        get => _mortgage;
        set => SetField(ref _mortgage, value);
    }

    public double Total {
        get => _total;
        set => SetField(ref _total, value);
    }

    public string Note {
        get => _note;
        set => SetField(ref _note, value);
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null) {
        if (EqualityComparer<T>.Default.Equals(field, value))
            return false;

        field = value;
        PropertyChanged?.Invoke(
            this,
            new PropertyChangedEventArgs(propertyName));

        return true;
    }


    public class Utility : INotifyPropertyChanged {
        private double _electricityBill;
        private double _heatingBill;
        private double _waterBill;
        private double _laundromatSubscription;
        private double _internetBill;
        private double _total;
        private string _note = string.Empty;

        public double ElectricityBill {
            get => _electricityBill;
            set => SetField(ref _electricityBill, value);
        }

        public double HeatingBill {
            get => _heatingBill;
            set => SetField(ref _heatingBill, value);
        }

        public double WaterBill {
            get => _waterBill;
            set => SetField(ref _waterBill, value);
        }

        public double LaundromatSubscription {
            get => _laundromatSubscription;
            set => SetField(ref _laundromatSubscription, value);
        }

        public double InternetBill {
            get => _internetBill;
            set => SetField(ref _internetBill, value);
        }

        public double Total {
            get => _total;
            set => SetField(ref _total, value);
        }

        public string Note {
            get => _note;
            set => SetField(ref _note, value);
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null) {
            if (EqualityComparer<T>.Default.Equals(field, value))
                return false;

            field = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

            return true;
        }
    }
}