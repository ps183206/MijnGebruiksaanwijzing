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

    }
}
