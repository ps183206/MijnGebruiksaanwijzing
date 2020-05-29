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
    /// Interaction logic for SpelerBeheer.xaml
    /// </summary>
    public partial class SpelerBeheer : Window
    {
        public SpelerBeheer()
        {
            InitializeComponent();

        }

        private void btnAccept_Click(object sender, RoutedEventArgs e)
        {
            bool Admin = false;
            if (tbVoornaam.Text == "")
            {
                MessageBox.Show("U moet een Voornaam invullen");
            }
            else if (tbAchternaam.Text == "")
            {
                MessageBox.Show("U moet een Achternaam invullen");
            }
            else if (tbGebruikersnaam.Text == "")
            {
                MessageBox.Show("U moet een Gebruikersnaam invullen");
            }
            else if (tbWachtwoord.Text == "")
            {
                MessageBox.Show("U moet een Wachtwoord invullen");
            }
            else
            {
                if (rdbAdmin.IsChecked == true)
                {
                    Admin = true;
                }
                else
                {
                    Admin = false;
                }

                //TODO NADAT DATABASE AFGEMAAKT IS EN GEGEVENS MEE GEGEVEN KUNNEN WORDEN
            }
        }

        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            HomeBegeleider HomeB = new HomeBegeleider();
            HomeB.Top = 0;
            HomeB.Left = 0;
            HomeB.Show();
            this.Close();
        }
    }
}
