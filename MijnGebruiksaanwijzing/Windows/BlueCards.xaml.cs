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

        List<string> ArrayList = new List<string>();

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

        int GetSelectedYellow { get; set; }

        public BlueCards(string gameType, List<string> redCards, List<string> yellowCards)
        {
            InitializeComponent();

            game = gameType;
            NewRedCards = redCards;
            NewYellowCards = yellowCards;
            RedCardsLength = NewRedCards.Count();

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

            tbYellow.Text = SingleYellowCards[0].ToString();

            tbRed.Text = NewRedCards[0].ToString();

            tbBlue.Text = blueCards[cardCount].ToString();

            YellowCardLength = SingleYellowCards.Count() - 1;
            Length = blueCards.Count;
            lblCurrentCard.Content = cardCount + 1 + "/" + Length;


            GetSelectedYellow = 0;

            //lblCurrentYellowCard.Content = YellowCardCount + 1 + "/" + YellowCardLength + 1;
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
                EindResultaat eindResultaat = new EindResultaat(NewRedCards, NewYellowCards, FinalBlueCards);
                eindResultaat.Top = 0;
                eindResultaat.Left = 0;
                eindResultaat.Show();
                this.Close();
            }
            else
            {

                redCardCount++;
                YellowCardCount++;
                foreach (string element in selectedBlueCards)
                {
                    FullBlueCardString = element.ToString() + "_" + FullBlueCardString;
                }
                FinalBlueCards.Add(FullBlueCardString);
                FullBlueCardString = "";

                tbRed.Text = NewRedCards[redCardCount].ToString();
                NewYellowArray = redCardCount;

                SingleYellowCards.Clear();

                List<string> temporaryYellow = new List<string>();
                List<string> SecondYellowCards = new List<string>();

                SecondYellowCards = NewYellowCards;
                YellowCardLength--;
                //string maken met alleen de string die ik moet hebben
                GetSelectedYellow++;
                string SelectedYellow = SecondYellowCards[GetSelectedYellow];

                temporaryYellow.Add(SelectedYellow);

                foreach (string element in temporaryYellow[0].Split(delimiterChars))
                {
                    SingleYellowCards.Add(element);
                }

                SingleYellowCards.Remove("");

                YellowCardLength = SingleYellowCards.Count() - 1;

                tbYellow.Text = SingleYellowCards[0];

                cardCount = 0;
                YellowCardCount = 0;
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
                btnPastBijMij.Opacity = 1;
                btnPastNietBijMij.Opacity = 1;
                gridBlue.Visibility = Visibility.Visible;
                btnVolgende.Visibility = Visibility.Hidden;
                selectedBlueCards.Clear();

                //lblCurrentYellowCard.Content = YellowCardCount + 1 + "/" + YellowCardLength + 1;
            }
        }

        private void btnPastBijMij_MouseDown(object sender, RoutedEventArgs e)
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
                gridBlue.Visibility = Visibility.Hidden;
                btnVolgende.Visibility = Visibility.Visible;
                btnPastBijMij.IsEnabled = false;
                btnPastNietBijMij.IsEnabled = false;
                btnPastBijMij.Opacity = 0.5;
                btnPastNietBijMij.Opacity = 0.5;
            }
        }

        private void btnPastNietBijMij_MouseDown(object sender, RoutedEventArgs e)
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
                gridBlue.Visibility = Visibility.Hidden;
                btnVolgende.Visibility = Visibility.Visible;
                btnPastBijMij.IsEnabled = false;
                btnPastNietBijMij.IsEnabled = false;
                btnPastBijMij.Opacity = 0.5;
                btnPastNietBijMij.Opacity = 0.5;
            }
        }

        private void prevYellowCard_Click(object sender, RoutedEventArgs e)
        {
            if (tbYellow.Text == SingleYellowCards[0])
            {
                YellowCardCount = 0;
                tbYellow.Text = SingleYellowCards[YellowCardCount];
                lblCurrentYellowCard.Content = YellowCardCount;
            }
            else
            {
                YellowCardCount--;
                tbYellow.Text = SingleYellowCards[YellowCardCount];
            }

            //lblCurrentYellowCard.Content = YellowCardCount + 1 + "/" + YellowCardLength + 1;
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

            //lblCurrentYellowCard.Content = YellowCardCount + 1 + "/" + YellowCardLength + 1;
        }


    }
}
