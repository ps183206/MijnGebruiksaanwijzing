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
    /// Interaction logic for YellowCards.xaml
    /// </summary>
    public partial class YellowCards : Window
    {
        List<string> PastWelYellowList = new List<string>();
        List<string> YellowCardsList = new List<string>();

        public YellowCards()
        {
            InitializeComponent();
            //List die je van de vorige pagina mee kunt nemen komt in het midden te staan/ die wordt geladen
            //Beneden worden de eerste 5 van de lijst van yellow cards gepakt en als kaartjes onder toegevoegd.
            //ophalen uit de database
            //er moet door heen gecycled kunnen worden door de kaartjes onder
            //wanneer een kaartje gekoppeld wordt deze ook koppelen aan de database
            //dit kaartje verwijderen uit de list van yellow cards
            //wanneer alle rode kaartjes minimaal 1 geel kaartje hebben gekregen BtnDoorgaan visible maken
            //doorgaan naar volgend scherm
            //dit scherm sluiten
        }

        private void btnVolgende_Click(object sender, RoutedEventArgs e)
        {
            BlueCards blueCards = new BlueCards();
            blueCards.Top = 0;
            blueCards.Left = 0;
            blueCards.Show();
            this.Close();
        }

        private void btnPastBijMij_Click(object sender, RoutedEventArgs e)
        {
            tbPastWel.Text = tbYellow.Text;
            PastWelYellowList.Add(tbPastWel.Text);

            try
            {

            }
            catch (Exception)
            {
                tbYellow.Text = "";
                btnPastBijMij.IsEnabled = false;
                btnPastNietBijMij.IsEnabled = false;
                btnVolgende.IsEnabled = true;
            }
        }

        private void btnPastNietBijMij_Click(object sender, RoutedEventArgs e)
        {
            tbPastNiet.Text = tbYellow.Text;

            try
            {

            }
            catch (Exception)
            {
                tbYellow.Text = "";
                btnPastBijMij.IsEnabled = false;
                btnPastNietBijMij.IsEnabled = false;
                btnVolgende.IsEnabled = true;
            }
        }

    }
}
