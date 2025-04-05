using MaterialDemo.Domain;
using System.Windows;
using System.Windows.Controls;

namespace MaterialDemo.Views
{
    /// <summary>
    /// Sqlite3Connect.xaml 的交互逻辑
    /// </summary>
    public partial class Sqlite3Connect : UserControl
    {
        ListsAndGridsViewModel viewModel = new ListsAndGridsViewModel();
        public Sqlite3Connect()
        {
            this.DataContext = viewModel;

            InitializeComponent();

            Task.Run(() =>
            {
                viewModel.Initializesync();
                // 使用 Dispatcher 将更新操作切换回主线程
                Dispatcher.Invoke(() =>
                {
                    prog.Visibility = Visibility.Collapsed;
                });
            });

            comboCount.SelectionChanged += (s, e) =>
            {
                prog.Visibility = Visibility.Visible;

                Task.Run(() =>
                {
                    Thread.Sleep(500);
                    viewModel.Initializesync();
                    // 使用 Dispatcher 将更新操作切换回主线程
                    Dispatcher.Invoke(() =>
                    {
                        prog.Visibility = Visibility.Collapsed;
                    });
                });
            };
        }

    }
}
