using MaterialDemo.Views;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Windows.Input;

namespace MaterialDemo.Domain
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel()
        {
            _demoItems = new ObservableCollection<DemoItem>();
            DemoItems =
        [
            new DemoItem(
                "Home",
                typeof(Home)
            ),
            .. GenerateDemoItems().OrderBy(i => i.Name),
        ];
            SelectedItem = DemoItems.FirstOrDefault(i => i.Name == "Home");
            SelectedIndex = 0;


            HomeCommand = new RelayCommand(_ =>
            {
                SelectedItem = DemoItems.FirstOrDefault(i => i.Name == "Home");
                SelectedIndex = 0;
            });
        }
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private ObservableCollection<DemoItem> _demoItems;
        public ObservableCollection<DemoItem> DemoItems
        {
            get => _demoItems;
            set
            {
                _demoItems = value;
                OnPropertyChanged(nameof(DemoItems));
            }
        }
        private DemoItem _selectedItem;
        public DemoItem SelectedItem
        {
            get => _selectedItem;
            set
            {
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
            }
        }
        public int _selectedIndex;
        public int SelectedIndex
        {
            get => _selectedIndex;
            set
            {
                _selectedIndex = value;
                OnPropertyChanged(nameof(SelectedIndex));
            }
        }

        public ICommand HomeCommand { get; }

        private static IEnumerable<DemoItem> GenerateDemoItems()
        {
            yield return new DemoItem(
                "Palette",
                typeof(Views.Palette));
            yield return new DemoItem(
               "Sqlite3Connect",
               typeof(Views.Sqlite3Connect));
            yield return new DemoItem(
               "JsonHelp",
               typeof(Views.JsonHelp));
            yield return new DemoItem(
               "SignalRConnect",
               typeof(Views.SignalRConnect));
        }
    }
}
