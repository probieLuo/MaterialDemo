using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace MaterialDemo
{
    /// <summary>
    /// LoginWindow.xaml 的交互逻辑
    /// </summary>
    public partial class LoginWindow : Window
    {
        public LoginWindow()
        {
            InitializeComponent();
            //this.DataContext = new Domain.LoginViewModel();
        }

        private void Login_Click(object sender, RoutedEventArgs e)
        {
            if (Login())
            {
                MainWindow mainWindow = new MainWindow();
                mainWindow.Show();
                this.Close();
            }
        }
        private void Register_Click(object sender, RoutedEventArgs e)
        {
            // 注册逻辑
        }
        private bool Login()
        {
            // 登录逻辑
            // 这里可以添加用户名和密码的验证逻辑
            // 如果验证成功，返回true，否则返回false
            return true;
        }

    }
}
