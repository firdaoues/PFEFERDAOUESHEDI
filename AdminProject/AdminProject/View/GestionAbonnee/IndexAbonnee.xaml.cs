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

namespace AdminProject.View.GestionAbonnee
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class IndexAbonnee : Page
    {
        public IndexAbonnee()
        {
            this.InitializeComponent();
        }

        private void txtcin_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txtcin.Text.All(char.IsNumber);
            if (txtcin.Text.Length!=8 || test == false )
            {
                txtcin.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtcin.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txtcin.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtcin.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
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

        private void txtprenom_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txtprenom.Text.All(char.IsLetter);
            if (txtprenom.Text == "" || test == false)
            {
                txtprenom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtprenom.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txtprenom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtprenom.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void txtemail_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = true;
            int count = txtemail.Text.Split('.').Length - 1;
            if (count == 2)
            {
                int firstpos = txtemail.Text.IndexOf(".");
                int lastpos = txtemail.Text.LastIndexOf(".");
                int atpos = txtemail.Text.IndexOf("@");
                if (firstpos < atpos && atpos < lastpos)
                {
                    test = true;
                }
                else
                {
                    test = false;
                }
            }
            if (txtemail.Text.Contains("@") == false || txtemail.Text.Contains(".") == false || test == false)
            {
                txtemail.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtemail.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txtemail.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtemail.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void txttel_LostFocus(object sender, RoutedEventArgs e)
        {
            bool test = txttel.Text.All(char.IsNumber);
            if (txttel.Text.Length!=8 || test == false)
            {
                txttel.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txttel.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txttel.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txttel.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void txtdatenaissance_LostFocus(object sender, RoutedEventArgs e)
        {
            if (txtdatenaissance.Date.Year>DateTime.Now.Date.Year-18)
            {
                txtdatenaissance.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtdatenaissance.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txtdatenaissance.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtdatenaissance.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void txtcin_GotFocus(object sender, RoutedEventArgs e)
        {
            txtcin.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtnom_GotFocus(object sender, RoutedEventArgs e)
        {
            txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtprenom_GotFocus(object sender, RoutedEventArgs e)
        {
            txtprenom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtemail_GotFocus(object sender, RoutedEventArgs e)
        {
            txtemail.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txttel_GotFocus(object sender, RoutedEventArgs e)
        {
            txttel.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtmotdepasse_LostFocus(object sender, RoutedEventArgs e)
        {
            
            if (txtmotdepasse.Password.Length<8 )
            {
                txtmotdepasse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtmotdepasse.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
            }
            else
            {
                txtmotdepasse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtmotdepasse.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
            }
        }

        private void txtmotdepasse_Holding(object sender, HoldingRoutedEventArgs e)
        {
            txtmotdepasse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtdatenaissance_GotFocus(object sender, RoutedEventArgs e)
        {
            txtdatenaissance.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }
    }
}
