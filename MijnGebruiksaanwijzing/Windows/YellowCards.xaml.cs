﻿using System;
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
    }
}