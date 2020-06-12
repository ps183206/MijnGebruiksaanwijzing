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
    /// Interaction logic for RedCards.xaml
    /// </summary>
    public partial class RedCards : Window
    {
        List<string> redCards = new List<string>();

        List<string> selectedRedCards = new List<string>();

        int cardCount = 0;

        public RedCards()
        {
            InitializeComponent();
            //wanneer er op de groene knop geklikt wordt moeten de kaartjes toegevoegd aan een list die wordt meegenomen dalijk
            //nadat het kaartje toegevoegd is aan de list die meegenomen wordt dan wordt deze verwijderd uit de andere list
            //wanneer er op de rode knop wordt gedrukt dan wordt het kaartje verwijderd van de beginlist
            //wanneer het hele lijstje leeg is dan komt de button doorgaan te voor schijn en kan deze geklikt worden om verder te gaan
        }

        private void RedCards_IsLoaded(object sender, RoutedEventArgs e)
        {
            tbRed.Text = redCards[cardCount].ToString();
        }

        private void btnVolgende_Click(object sender, RoutedEventArgs e)
        {
            YellowCards yellowCards = new YellowCards();
            yellowCards.Top = 0;
            yellowCards.Left = 0;
            yellowCards.Show();
            this.Close();

        }

        private void btnPastBijMij_Click(object sender, RoutedEventArgs e)
        {
            tbPastWel.Text = tbRed.Text;
            selectedRedCards.Add(tbPastWel.Text);

            try
            {
                cardCount++;
                tbRed.Text = redCards[cardCount];
            }
            catch (Exception)
            {
                tbRed.Text = "";
                btnPastBijMij.IsEnabled = false;
                btnPastNietBijMij.IsEnabled = false;
                btnVolgende.IsEnabled = true;
            }
        }

        private void btnPastNietBijMij_Click(object sender, RoutedEventArgs e)
        {
            tbPastNiet.Text = tbRed.Text;

            try
            {
                
            }
            catch (Exception)
            {
                tbRed.Text = "";
                btnPastBijMij.IsEnabled = false;
                btnPastNietBijMij.IsEnabled = false;
                btnVolgende.IsEnabled = true;
            }
        }


    }
}
