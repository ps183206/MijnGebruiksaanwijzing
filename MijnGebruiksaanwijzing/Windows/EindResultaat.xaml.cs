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
        public EindResultaat()
        {
            InitializeComponent();

            // GridView/ListView laten vullen met de resultaten van het gespeelde spel
            // De knop alle resultaten + aanvullingen op laten slaan in de database
        }
    }
}
