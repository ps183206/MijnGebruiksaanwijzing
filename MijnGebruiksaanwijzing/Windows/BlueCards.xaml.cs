using MijnGebruiksaanwijzing.Classes;
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

namespace MijnGebruiksaanwijzing.Windows
{
    /// <summary>
    /// Interaction logic for BlueCards.xaml
    /// </summary>
    public partial class BlueCards : Window
    {
        List<string> blueCards = new List<string>();
        List<string> redCards = new List<string>();
        List<string> yellowCards = new List<string>();

        List<string> selectedBlueCards = new List<string>();
        
        public BlueCards()
        {
            InitializeComponent();
        }

        private void btnVolgende_Click(object sender, RoutedEventArgs e)
        {
            HomeLeerling homeleerling = new HomeLeerling();
            homeleerling.Top = 0;
            homeleerling.Left = 0;
            homeleerling.Show();
            this.Close();
        }

        private void btnPastBijMij_Click(object sender, RoutedEventArgs e)
        {
            tbPastWel.Text = tbYellow.Text;
            selectedBlueCards.Add(tbPastWel.Text);

            try
            {

            }
            catch (Exception)
            {
                tbBlue.Text = "";
                btnPastBijMij.IsEnabled = false;
                btnPastNietBijMij.IsEnabled = false;
                btnVolgende.IsEnabled = true;
            }
        }

        private void btnPastNietBijMij_Click(object sender, RoutedEventArgs e)
        {
            tbPastNiet.Text = tbYellow.Text;

            try
            {

            }
            catch (Exception)
            {
                tbBlue.Text = "";
                btnPastBijMij.IsEnabled = false;
                btnPastNietBijMij.IsEnabled = false;
                btnVolgende.IsEnabled = true;
            }
        }

        private void prevYellowCard_Click(object sender, RoutedEventArgs e)
        {

        }

        private void nextYellowCard_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
