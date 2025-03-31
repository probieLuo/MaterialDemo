using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MaterialDemo.Domain
{
    public class DemoItem: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        private readonly Type _contentType;
        private readonly object? _dataContext;
        private object? _content;
        public DemoItem(string name,Type contentType, object? dataContext=null)
        {
            Name = name;
            _contentType = contentType;
            _dataContext = dataContext;
        }
        public string Name { get; set; }
        public object? Content => _content ??= CreateContent();
        private object? CreateContent()
        {
            var content = Activator.CreateInstance(_contentType);
            if (_dataContext != null && content is FrameworkElement element)
            {
                element.DataContext = _dataContext;
            }

            return content;
        }
    }
}
