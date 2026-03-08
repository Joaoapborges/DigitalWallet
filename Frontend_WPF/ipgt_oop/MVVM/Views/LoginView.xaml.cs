using ipgt_oop.MVVM.ViewModels;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ipgt_oop.MVVM.Views
{
    public partial class LoginView : UserControl
    {
        private const double AnimationDurationSeconds = 0.35;
        private const double SegmentWidth = 201;

        public LoginView()
        {
            InitializeComponent();
            DataContext = new LoginViewModel();
        }

        private void SegmentButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button clickedButton)
            {
                // Determine the target index from the button's Tag property
                if (int.TryParse(clickedButton.Tag?.ToString(), out int targetIndex))
                {
                    // Calculate the required horizontal offset
                    double targetOffset = targetIndex * SegmentWidth;

                    // Check if the pill is already in the target position
                    if (SelectionTranslate.X == targetOffset)
                    {
                        return;
                    }

                    // Setup the animation
                    DoubleAnimation animation = new DoubleAnimation
                    {
                        To = targetOffset,
                        Duration = TimeSpan.FromSeconds(AnimationDurationSeconds),
                        EasingFunction = new CubicEase { EasingMode = EasingMode.EaseOut } // Improve the animation fluidity
                    };

                    // Start the animation on the TranslateTransform's X property
                    SelectionTranslate.BeginAnimation(TranslateTransform.XProperty, animation);

                    // Update the text colors to reflect the new selection
                    UpdateTextColors(clickedButton);
                }
            }
        }

        private void UpdateTextColors(Button selectedButton)
        {
            // Reset all buttons to the default gray color
            ManualEntryButton.Foreground = (Brush)FindResource("ButtonUnselected");
            QuickSelectButton.Foreground = (Brush)FindResource("ButtonUnselected");

            // Set the selected button's text to white
            selectedButton.Foreground = (Brush)FindResource("ButtonSelected");
        }
    }
}
