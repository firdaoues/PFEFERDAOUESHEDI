using AdminProject.Model;
using Microsoft.WindowsAzure.MobileServices;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text.RegularExpressions;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Popups;
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
        Abonnee monabonnee = new Abonnee();
        private MobileServiceCollection<Abonnee, Abonnee> abonnees;
        private IMobileServiceTable<Abonnee> abonnetable = App.MobileService.GetTable<Abonnee>();
        bool testnom = false, testprenom = false, testcin = false, testpw = false, testeamil = false,testtel=false,testdn=false;
        public IndexAbonnee()
        {
            this.InitializeComponent();
            btnmodifier.Visibility = Visibility.Collapsed;
            btnsupprimer.Visibility = Visibility.Collapsed;
            affiche();
        }

        private void testgen()
        {
            testernom();
            testerprenom();
            testercin();
            testeremail();
            testerdn();
            testermotdemapsse();
            testertel();
        }

        private async void affiche()
        {
            try
            {
                abonnees = await abonnetable.ToCollectionAsync();
            }
            catch (Exception)
            {
                MessageDialog msg = new MessageDialog("erreur");
                msg.ShowAsync();
            }
            if (abonnees.Count()==0)
            {
                MessageDialog mm = new MessageDialog("pas des abonnées ");
                mm.ShowAsync();
            }
            else
            {
                afficheabonnee.ItemsSource = abonnees;
            }

        }

        private void testercin()
        {
            bool test = txtcin.Text.All(char.IsNumber);
            if (txtcin.Text.Length != 8 || test == false)
            {
                txtcin.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtcin.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testcin = false;
            }
            else
            {
                txtcin.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtcin.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testcin = true;
            }
        }

        private void testernom()
        {
            Regex regex = new Regex(@"^[a-zA-Z ]+$");
            bool test = regex.IsMatch(txtnom.Text);
            if (txtnom.Text == "" || test == false)
            {
                txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtnom.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testnom = false;
            }
            else
            {
                txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtnom.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testnom = true;
            }
        }

        private void testerprenom()
        {
            Regex regex = new Regex(@"^[a-zA-Z ]+$");
            bool test = regex.IsMatch(txtprenom.Text);
            if (txtprenom.Text == "" || test == false)
            {
                txtprenom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtprenom.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testprenom = false;
            }
            else
            {
                txtprenom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtprenom.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testprenom = true;
            }
        }

        private void testeremail()
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
                testeamil = false;
            }
            else
            {
                txtemail.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtemail.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testeamil = true;
            }
        }

        private void testertel()
        {
            bool test = txttel.Text.All(char.IsNumber);
            if (txttel.Text.Length != 8 || test == false)
            {
                txttel.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txttel.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testtel = false;
            }
            else
            {
                txttel.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txttel.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testtel = true;
            }
        }

        private void testerdn()
        {
            if (txtdatenaissance.Date.Year > DateTime.Now.Date.Year - 18)
            {
                txtdatenaissance.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtdatenaissance.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testdn = false;
            }
            else
            {
                txtdatenaissance.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtdatenaissance.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testdn = true;
            }
        }

        private void testermotdemapsse()
        {
            if (txtmotdepasse.Password.Length < 8)
            {
                txtmotdepasse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtmotdepasse.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testpw = false;
            }
            else
            {
                txtmotdepasse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtmotdepasse.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testpw = true;
            }
        }

        private void txtcin_LostFocus(object sender, RoutedEventArgs e)
        {
            testercin();
        }

        private void txtnom_LostFocus(object sender, RoutedEventArgs e)
        {
            testernom();
        }

        private void txtprenom_LostFocus(object sender, RoutedEventArgs e)
        {
            testerprenom();
        }

        private void txtemail_LostFocus(object sender, RoutedEventArgs e)
        {
            testeremail();
        }

        private void txttel_LostFocus(object sender, RoutedEventArgs e)
        {
            testertel();
        }

        private void txtdatenaissance_LostFocus(object sender, RoutedEventArgs e)
        {
            testerdn();
        }

        private void txtcin_GotFocus(object sender, RoutedEventArgs e)
        {
            txtcin.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtnom_GotFocus(object sender, RoutedEventArgs e)
        {
            txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private async void btnajout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (testnom && testprenom && testpw && testdn && testeamil && testcin && testtel)
                {
                    Abonnee abonnee = new Abonnee {cin=int.Parse(txtcin.Text), datedenaissance=txtdatenaissance.Date.DateTime, email=txtemail.Text, nom=txtnom.Text, prenom=txtprenom.Text, motdepasse=txtmotdepasse.Password, tel=int.Parse(txttel.Text) };
                    await abonnetable.InsertAsync(abonnee);
                    MessageDialog msg = new MessageDialog("ajouté avec succes");
                    msg.ShowAsync();
                    Frame.Navigate(typeof(IndexAbonnee));
                }
            }
            catch (Exception)
            {
                MessageDialog mm = new MessageDialog("errer");
                mm.ShowAsync();
            }
        }

        private async void btnmodifier_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (testnom && testprenom && testpw && testdn && testeamil && testcin && testtel)
                {
                    Abonnee abonnee = new Abonnee {Id=monabonnee.Id, cin = int.Parse(txtcin.Text), datedenaissance = txtdatenaissance.Date.DateTime, email = txtemail.Text, nom = txtnom.Text, prenom = txtprenom.Text, motdepasse = txtmotdepasse.Password, tel = int.Parse(txttel.Text) };
                    await abonnetable.UpdateAsync(abonnee);
                    MessageDialog msg = new MessageDialog("modifié avec succes");
                    msg.ShowAsync();
                    Frame.Navigate(typeof(IndexAbonnee));
                }
            }
            catch (Exception)
            {
                MessageDialog mm = new MessageDialog("errer");
                mm.ShowAsync();
            }
        }

        private async void btnsupprimer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await abonnetable.DeleteAsync(monabonnee);
                MessageDialog msg = new MessageDialog("supression avec succes");
                msg.ShowAsync();
                Frame.Navigate(typeof(IndexAbonnee));

            }
            catch (Exception)
            {
                MessageDialog mm = new MessageDialog("errer");
                mm.ShowAsync();
            }
        }

        private void afficheabonnee_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            monabonnee = afficheabonnee.SelectedItem as Abonnee;
            txtcin.Text = monabonnee.cin.ToString();
            txtnom.Text = monabonnee.nom;
            txtprenom.Text = monabonnee.prenom;
            txttel.Text = monabonnee.tel.ToString();
            txtdatenaissance.Date = monabonnee.datedenaissance.Date;
            txtemail.Text = monabonnee.email;
            txtmotdepasse.Password = monabonnee.motdepasse;
            btnmodifier.Visibility = Visibility.Visible;
            btnsupprimer.Visibility = Visibility.Visible;
            testgen();
        }

        private void txtmotdepasse_GotFocus(object sender, RoutedEventArgs e)
        {
            txtmotdepasse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
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
            testermotdemapsse();
        }

        private void txtdatenaissance_GotFocus(object sender, RoutedEventArgs e)
        {
            txtdatenaissance.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }
    }
}
