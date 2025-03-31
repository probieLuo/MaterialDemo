using MaterialDesignThemes.Wpf;
using System.Windows;
using System.Windows.Input;

namespace MaterialDemo
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = new Domain.MainViewModel();
        }

        private void UIElement_OnPreviewMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            if (NavDrawer.OpenMode is not DrawerHostOpenMode.Standard)
            {
                MenuToggleButton.IsChecked = false;
            }
        }

        private void OnSelectedItemChanged(object sender, DependencyPropertyChangedEventArgs e)
        {

        }
    }
}