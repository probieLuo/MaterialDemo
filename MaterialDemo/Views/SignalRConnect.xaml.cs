using MaterialDemo.Domain;
using System.Windows.Controls;

namespace MaterialDemo.Views
{
    /// <summary>
    /// SignalRConnect.xaml 的交互逻辑
    /// </summary>
    public partial class SignalRConnect : UserControl
    {
        public SignalRConnect()
        {
            this.DataContext = new SignalRConnectViewModel();
            InitializeComponent();
        }
    }
}
