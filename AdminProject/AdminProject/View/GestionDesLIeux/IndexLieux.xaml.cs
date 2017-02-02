using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace AdminProject.View.GestionDesLIeux
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IndexLieux : Page
    {
        public IndexLieux()
        {
            this.InitializeComponent();
        }



        private void txtnom_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txtnom.Text.All(char.IsLetter);
            if (txtnom.Text == "" || test == false)
            {
                txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtnom.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtnom.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void txtnom_GotFocus(object sender, RoutedEventArgs e)
        {
            txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtadresse_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txtadresse.Text.All(char.IsLetterOrDigit);
            if (txtadresse.Text == "" || test == false)
            {
                txtadresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtadresse.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txtadresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtadresse.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void txtlangitude_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txtlangitude.Text.All(char.IsNumber);
            if (txtlangitude.Text == "" || test == false)
            {
                txtlangitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);

                txtlangitude.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txtlangitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtlangitude.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void txtlatitude_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txtlatitude.Text.All(char.IsNumber);
            if (txtlatitude.Text == "" || test == false)
            {
                txtlatitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtlatitude.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txtlatitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtlatitude.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void txtadresse_GotFocus(object sender, RoutedEventArgs e)
        {
            txtadresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtlangitude_GotFocus(object sender, RoutedEventArgs e)
        {
            txtlangitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtlatitude_GotFocus(object sender, RoutedEventArgs e)
        {
            txtlatitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }
    }
}