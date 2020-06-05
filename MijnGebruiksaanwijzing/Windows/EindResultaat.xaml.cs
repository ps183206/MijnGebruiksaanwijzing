using MySql.Data.MySqlClient;
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
    /// Interaction logic for EindResultaat.xaml
    /// </summary>
    public partial class EindResultaat : Window
    {
        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;

        public EindResultaat()
        {
            server = "localhost";
            database = "mijngebruiksaanwijzing";
            uid = "root";
            password = "";

            string connString;
            connString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            conn = new MySqlConnection(connString);

            InitializeComponent();

            // GridView/ListView laten vullen met de resultaten van het gespeelde spel
        }

        private void btnSaveResult_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // De knop alle resultaten + aanvullingen op laten slaan in de database


                HomeLeerling homeleerling = new HomeLeerling();
                homeleerling.Top = 0;
                homeleerling.Left = 0;
                homeleerling.Show();
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Resultaten opslaan mislukt!");
            }
        }
    }
}
