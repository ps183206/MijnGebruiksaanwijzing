using iTextSharp;
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
using System.Xml;

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
		public string Categorie { get; }

		char delimiterChars = '_';

		private string documentName;
		private string categorie;

		public EindResultaat(List<string> redCards, List<string> yellowCards, List<string> blueCards)
        {
            InitializeComponent();

			redList = redCards;
			yellowList = yellowCards;
			blueList = blueCards;


		}

        private void btnSaveResult_Click(object sender, RoutedEventArgs e)
        {
            ExportToPdf();
        }

		private void ExportToPdf()
		{
			documentName = TxtStudentName.Text + DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");

			//File to write to
			var testFile = System.IO.Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), documentName + ".pdf");

			var fs = new FileStream(testFile, FileMode.Create, FileAccess.Write, FileShare.None);

			Document document = new Document(PageSize.A4, 25, 25, 30, 30);

			PdfWriter writer = PdfWriter.GetInstance(document, fs);

			document.AddAuthor("Summa College");
			document.AddCreator("Summa College Kaarten Spel");
			document.AddKeywords("Kaarten Spel");
			document.AddSubject("Resultaten Kaarten Spel");
			document.AddTitle($"Resultaten van {TxtStudentName.Text}");

			document.SetPageSize(PageSize.A4.Rotate());

			BaseColor redColor = new BaseColor(255, 195, 195);
			BaseColor yellowColor = new BaseColor(255, 255, 195);
			BaseColor blueColor = new BaseColor(195, 210, 255);
			BaseColor dirtyfuckingcolor = new BaseColor(214, 0, 149);

			document.Open();


			PdfPTable table = new PdfPTable(3);

			PdfPCell cell = new PdfPCell(new Phrase(" \n Resultaten \n"));
			cell.BackgroundColor = dirtyfuckingcolor;

			cell.Colspan = 3;
			cell.HorizontalAlignment = Element.ALIGN_CENTER;

			table.AddCell(cell);

			PdfPCell cell1 = new PdfPCell(new Phrase("\n Belemeringen \n"));
			cell1.BackgroundColor = dirtyfuckingcolor;

			PdfPCell cell2 = new PdfPCell(new Phrase("\n Oplossingen \n"));
			cell2.BackgroundColor = dirtyfuckingcolor;

			PdfPCell cell3 = new PdfPCell(new Phrase("\n Wie kan mij helpen \n"));
			cell3.BackgroundColor = dirtyfuckingcolor;

			table.AddCell(cell1);
			table.AddCell(cell2);
			table.AddCell(cell3);

			int index = 0;
			foreach (string redCard in redList)
			{
				PdfPCell redCell = new PdfPCell();
				redCell.BackgroundColor = redColor;
				redCell.AddElement(new Phrase(redCard));

				//addcell redCard
				table.AddCell(redCell);

				List<string> yList = new List<string>();
				List<string> bList = new List<string>();

				yList.Add(yellowList[index]);
				bList.Add(blueList[index]);
				//int yellow = 0;
				//int blue = 0;
				//ieder item in yellowlist dus hiermee bedoel [0] [1] [2] bijvoorbeeld
				foreach (string item in yList)
				{
					PdfPCell yellowCell = new PdfPCell();
					yellowCell.BackgroundColor = yellowColor;
					//if(index == yellow)
					//{
					//ieder element in item dus dit is de inhoud van bijv [0] = dit is een test_dit is nog een test
					foreach (string element in item.Split(delimiterChars))
					{
						//zet items in deze list als:        [0]dit is een test
						//                                   [1]dit is nog een test
						FinalyellowList.Add(element);
					}
					FinalyellowList.Remove("");
					string result = "";
					foreach (string yellowCard in FinalyellowList)
					{
						result += "- " + yellowCard + "\n";
					}
					//add to cell's
					yellowCell.AddElement(new Phrase(result));
					table.AddCell(yellowCell);

					//string result = Regex.Replace(input, @"\r\n?|\n", replacementString);

					FinalyellowList.Clear();

					//}
				}
				//ieder item in bluelist dus hiermee bedoel [0] [1] [2] bijvoorbeeld
				foreach (string item in bList)
				{
					PdfPCell blueCell = new PdfPCell();
					blueCell.BackgroundColor = blueColor;
					//if (index == blue)
					//{
					//ieder element in item dus dit is de inhoud van bijv [0] = dit is een test_dit is nog een test_
					foreach (string element in item.Split(delimiterChars))
					{
						//zet items in deze list als:        [0]dit is een test
						//                                   [1]dit is nog een test

						FinalBlueList.Add(element);
					}

					FinalBlueList.Remove("");
					string result = "";
					foreach (string blueCard in FinalBlueList)
					{
						result += "- " + blueCard + "\n";
					}
					//add to cell's
					blueCell.AddElement(new Phrase(result));
					table.AddCell(blueCell);

					FinalBlueList.Clear();
				//}
				}
				index++;
				//yellow++;
				//blue++;
			}

			document.Add(table);


			document.Close();

			writer.Close();

			fs.Close();

			MessageBox.Show("U kunt uw resultaten bekijken in het PDF op je bureaublad");

			System.Windows.Application.Current.Shutdown();
		}
	}
}
