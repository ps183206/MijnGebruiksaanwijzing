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
    /// Interaction logic for YellowCards.xaml
    /// </summary>
    public partial class YellowCards : Window
    {
        //List die je van de vorige pagina mee kunt nemen komt in het midden te staan/ die wordt geladen
        List<string> NewRedCards = new List<string>();

        MySqlConnection conn =
        new MySqlConnection("Server=localhost;Database=mijngebruiksaanwijzing;Uid=root;Pwd=");

        List<string> yellowCards = new List<string>();
        List<string> selectedYellowCards = new List<string>();
        List<string> FinalYellowCards = new List<string>();

        int cardCount = 0;
        int redCardCount = 0;
        int c = 0;

        string FullYellowCardString = "";

        int Length { get; set; }

        int RedCardsLength { get; set; }

        int n { get; set; }

        public string game { get; set; }

        public YellowCards(List<string> redCards, string gameType)
        {
            InitializeComponent();

            game = gameType;

            //tbYellow.Text = redCards;

            NewRedCards = redCards;

            RedCardsLength = NewRedCards.Count();

            conn.Open();
            MySqlCommand command = conn.CreateCommand();

            //ophalen uit de database
            command.CommandText = "SELECT CardDesc FROM `cards` WHERE CardColor = 'Yellow' AND CardType = @type";
            command.Parameters.AddWithValue("@type", gameType);
            MySqlDataReader reader = command.ExecuteReader();
            DataTable dtData = new DataTable();
            dtData.Load(reader);
            conn.Close();
            //er moet door heen gecycled kunnen worden door de kaartjes onder
            foreach (DataRow row in dtData.Rows)
            {
                foreach (DataColumn col in dtData.Columns)
                {
                    yellowCards.Add(row[col].ToString());
                }
            }
            Length = yellowCards.Count;
            lblCurrentCard.Content = cardCount + 1 + "/" + Length;
        }
        private void YellowCards_IsLoaded(object sender, RoutedEventArgs e)
        {
            tbYellow.Text = yellowCards[cardCount].ToString();
            tbRed.Text = NewRedCards[cardCount].ToString();
        }

        private void btnVolgende_Click(object sender, RoutedEventArgs e)
        {
            
            RedCardsLength--;
            if (RedCardsLength == 0)
            {
                //Naar volgende pagina
                foreach (string element in selectedYellowCards)
                {
                    c++;
                    FullYellowCardString = element.ToString() + "_" + FullYellowCardString;
                }
                FinalYellowCards.Add(FullYellowCardString);
                FullYellowCardString = "";
                //wanneer alle rode kaartjes minimaal 1 geel kaartje hebben gekregen BtnDoorgaan visible maken en volgende scherm zichtbaar maken
                BlueCards blueCards = new BlueCards(game, NewRedCards, FinalYellowCards);
                blueCards.Top = 0;
                blueCards.Left = 0;
                blueCards.Show();
                this.Close();
            }
            else
            {

                redCardCount++;
                foreach (string element in selectedYellowCards)
                {
                    c++;
                    FullYellowCardString = element.ToString() + "_" + FullYellowCardString;
                }
                FinalYellowCards.Add(FullYellowCardString);
                FullYellowCardString = "";
                
                tbRed.Text = NewRedCards[redCardCount].ToString();
                
                cardCount = 0;
                yellowCards.Clear();
                conn.Open();
                MySqlCommand command = conn.CreateCommand();

                //ophalen uit de database
                command.CommandText = "SELECT CardDesc FROM `cards` WHERE CardColor = 'Yellow' AND CardType = @type";
                command.Parameters.AddWithValue("@type", game);
                MySqlDataReader reader = command.ExecuteReader();
                DataTable dtData = new DataTable();
                dtData.Load(reader);
                conn.Close();
                //er moet door heen gecycled kunnen worden door de kaartjes onder
                foreach (DataRow row in dtData.Rows)
                {
                    foreach (DataColumn col in dtData.Columns)
                    {
                        yellowCards.Add(row[col].ToString());
                    }
                }
                tbPastWel.Text = "";
                tbPastNiet.Text = "";
                tbYellow.Text = yellowCards[cardCount].ToString();
                Length = yellowCards.Count;
                lblCurrentCard.Content = cardCount + 1 + "/" + Length;
                btnPastBijMij.IsEnabled = true;
                btnPastNietBijMij.IsEnabled = true;
                btnVolgende.IsEnabled = false;
                selectedYellowCards.Clear();

            }

        }

        private void btnPastBijMij_Click(object sender, RoutedEventArgs e)
        {
            tbPastWel.Text = tbYellow.Text;
            selectedYellowCards.Add(tbPastWel.Text);
            Length = yellowCards.Count;
            try
            {
                cardCount++;
                tbYellow.Text = yellowCards[cardCount];
                lblCurrentCard.Content = cardCount + 1 + "/" + Length;
            }
            catch (Exception)
            {
                tbYellow.Text = "";
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
                cardCount++;
                tbYellow.Text = yellowCards[cardCount];
                lblCurrentCard.Content = cardCount + 1 + "/" + Length;
            }
            catch (Exception)
            {
                tbYellow.Text = "";
                btnPastBijMij.IsEnabled = false;
                btnPastNietBijMij.IsEnabled = false;
                btnVolgende.IsEnabled = true;
            }
        }

    }
}
