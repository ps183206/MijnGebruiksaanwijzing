using MijnGebruiksaanwijzing.Windows;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
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

        MySqlConnection conn =
        new MySqlConnection("Server=localhost;Database=mijngebruiksaanwijzing;Uid=root;Pwd=");

        public LoginScreen()
        {
            InitializeComponent();
        }

        //private void tbUsername_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (tbUsername.Text == "Gebruikersnaam")
        //    {
        //        tbUsername.Text = "";
        //        tbUsername.Foreground = Brushes.Black;
        //    }
        //}

        //private void tbPassword_PreviewMouseDown(object sender, MouseButtonEventArgs e)
        //{
        //    if (tbPassword.Text == "Wachtwoord")
        //    {
        //        tbPassword.Text = "";
        //        tbPassword.Foreground = Brushes.Black;
        //    }
        //}

        private void btnLogin_Click(object sender, RoutedEventArgs e)
        {
            if (tbUsername.Text != "" && tbPassword.Text != "")
            {
                CheckLogin();
            }
            else
            {
                MessageBox.Show("Voer een gebruikersnaam en wachtwoord in!");
            }
        }

        private void CheckLogin()
        {
            //string username = tbUsername.Text;
            //string password = tbPassword.Text;

            ////hier wordt de query uitgevoerd om de gebruikersnaam en het wachtwoord op te halen uit de database
            //conn.Open();

            //MySqlCommand command = conn.CreateCommand();
            //command.CommandText = "$SELECT username, password FROM users WHERE Username = '{username}'";
            //command.Parameters.AddWithValue("@name", tbUsername.Text);
            //command.Parameters.AddWithValue("@pass", tbPassword.Text);
            //MySqlDataReader reader = command.ExecuteReader();

            //DataTable dtData = new DataTable();
            //dtData.Load(reader);

            //foreach (DataRow row in dtData.Rows)
            //{
            //    KaartenBeheer kaartenbeheer = new KaartenBeheer();
            //    kaartenbeheer.Top = 0;
            //    kaartenbeheer.Left = 0;
            //    this.Close();
            //    kaartenbeheer.Show();

            //    //else
            //    //{
            //    //    MessageBox.Show("Gebruikersnaam of wachtwoord is onjuist!");
            //    //}
            //}

            //conn.Close();

            string username = tbUsername.Text;
            string password = tbPassword.Text;

            using (MySqlCommand cmd = new MySqlCommand($"SELECT Username, Password FROM users WHERE Username = '{username}'"))
            {
                cmd.CommandType = CommandType.Text;
                cmd.Connection = conn;
                conn.Open();
                using (MySqlDataReader sdr = cmd.ExecuteReader())
                {
                    sdr.Read();
                    string user = sdr["Username"].ToString();
                    string pass = sdr["Password"].ToString();

                    if (username == user || password == pass)
                    {
                        KaartenBeheer kaartenbeheer = new KaartenBeheer();
                        kaartenbeheer.Top = 0;
                        kaartenbeheer.Left = 0;
                        this.Close();
                        kaartenbeheer.Show();
                    }
                    else
                    {
                        MessageBox.Show("De gebruikersnaam of wachtwoord is incorrect!");
                    }
                }
                conn.Close();
            }
        }
    }
}
