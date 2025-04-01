using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaterialDemo.Domain
{
    public class ListsAndGridsViewModel
    {
        public ListsAndGridsViewModel()
        {
            Items1 = CreateData();
        }
        public ObservableCollection<SelectableViewModel> Items1 { get; }
        private static ObservableCollection<SelectableViewModel> CreateData()
        {
            return new ObservableCollection<SelectableViewModel>
        {
            new SelectableViewModel
            {
                Code = 'M',
                Name = "Material Design",
                Description = "Material Design in XAML Toolkit"
            },
            new SelectableViewModel
            {
                Code = 'D',
                Name = "Dragablz",
                Description = "Dragablz Tab Control",
                Food = "Fries"
            },
            new SelectableViewModel
            {
                Code = 'P',
                Name = "Predator",
                Description = "If it bleeds, we can kill it"
            }
        };
        }
    }
}
