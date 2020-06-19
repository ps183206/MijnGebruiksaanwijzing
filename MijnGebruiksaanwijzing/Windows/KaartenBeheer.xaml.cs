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
using MySql.Data.MySqlClient;
using MySql.Data;
using System.Data;

namespace MijnGebruiksaanwijzing.Windows
{
    /// <summary>
    /// Interaction logic for KaartenBeheer.xaml
    /// </summary>
    public partial class KaartenBeheer : Window
    {


        public KaartenBeheer()
        {
            InitializeComponent();
            List<string> ListData = new List<string>();
            //CardID = AI
            //CardDesc = Description Content van de kaarten
            //CardColor = Cardkleur
            //CardType = Stage/School

            MySqlConnection conn =
            new MySqlConnection("Server=localhost;Database=mijngebruiksaanwijzing;Uid=root;Pwd=");

            conn.Open();
            MySqlCommand command = conn.CreateCommand();

            command.CommandText = "SELECT CardDesc FROM `cards` ";
            MySqlDataReader reader = command.ExecuteReader();
            DataTable dtData = new DataTable();
            dtData.Load(reader);
            conn.Close();
            foreach (DataRow row in dtData.Rows)
            {
                foreach (DataColumn col in dtData.Columns)
                {
                    ListData.Add(row[col].ToString());
                }
            }
            ListKaarten.ItemsSource = ListData;
            //Zorgen dat alle listviews gevuld worden met de gegevens vanuit de database
            //terugknop werkend maken

            //Boven bij de listview een + toevoegen dat de mogelijkheid gegevens wordt om iets toe te voegen

            //knopje bij selected item dat deze geedit kan worden

            // mogelijkheid om een kaart te verwijderen
        }
        public class AddData
        {
            //Database connectie maken

            //Database gegevens ophalen met query
            //Gegevens in de listview zetten
        }

        private void btnAdd_Click(object sender, RoutedEventArgs e)
        {
            String CardDesc = TxtDescription.Text;
            String CardColor = "";
            String CardType = "";
            MySqlConnection conn =
            new MySqlConnection("Server=localhost;Database=mijngebruiksaanwijzing;Uid=root;Pwd=");
            if (rdbred.IsChecked == true)
            {
                CardColor = "Red";
            }
            else if (rdbyellow.IsChecked == true)
            {
                CardColor = "Yellow";
            }
            else if (rdbblue.IsChecked == true)
            {
                CardColor = "Blue";
            }

            if (TxtType.Text == "")
            {
                MessageBox.Show("U heeft geen keuze gemaakt in stage of school");
            }
            else
            {
                CardType = TxtType.Text;
                conn.Open();
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = $"Insert into cards (CardID, CardDesc, CardColor, CardType) values ('', '{CardDesc}', '{CardColor}', '{CardType}')";
                MySqlDataReader reader = command.ExecuteReader();

                TxtDescription.Text = "";
                TxtType.Text = "";
            }
        }

        private void btnRemove_Click(object sender, RoutedEventArgs e)
        {
            MySqlConnection conn =
            new MySqlConnection("Server=localhost;Database=mijngebruiksaanwijzing;Uid=root;Pwd=");

            if (TxtDescription.Text == null)
            {
                MessageBox.Show("U heeft nog geen beschrijving toegevoegd, klik in het lijstje een beschrijving aan om deze aan te vullen");
            }
            else if (TxtType.Text == null)
            {
                MessageBox.Show("U heeft nog geen type kaartje toegevoegd, klik in het lijstje een beschrijving aan om deze aan te vullen");
            }
            else
            {
                string Desc = TxtDescription.Text;

                conn.Open();
                MySqlCommand command = conn.CreateCommand();

                command.CommandText = $"DELETE FROM `cards` WHERE CardDesc = '{Desc}'";
                MySqlDataReader reader = command.ExecuteReader();
                conn.Close();
                MessageBox.Show("Het kaartje is succesvol verwijderd");
            }
            List<string> ListData = new List<string>();

            conn.Open();
            MySqlCommand command2 = conn.CreateCommand();

            command2.CommandText = "SELECT CardDesc FROM `cards` ";
            MySqlDataReader reader2 = command2.ExecuteReader();
            DataTable dtData = new DataTable();
            dtData.Load(reader2);
            conn.Close();
            foreach (DataRow row in dtData.Rows)
            {
                foreach (DataColumn col in dtData.Columns)
                {
                    ListData.Add(row[col].ToString());
                }
            }
            ListKaarten.ItemsSource = ListData;
        }

        private void ListKaarten_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            MySqlConnection conn =
            new MySqlConnection("Server=localhost;Database=mijngebruiksaanwijzing;Uid=root;Pwd=");

            string CurrentCard = ListKaarten.SelectedItem.ToString();

            using (MySqlCommand cmd = new MySqlCommand($"SELECT CardDesc, CardColor, CardType FROM cards WHERE CardDesc = '{CurrentCard}'"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    TxtDescription.Text = sdr["CardDesc"].ToString();
                    string Color = sdr["CardColor"].ToString();
                    if (Color == "Red")
                    {
                        rdbred.IsChecked = true;
                    }
                    else if (Color == "Yellow")
                    {
                        rdbyellow.IsChecked = true;
                    }
                    else if (Color == "Blue")
                    {
                        rdbblue.IsChecked = true;
                    }
                    TxtType.Text = sdr["CardType"].ToString();
                }
                conn.Close();
            }
        }
    }
}
