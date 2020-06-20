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

        List<string> SingleYellowCards = new List<string>();
        List<string> FinalBlueCards = new List<string>();


        char delimiterChars = '_';

        string FullBlueCardString = "";
        //int array { get; set; }
        //string NewArray { get; set; }

        MySqlConnection conn =
            new MySqlConnection("Server=localhost;Database=mijngebruiksaanwijzing;Uid=root;Pwd=");


        int cardCount = 0;
        int redCardCount = 0;


        int YellowCardCount = 0;

        int Length = 0;

        int a = 1;

        string[] Array { get; set; }

        int YellowCardLength { get; set; }
        public int RedCardsLength { get; private set; }

        public string game { get; set; }

        int NewYellowArray { get; set; }

        public BlueCards(string gameType, List<string> redCards, List<string> yellowCards)
        {
            InitializeComponent();

            game = gameType;
            NewRedCards = redCards;
            NewYellowCards = yellowCards;

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
        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Array = NewYellowCards[0].Split(delimiterChars);

            Array = Array.Take(Array.Count() - 1).ToArray();

            foreach (string element in Array)
            {
                SingleYellowCards.Add(element);
            }

            tbYellow.Text = SingleYellowCards[0];

            tbRed.Text = NewRedCards[0].ToString();

            tbBlue.Text = blueCards[cardCount].ToString();

            YellowCardLength = SingleYellowCards.Count() - 1;
            Length = blueCards.Count;
            lblCurrentCard.Content = cardCount + 1 + "/" + Length;
        }

        private void btnVolgende_Click(object sender, RoutedEventArgs e)
        {
            RedCardsLength--;
            if (RedCardsLength == 0)
            {
                //Naar volgende pagina
                foreach (string element in selectedBlueCards)
                {
                    FullBlueCardString = element.ToString() + "_" + FullBlueCardString;
                }
                FinalBlueCards.Add(FullBlueCardString);
                FullBlueCardString = "";
                


                //Door naar volgende pagina
            }
            else
            {

                redCardCount++;
                foreach (string element in selectedBlueCards)
                {
                    FullBlueCardString = element.ToString() + "_" + FullBlueCardString;
                }
                FinalBlueCards.Add(FullBlueCardString);
                FullBlueCardString = "";

                tbRed.Text = NewRedCards[redCardCount].ToString();

                NewYellowArray = redCardCount;

                Array = NewYellowCards[NewYellowArray].Split(delimiterChars);

                Array = Array.Take(Array.Count() - 1).ToArray();

                SingleYellowCards.Clear();

                foreach (string element in Array)
                {
                    SingleYellowCards.Add(element);
                }

                tbYellow.Text = SingleYellowCards[0];



                cardCount = 0;
                blueCards.Clear();
                conn.Open();
                MySqlCommand command = conn.CreateCommand();

                //ophalen uit de database
                command.CommandText = "SELECT CardDesc FROM `cards` WHERE CardColor = 'Blue' AND CardType = @type";
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
                        blueCards.Add(row[col].ToString());
                    }
                }

                tbPastWel.Text = "";
                tbPastNiet.Text = "";

                tbBlue.Text = blueCards[cardCount].ToString();
                Length = blueCards.Count;

                lblCurrentCard.Content = cardCount + 1 + "/" + Length;

                btnPastBijMij.IsEnabled = true;
                btnPastNietBijMij.IsEnabled = true;
                btnVolgende.IsEnabled = false;

            }
        }

        private void btnPastBijMij_Click(object sender, RoutedEventArgs e)
        {
            tbPastWel.Text = tbBlue.Text;
            selectedBlueCards.Add(tbPastWel.Text);
            Length = blueCards.Count;

            try
            {
                cardCount++;
                tbBlue.Text = blueCards[cardCount];
                lblCurrentCard.Content = cardCount + 1 + "/" + Length;
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
                lblCurrentCard.Content = cardCount + 1 + "/" + Length;
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
            if (tbYellow.Text == SingleYellowCards[0])
            {
                YellowCardCount = 0;
                tbYellow.Text = SingleYellowCards[YellowCardCount];
            }
            else
            {
                YellowCardCount--;
                tbYellow.Text = SingleYellowCards[YellowCardCount];
            }
        }

        private void nextYellowCard_Click(object sender, RoutedEventArgs e)
        {
            if (YellowCardCount == YellowCardLength)
            {
                YellowCardCount = YellowCardLength;
                tbYellow.Text = SingleYellowCards[YellowCardCount];
            }
            else
            {
                YellowCardCount++;
                tbYellow.Text = SingleYellowCards[YellowCardCount];
            }
        }


    }
}
