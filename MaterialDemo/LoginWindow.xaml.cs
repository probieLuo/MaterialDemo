using MaterialDemo.Domain;
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
        private Domain.LoginViewModel _loginViewModel;
        public LoginWindow()
        {
            try
            {
                _loginViewModel = new LoginViewModel();
                InitializeComponent();
                this.DataContext = _loginViewModel;
                // 绑定登录成功事件
                ((Domain.LoginViewModel)this.DataContext).LoginSuccess += OnLoginSuccess;
            }
            catch (Exception e)
            {

            }
        }

        private void OnLoginSuccess()
        {
            // 登录成功，关闭登录窗口并打开主窗口
            Application.Current.MainWindow = new MainWindow();
            Application.Current.MainWindow.Show();
            this.Close(); // 关闭登录窗口
        }
    }
}
