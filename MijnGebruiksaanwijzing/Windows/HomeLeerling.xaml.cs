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
    /// Interaction logic for HomeLeerling.xaml
    /// </summary>
    public partial class HomeLeerling : Window
    {
        public HomeLeerling()
        {
            InitializeComponent();

            //uitloggen naar pagina loginscherm
            //dit scherm sluiten

            //button start spel ga naar SpelWindow
            //dit scherm sluiten

            //button naar MijnResultaten gaan (Naam leerling meegeven vanuit login pagina)
            //Naam opzoeken in database met de gebruikersnaam van de leerling

        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginwindow = new LoginScreen();
            loginwindow.Top = 0;
            loginwindow.Left = 0;
            loginwindow.Show();
            this.Close();
        }

        private void btnStartGame_Click(object sender, RoutedEventArgs e)
        {
            popupStart.IsOpen = true;
        }

        private void Label_MouseUp(object sender, MouseButtonEventArgs e)
        {
            popupStart.IsOpen = false;
        }
    }
}
