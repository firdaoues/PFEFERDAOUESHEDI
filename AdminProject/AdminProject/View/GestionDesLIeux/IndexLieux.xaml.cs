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

namespace AdminProject.View.GestionDesLIeux
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Indexabonnee : Page
    {
        Lieu monlieu = new Lieu();
        private MobileServiceCollection<Lieu, Lieu> lieux;
        private IMobileServiceTable<Lieu> lieutable = App.MobileService.GetTable<Lieu>();
        bool testnom = false, testadr = false, testlong = false, testlat = false;
        public Indexabonnee()
        {
            this.InitializeComponent();
            btnmodifier.Visibility = Visibility.Collapsed;
            btnsupprimer.Visibility = Visibility.Collapsed;
            affichelist();

        }

        private async void affichelist()
        {
            try
            {
                lieux = await lieutable.ToCollectionAsync();
                affichelieux.ItemsSource = lieux;
            }
            catch (Exception)
            {
                MessageDialog msg = new MessageDialog("erreur");
                msg.ShowAsync();
            }
            if (lieux.Count()==0)
            {
                MessageDialog mm = new MessageDialog("pas des lieux");
                mm.ShowAsync();
            }
        }

        private void txtnom_LostFocus(object sender, RoutedEventArgs e)
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

        private void txtnom_GotFocus(object sender, RoutedEventArgs e)
        {
            txtnom.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Black);
        }

        private void txtadresse_LostFocus(object sender, RoutedEventArgs e)
        {
            Regex regex = new Regex(@"^[a-zA-Z ]+$");
            bool test = regex.IsMatch(txtadresse.Text);
            if (txtadresse.Text == "" || test == false)
            {
                txtadresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtadresse.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testadr = false;
            }
            else
            {
                txtadresse.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtadresse.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testadr = true;
            }
        }

        private void txtlangitude_LostFocus(object sender, RoutedEventArgs e)
        {
            Double x = 0;
            bool test = Double.TryParse(txtlangitude.Text, out x);
            if (txtlangitude.Text == "" || test == false)
            {
                txtlangitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtlangitude.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testlong = false;
            }
            else
            {
                txtlangitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtlangitude.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testlong = true;
            }
        }

        private void txtlatitude_LostFocus(object sender, RoutedEventArgs e)
        {
            Double x = 0;
            bool test = Double.TryParse(txtlatitude.Text, out x);
            if (txtlatitude.Text == "" || test == false)
            {
                txtlatitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Red);
                txtlatitude.Foreground = new SolidColorBrush(Windows.UI.Colors.Red);
                testlat = false;
            }
            else
            {
                txtlatitude.BorderBrush = new SolidColorBrush(Windows.UI.Colors.Green);
                txtlatitude.Foreground = new SolidColorBrush(Windows.UI.Colors.Green);
                testlat = true;
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

        private void affichelieux_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            monlieu = affichelieux.SelectedItem as Lieu;
            txtnom.Text = monlieu.nom;
            txtadresse.Text = monlieu.adresse;
            txtlangitude.Text = monlieu.langitude.ToString();
            txtlatitude.Text = monlieu.latitude.ToString();
            btnmodifier.Visibility = Visibility.Visible;
            btnsupprimer.Visibility = Visibility.Visible;
            btnajout.Visibility = Visibility.Collapsed;
        }

        private async void btnajout_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (testnom && testadr && testlong && testlat)
                {
                    Lieu lieu = new Lieu { nom = txtnom.Text, adresse = txtadresse.Text, langitude = Double.Parse(txtlangitude.Text), latitude = Double.Parse(txtlatitude.Text) };
                    await lieutable.InsertAsync(lieu);
                    MessageDialog msg = new MessageDialog("ajout avec succes");
                    msg.ShowAsync();
                    Frame.Navigate(typeof(Indexabonnee));
                }
                else
                {
                    MessageDialog msg = new MessageDialog("verifier les champs a remplir");
                    msg.ShowAsync();
                }

            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog(ex.Message);
                msg.ShowAsync();
            }
        }

        private async void btnmodifier_Click(object sender, RoutedEventArgs e)
        {
            
            try
            {
                if (testnom && testadr && testlong && testlat)
                {
                    Lieu lieu = new Lieu { Id = monlieu.Id, nom = txtnom.Text, adresse = txtadresse.Text, langitude = Double.Parse(txtlangitude.Text), latitude = Double.Parse(txtlatitude.Text) };
                    await lieutable.UpdateAsync(lieu);
                    MessageDialog msg = new MessageDialog("modification  avec succes");
                    msg.ShowAsync();
                    Frame.Navigate(typeof(Indexabonnee));
                }
                else
                {

                    MessageDialog msg = new MessageDialog("verifier les champs");
                    msg.ShowAsync();
                }
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog(ex.Message);
                msg.ShowAsync();
            }
        }

        private async void btnsupprimer_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                await lieutable.DeleteAsync(monlieu);
                MessageDialog msg = new MessageDialog("suppression avec succes");
                msg.ShowAsync();
                Frame.Navigate(typeof(Indexabonnee));
            }
            catch (Exception ex)
            {
                MessageDialog msg = new MessageDialog(ex.Message);
                msg.ShowAsync();
            }
        }
    }
}