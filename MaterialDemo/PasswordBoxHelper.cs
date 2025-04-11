using System.Windows;
using System.Windows.Controls;

namespace MaterialDemo
{
    public static class PasswordBoxHelper
    {
        public static string GetPassword(DependencyObject obj)
        {
            return (string)obj.GetValue(PasswordProperty);
        }

        public static void SetPassword(DependencyObject obj, string value)
        {
            obj.SetValue(PasswordProperty, value);
        }

        public static readonly DependencyProperty PasswordProperty =
            DependencyProperty.RegisterAttached("Password", typeof(string), typeof(PasswordBoxHelper),
                new FrameworkPropertyMetadata(string.Empty, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault,
                    OnPasswordChanged));

        private static void OnPasswordChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                passwordBox.Password = e.NewValue.ToString();
            }
        }

        public static bool GetIsPasswordBindingEnable(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsPasswordBindingEnableProperty);
        }

        public static void SetIsPasswordBindingEnable(DependencyObject obj, bool value)
        {
            obj.SetValue(IsPasswordBindingEnableProperty, value);
        }

        public static readonly DependencyProperty IsPasswordBindingEnableProperty =
            DependencyProperty.RegisterAttached("IsPasswordBindingEnable", typeof(bool), typeof(PasswordBoxHelper),
                new PropertyMetadata(false, OnIsPasswordBindingEnableChanged));

        private static void OnIsPasswordBindingEnableChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if (d is PasswordBox passwordBox)
            {
                if ((bool)e.NewValue)
                {
                    passwordBox.PasswordChanged += PasswordBox_PasswordChanged;
                }
                else
                {
                    passwordBox.PasswordChanged -= PasswordBox_PasswordChanged;
                }
            }
        }

        private static void PasswordBox_PasswordChanged(object sender, RoutedEventArgs e)
        {
            if (sender is PasswordBox passwordBox)
            {
                SetPassword(passwordBox, passwordBox.Password);
            }
        }
    }
}
