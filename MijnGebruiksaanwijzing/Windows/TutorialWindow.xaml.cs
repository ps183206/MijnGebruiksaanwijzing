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
    /// Interaction logic for TutorialWindow.xaml
    /// </summary>
    public partial class TutorialWindow : Window
    {
        public TutorialWindow()
        {
            InitializeComponent(); 
        }

        //Terug naar leerling home screen
        //deze pagina sluiten
        private void btnBack_Click(object sender, RoutedEventArgs e)
        {
            HomeLeerling homeleerling = new HomeLeerling();
            homeleerling.Top = 0;
            homeleerling.Left = 0;
            homeleerling.Show();
            this.Close();
        }

        //verder naar de beginpagina van het spel
        //deze pagina sluiten
        private void btnContinue_Click(object sender, RoutedEventArgs e)
        {
            RedCards redcards = new RedCards();
            redcards.Top = 0;
            redcards.Left = 0;
            redcards.Show();
            this.Close();
        }    
    }
}
