using MijnGebruiksaanwijzing.Classes;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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
        List<string> NewRedCards = new List<string>();
        List<string> NewYellowCards = new List<string>();

        List<string> blueCards = new List<string>();
        List<string> selectedBlueCards = new List<string>();

        int cardCount = 0;
        
        public BlueCards(string gameType, List<string> redCards, List<string> yellowCards)
        {
            InitializeComponent();

            MySqlConnection conn =
            new MySqlConnection("Server=localhost;Database=mijngebruiksaanwijzing;Uid=root;Pwd=");

            conn.Open();
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT CardDesc FROM `cards` WHERE CardColor = 'Blue' AND CardType = @type";
            command.Parameters.AddWithValue("@type", gameType);
            MySqlDataReader reader = command.ExecuteReader();
            DataTable dtData = new DataTable();
            dtData.Load(reader);
            conn.Close();
            foreach (DataRow row in dtData.Rows)
            {
                foreach (DataColumn col in dtData.Columns)
                {
                    blueCards.Add(row[col].ToString());
                }
            }
        }

        private void btnVolgende_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                //Volgende rode kaart weergeven uit redCards


            }
            catch (Exception)
            {
                HomeLeerling homeleerling = new HomeLeerling();
                homeleerling.Top = 0;
                homeleerling.Left = 0;
                homeleerling.Show();
                this.Close();
            }
            
        }

        private void btnPastBijMij_Click(object sender, RoutedEventArgs e)
        {
            tbPastWel.Text = tbBlue.Text;
            selectedBlueCards.Add(tbPastWel.Text);

            try
            {
                cardCount++;
                tbBlue.Text = blueCards[cardCount];
                lblCurrentCard.Content = cardCount + 1 + "/50";
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
            tbPastNiet.Text = tbBlue.Text;

            try
            {
                cardCount++;
                tbBlue.Text = blueCards[cardCount];
                lblCurrentCard.Content = cardCount + 1 + "/50";
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
