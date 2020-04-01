using MijnGebruiksaanwijzing.Windows;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace MijnGebruiksaanwijzing
{
    /// <summary>
    /// Interaction logic for LoginScreen.xaml
    /// </summary>
    public partial class LoginScreen : Window
    {
        //Gegevens uit Txt's halen
        //gegevens nakijken via database
        //functie database oproepen
        //try catch maken voor als database niet werkt
        //nakijken voor leerling of leraar
        //wanneer de gegevens goed zijn doorsturen naar de bijbehorende pagina (HomeLeerling / HomeBegeleider)
        //gebruikersnaam mee geven naar Leerlinghome
        //window sluiten

        private MySqlConnection conn;
        private string server;
        private string database;
        private string uid;
        private string password;
        public LoginScreen()
        {
            server = "localhost";
            database = "mijngebruiksaanwijzing";
            uid = "root";
            password = "";

            string connString;
            connString = $"SERVER={server};DATABASE={database};UID={uid};PASSWORD={password};";

            conn = new MySqlConnection(connString);

            InitializeComponent();
        }

        private void tbUsername_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tbUsername.Text == "Gebruikersnaam")
            {
                tbUsername.Text = "";
                tbUsername.Foreground = Brushes.Black;
            }
        }

        private void tbPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        {
            if (tbPassword.Text == "Wachtwoord")
            {
                tbPassword.Text = "";
                tbPassword.Foreground = Brushes.Black;
            }
        }

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            string user = tbUsername.Text;
            string pass = tbPassword.Text;
            if (CanLogin(user, pass))
            {
                //conn.Open();
                //string rolequery = $"SELECT Role FROM users WHERE UserName = '{user}' AND Password ='{pass}';";

                //MySqlCommand cmd = new MySqlCommand(rolequery, conn);

                //if (rolequery == "0")
                //{
                //    HomeBegeleider winB = new HomeBegeleider();
                //    winB.Top = 0;
                //    winB.Left = 0;
                //    winB.Show();
                //    this.Close();
                //}
                //else if (rolequery == "1")
                //{
                //    HomeLeerling winL = new HomeLeerling();
                //    winL.Top = 0;
                //    winL.Left = 0;
                //    winL.Show();
                //    this.Close();
                //}
                //else
                //{
                //    MessageBox.Show(rolequery);
                //}
                try
                {
                    conn.Open();

                    // query to check whether value exists
                    string sql = $"SELECT Role FROM users WHERE UserName = '{user}' AND Password ='{pass}';";

                    // create the command object
                    using (MySqlCommand cmd = new MySqlCommand(sql, conn))
                    {
                        using (MySqlDataReader reader = cmd.ExecuteReader())
                        {
                            // if the result set is not NULL
                            if (reader.HasRows)
                            {
                                // update the existing value + the value from the text file
                                MessageBox.Show("gelukt");
                            }
                            else
                            {
                                // insert a value from a text file
                                MessageBox.Show("mislukt");
                            }
                        }
                    }
                }
                finally
                {
                    // always close connection when done
                    conn.Close();
                }

            }
            else
            {
                MessageBox.Show($"{user} bestaat niet of is incorrect!");
            }
        }

        public bool CanLogin(string user, string pass)
        {
            string query = $"SELECT * FROM users WHERE UserName = '{user}' AND Password ='{pass}';";

            try
            {
                if (OpenConnection())
                {
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        reader.Close();
                        conn.Close();
                        return true;
                    }
                    else
                    {
                        reader.Close();
                        conn.Close();
                        return false;
                    }
                }
                else
                {
                    conn.Close();
                    return false;
                }
            }
            catch (Exception ex)
            {
                conn.Close();
                return false;
            }
        }

        private bool OpenConnection()
        {
            try
            {
                conn.Open();
                return true;
            }
            catch (MySqlException ex)
            {
                switch (ex.Number)
                {
                    case 0:
                        MessageBox.Show("Connectie met de server mislukt!");
                        break;
                    case 1045:
                        MessageBox.Show("Server gebruikersnaam of wachtwoord is incorrect!");
                        break;
                }
                return false;
            }
        }
    }
}
