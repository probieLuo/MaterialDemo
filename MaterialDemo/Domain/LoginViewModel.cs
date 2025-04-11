using System.Windows.Input;

namespace MaterialDemo.Domain
{
    public class LoginViewModel : ViewModelBase
    {
        public ICommand LoginCommand { get; }
        public ICommand RegisterCommand { get; }
        private string _password = string.Empty;
        public string Password
        {
            get => _password;
            set => SetProperty(ref _password, value);
        }
        private string _username;
        public string UserName
        {
            get => _username;
            set => SetProperty(ref _username, value);
        }
        public LoginViewModel()
        {
            LoginCommand = new RelayCommand(Login);
            RegisterCommand = new RelayCommand(Register);
        }

        private void Register(object obj)
        {

        }

        private void Login(object obj)
        {
            Password = string.Empty;
            UserName = string.Empty;
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();

        }
    }
}
