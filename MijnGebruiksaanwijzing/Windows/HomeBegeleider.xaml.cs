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
    /// Interaction logic for HomeBegeleider.xaml
    /// </summary>
    public partial class HomeBegeleider : Window
    {
        public HomeBegeleider()
        {
            InitializeComponent();

            //uitlog knop aanmaken deze window sluiten en LoginScreen openen

            //Kaarten Beheer knop zorgen dat die werkend is
            //doorgaan naar volgende pagina
            //deze pagina sluiten

            //doorgaan naar kaarten beheer pagina
            //deze pagina sluiten
        }

        private void btnLogout_Click(object sender, RoutedEventArgs e)
        {
            LoginScreen loginwindow = new LoginScreen();
            loginwindow.Top = 0;
            loginwindow.Left = 0;
            loginwindow.Show();
            this.Close();
        }

        private void btnCardWin_Click(object sender, RoutedEventArgs e)
        {
            KaartenBeheer CardStorage = new KaartenBeheer();
            CardStorage.Top = 0;
            CardStorage.Left = 0;
            CardStorage.Show();
            this.Close();
        }

        private void btnPlayerBase_Click(object sender, RoutedEventArgs e)
        {
            SpelerBeheer PlayerStorage = new SpelerBeheer();
            PlayerStorage.Top = 0;
            PlayerStorage.Left = 0;
            PlayerStorage.Show();
            this.Close();
        }
    }
}
