using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;


namespace YourApp.Helpers
{
    public static class PasswordHelper
    {
        public static void TogglePasswordVisibility(
            PasswordBox passwordBox,
            TextBox textBox,
            Image image,
            ImageSource eyeOpen,
            ImageSource eyeClosed)
        {
            if (passwordBox.Visibility == Visibility.Visible)
            {
                textBox.Text = passwordBox.Password;
                passwordBox.Visibility = Visibility.Collapsed;
                textBox.Visibility = Visibility.Visible;
                image.Source = eyeOpen;
            }
            else
            {
                passwordBox.Password = textBox.Text;
                textBox.Visibility = Visibility.Collapsed;
                passwordBox.Visibility = Visibility.Visible;
                image.Source = eyeClosed;
            }
        }
    }
}
