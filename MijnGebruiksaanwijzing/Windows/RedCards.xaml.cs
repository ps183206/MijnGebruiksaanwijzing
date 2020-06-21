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
    /// Interaction logic for RedCards.xaml
    /// </summary>
    public partial class RedCards : Window
    {
        List<string> redCards = new List<string>();
        List<string> selectedRedCards = new List<string>();

        public string game { get; set; }
        public static int Count { get; private set; }

        int cardCount = 0;
        int Length { get; set; }

        public RedCards(string gameType)
        {
            InitializeComponent();
            
            game = gameType;

            MySqlConnection conn =
            new MySqlConnection("Server=localhost;Database=mijngebruiksaanwijzing;Uid=root;Pwd=");

            conn.Open();
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT CardDesc FROM `cards` WHERE CardColor = 'Red' AND CardType = @type";
            command.Parameters.AddWithValue("@type", gameType);
            MySqlDataReader reader = command.ExecuteReader();
            DataTable dtData = new DataTable();
            dtData.Load(reader);
            conn.Close();
            foreach (DataRow row in dtData.Rows)
            {
                foreach (DataColumn col in dtData.Columns)
                {
                    redCards.Add(row[col].ToString());
                }
            }
            Length = redCards.Count;
            lblCurrentCard.Content = cardCount + 1 +"/" + Length;
        }

        private void RedCards_IsLoaded(object sender, RoutedEventArgs e)
        {
            tbRed.Text = redCards[cardCount].ToString();
        }

        private void btnVolgende_Click(object sender, RoutedEventArgs e)
        {
            
            YellowCards yellowCards = new YellowCards(selectedRedCards, game);
            yellowCards.Top = 0;
            yellowCards.Left = 0;
            yellowCards.Show();
            this.Close();
        }

        private void btnPastBijMij_MouseDown(object sender, RoutedEventArgs e)
        {
            tbPastWel.Text = tbRed.Text;
            selectedRedCards.Add(tbPastWel.Text);
            Length = redCards.Count;

            try
            {
                cardCount++;
                tbRed.Text = redCards[cardCount];
                lblCurrentCard.Content = cardCount + 1 + "/" + Length;
            }
            catch (Exception)
            {
                gridRed.Visibility = Visibility.Hidden;
                btnVolgende.Visibility = Visibility.Visible;
                btnPastBijMij.IsEnabled = false;
                btnPastNietBijMij.IsEnabled = false;
                btnPastBijMij.Opacity = 0.5;
                btnPastNietBijMij.Opacity = 0.5;
            }
        }

        private void btnPastNietBijMij_MouseDown(object sender, RoutedEventArgs e)
        {
            tbPastNiet.Text = tbRed.Text;
            Length = redCards.Count;

            try
            {
                cardCount++;
                tbRed.Text = redCards[cardCount];
                lblCurrentCard.Content = cardCount + 1 + "/" + Length;
            }
            catch (Exception)
            {
                gridRed.Visibility = Visibility.Hidden;
                btnVolgende.Visibility = Visibility.Visible;
                btnPastBijMij.IsEnabled = false;
                btnPastNietBijMij.IsEnabled = false;
                btnPastBijMij.Opacity = 0.5;
                btnPastNietBijMij.Opacity = 0.5;
            }
        }


    }
}
