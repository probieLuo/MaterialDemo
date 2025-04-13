using MaterialDemo.Models;
using MaterialDemo.Services;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

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

        private string _message = "1111";
        public string Message
        {
            get => _message;
            set => SetProperty(ref _message, value);
        }
        private bool _snackbarOneIsActive = false;
        public bool SnackbarOneIsActive
        {
            get => _snackbarOneIsActive;
            set => SetProperty(ref _snackbarOneIsActive, value);
        }
        /// <summary>
        /// Login success event
        /// </summary>
        public event Action LoginSuccess;
        private readonly DispatcherTimer _timer;

        private string _registerUserName = string.Empty;
        public string RegisterUserName
        {
            get => _registerUserName;
            set => SetProperty(ref _registerUserName, value);
        }
        private string _registerEmail = string.Empty;
        public string RegisterEmail
        {
            get => _registerEmail; set => SetProperty(ref _registerEmail, value);
        }
        private string _registerPassword = string.Empty;
        public string RegisterPassword
        {
            get => _registerPassword;
            set => SetProperty(ref _registerPassword, value);
        }
        private string _registerConfirmPassword = string.Empty;
        public string RegisterConfirmPassword
        {
            get => _registerConfirmPassword;
            set => SetProperty(ref _registerConfirmPassword, value);
        }
        private readonly UserService _userService;
        public LoginViewModel()
        {
            _userService = new UserService();
            LoginCommand = new AsyncCommand(Login);
            RegisterCommand = new AsyncCommand(Register);


            _timer = new DispatcherTimer { Interval = TimeSpan.FromSeconds(3) };
            _timer.Tick += (s, e) =>
            {
                Message = "";
                SnackbarOneIsActive = false;
                _timer.Stop();
            };
        }

        /// <summary>
        /// Register command
        /// </summary>
        /// <param name="obj"></param>
        private async Task Register()
        {
            if (IsValidRegister())
            {
                //写入注册信息
                bool result = await _userService.AddAsync(new User
                {
                    Name = RegisterUserName,
                    Password = BCrypt.Net.BCrypt.HashPassword(RegisterPassword),
                    Email = RegisterEmail
                });
                if (result)
                {
                    ShowMessage("注册成功！");
                }
                else
                {
                    ShowMessage("注册失败！");
                }
            }
        }

        /// <summary>
        /// 验证注册信息
        /// </summary>
        /// <returns></returns>
        private bool IsValidRegister()
        {
            if (string.IsNullOrEmpty(RegisterUserName))
            {
                ShowMessage("用户名不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(RegisterPassword))
            {
                ShowMessage("密码不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(RegisterConfirmPassword))
            {
                ShowMessage("确认密码不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(RegisterEmail))
            {
                ShowMessage("邮箱不能为空！");
                return false;
            }
            if (RegisterConfirmPassword != RegisterPassword)
            {
                ShowMessage("两次输入密码不一致！");
                return false;
            }
            if (RegisterPassword.Length < 6)
            {
                ShowMessage("密码设置至少6位！");
                return false;
            }
            return true;
        }

        private void ShowMessage(string message)
        {
            Message = message;
            SnackbarOneIsActive = true;
            _timer.Start();
        }

        /// <summary>
        /// Login command
        /// </summary>
        /// <param name="obj"></param>
        private async Task Login()
        {
            if (await IsValidLogin())
            {
                // 触发登录成功事件
                LoginSuccess?.Invoke();
            }

        }

        /// <summary>
        /// 验证登录信息
        /// </summary>
        /// <returns></returns>
        private async Task<bool> IsValidLogin()
        {
            if (string.IsNullOrEmpty(UserName))
            {
                ShowMessage("用户名不能为空！");
                return false;
            }
            if (string.IsNullOrEmpty(Password))
            {
                ShowMessage("密码不能为空！");
                return false;
            }
            User user = await _userService.GetByNameAsync(UserName);
            if (user == null)
            {
                ShowMessage("用户名不存在！");
                return false;
            }
            if (BCrypt.Net.BCrypt.Verify(Password, user.Password))
            {
                return true;
            }
            else
            {
                ShowMessage("密码错误！");
                return false;
            }
        }
    }
}
