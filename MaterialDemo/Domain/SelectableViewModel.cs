﻿namespace MaterialDemo.Domain
{
    public class SelectableViewModel : Domain.ViewModelBase
    {
        private bool _isSelected;
        private string? _name;
        private string? _description;
        private char _code;
        private double _numeric;
        private string? _food;
        private string? _files;
        private VehicleType _vehicleType;

        public bool IsSelected
        {
            get => _isSelected;
            set => SetProperty(ref _isSelected, value);
        }

        public char Code
        {
            get => _code;
            set => SetProperty(ref _code, value);
        }

        public string? Name
        {
            get => _name;
            set => SetProperty(ref _name, value);
        }

        public string? Description
        {
            get => _description;
            set => SetProperty(ref _description, value);
        }

        public double Numeric
        {
            get => _numeric;
            set => SetProperty(ref _numeric, value);
        }

        public string? Food
        {
            get => _food;
            set => SetProperty(ref _food, value);
        }

        public string? Files
        {
            get => _files;
            set => SetProperty(ref _files, value);
        }

        public VehicleType VehicleType
        {
            get => _vehicleType;
            set => SetProperty(ref _vehicleType, value);
        }

    }

    public enum VehicleType
    {
        Car,
        Bus,
        Motorcycle,
        Van,
        Scooter,
        Truck
    }
}
