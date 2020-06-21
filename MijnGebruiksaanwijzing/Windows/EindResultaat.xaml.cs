using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Reflection;
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
		List<string> redList = new List<string>();
		List<string> yellowList = new List<string>();
		List<string> blueList = new List<string>();

		List<string> FinalyellowList = new List<string>();
		List<string> FinalBlueList = new List<string>();

		string FullYellowString { get; set; }

		char delimiterChars = '_';

		public EindResultaat(List<string> redCards, List<string> yellowCards, List<string> blueCards)
        {
            InitializeComponent();

			redList = redCards;
			yellowList = yellowCards;
			//ieder item in yellowlist dus hiermee bedoel [0] [1] [2] bijvoorbeeld
			foreach (string item in yellowList)
			{
				//ieder element in item dus dit is de inhoud van bijv [0] = dit is een test_dit is nog een test
				foreach (string element in item.Split(delimiterChars))
				{
					//zet items in deze list als:		[0]dit is een test
					//									[1]dit is nog een test
					FinalyellowList.Add(element);
				}
			}
			blueList = blueCards;
			//ieder item in bluelist dus hiermee bedoel [0] [1] [2] bijvoorbeeld
			foreach (string item in blueList)
			{
				//ieder element in item dus dit is de inhoud van bijv [0] = dit is een test_dit is nog een test
				foreach (string element in item.Split(delimiterChars))
				{
					//zet items in deze list als:		[0]dit is een test
					//									[1]dit is nog een test
					FinalBlueList.Add(element);
				}
			}

			// GridView/ListView laten vullen met de resultaten van het gespeelde spel
			//redList.Add("Rood kaartje 1"); 
			//redList.Add("Rood kaartje 2"); 
			//redList.Add("Rood kaartje 3"); 
			//yellowList.Add("Geel kaartje 1, Geel kaartje 2"); 
			//yellowList.Add("Geel kaartje 3"); 
			//yellowList.Add("Geel kaartje 4, Geel kaartje 5, Geel kaartje 6"); 
			//blueList.Add("Blauw kaartje 1"); 
			//blueList.Add("Blauw kaartje 2"); 
			//blueList.Add("Blauw kaartje 3, Blauw kaartje 4"); 

			var lvRedData = new ListView();
			foreach (var item in redList)
			{
				lvRed.Items.Add(item);
			}

			var lvYellowData = new ListView();
			foreach (var item in FinalyellowList)
			{
				lvYellow.Items.Add(item);
			}

			var lvBlueData = new ListView();
			foreach (var item in FinalBlueList)
			{
				lvBlue.Items.Add(item);
			}
		}

        private void btnSaveResult_Click(object sender, RoutedEventArgs e)
        {
            ExportToPdf();
        }

		private void ExportToPdf()
		{
			try
			{
				var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
				string path = $"C:\\Users\\{Environment.UserName}\\Downloads\\{Assembly.GetEntryAssembly().GetName().Name}.pdf";
				PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));
				pdfDoc.Open();

				var headerTable = new PdfPTable(new[] { 1.25f, 1.25f, 1.25f })
				{
					WidthPercentage = 75,
					DefaultCell = { MinimumHeight = 22f }
				};

				headerTable.AddCell("Belemmering");
				headerTable.AddCell("Oplossing");
				headerTable.AddCell("Wie kan mij daarbij helpen?");
				headerTable.AddCell(redList[0]);
				headerTable.AddCell(yellowList[0]);
				headerTable.AddCell(blueList[0]);
				headerTable.AddCell(redList[1]);
				headerTable.AddCell(yellowList[1]);
				headerTable.AddCell(blueList[1]);
				headerTable.AddCell(redList[2]);
				headerTable.AddCell(yellowList[2]);
				headerTable.AddCell(blueList[2]);


				pdfDoc.Add(headerTable);

				pdfDoc.Close();

				MessageBox.Show("Resultaten gedownload als Pdf!");
			}
			catch (Exception ex)
			{
				MessageBox.Show("Downloaden mislukt.");
			}
		}
	}
}
