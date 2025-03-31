using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Configuration;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Documents;
using static MaterialDesignThemes.Wpf.Theme;

namespace MaterialDemo.Domain
{
    public class MainViewModel : INotifyPropertyChanged
    {
        public MainViewModel() 
        {
            _demoItems=new ObservableCollection<DemoItem>();
            DemoItems =
        [
            new DemoItem(
                "Home",
                typeof(Home)
            ),
            .. GenerateDemoItems().OrderBy(i => i.Name),
        ];
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

        private static IEnumerable<DemoItem> GenerateDemoItems()
        {
            yield return new DemoItem(
                "Palette",
                typeof(Palette));

        }
    }
}
