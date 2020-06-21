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
using Path = System.IO.Path;

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

        string documentName;
        int exported;

        public EindResultaat(List<string> redCards, List<string> yellowCards, List<string> blueCards)
        {
            InitializeComponent();

            // GridView/ListView laten vullen met de resultaten van het gespeelde spel
            redList.Add("Rood kaartje 1");
            redList.Add("Rood kaartje 2");
            redList.Add("Rood kaartje 3");
            yellowList.Add("Geel kaartje 1, Geel kaartje 2");
            yellowList.Add("Geel kaartje 3");
            yellowList.Add("Geel kaartje 4, Geel kaartje 5, Geel kaartje 6");
            blueList.Add("Blauw kaartje 1");
            blueList.Add("Blauw kaartje 2");
            blueList.Add("Blauw kaartje 3, Blauw kaartje 4");

            var lvRedData = new ListView();
            foreach (var item in redList)
            {
                lvRed.Items.Add(item);
            }

            var lvYellowData = new ListView();
            foreach (var item in yellowList)
            {
                lvYellow.Items.Add(item);
            }

            var lvBlueData = new ListView();
            foreach (var item in blueList)
            {
                lvBlue.Items.Add(item);
            }
        }

        private void btnSaveResult_Click(object sender, RoutedEventArgs e)
        {
            WriteToPdf();
        }

		//private void ExportToPdf()
		//{
		//	try
		//	{
		//		var pdfDoc = new Document(PageSize.LETTER, 40f, 40f, 60f, 60f);
		//		string path = $"C:\\Users\\{Environment.UserName}\\Downloads\\{Assembly.GetEntryAssembly().GetName().Name}.pdf";
		//		PdfWriter.GetInstance(pdfDoc, new FileStream(path, FileMode.OpenOrCreate));
		//		pdfDoc.Open();

		//		var headerTable = new PdfPTable(new[] { 1.25f, 1.25f, 1.25f })
		//		{
		//			WidthPercentage = 75,
		//			DefaultCell = { MinimumHeight = 22f }
		//		};

		//		headerTable.AddCell("Belemmering");
		//		headerTable.AddCell("Oplossing");
		//		headerTable.AddCell("Wie kan mij daarbij helpen?");
		//		headerTable.AddCell(redList[0]);
		//		headerTable.AddCell(yellowList[0]);
		//		headerTable.AddCell(blueList[0]);
		//		headerTable.AddCell(redList[1]);
		//		headerTable.AddCell(yellowList[1]);
		//		headerTable.AddCell(blueList[1]);
		//		headerTable.AddCell(redList[2]);
		//		headerTable.AddCell(yellowList[2]);
		//		headerTable.AddCell(blueList[2]);


		//		pdfDoc.Add(headerTable);

		//		pdfDoc.Close();

		//		MessageBox.Show("Resultaten gedownload als Pdf!");
		//	}
		//	catch (Exception ex)
		//	{
		//		MessageBox.Show("Downloaden mislukt.");
		//	}
		//}
	
	
		private void WriteToPdf()
		{
            XmlDocument xmldoc = new XmlDocument();
            xmldoc.Load(@"..\..\XML\MijnGebruiksaanwijzing.xml");

            //Sample XML
            var xml = xmldoc;

            documentName = DateTime.Now.ToString("dd-MM-yyyy HH-mm-ss");

            //File to write to
            var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), documentName + ".pdf");

            //Standard PDF creation, nothing special here
            using (var fs = new FileStream(testFile, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                using (var doc = new Document())
                {
                    using (var writer = PdfWriter.GetInstance(doc, fs))
                    {
                        doc.SetPageSize(PageSize.A4.Rotate());
                        doc.Open();

                        var t = new PdfPTable(4);

                        t.WidthPercentage = 100; //table width to 100per

                        //Flag that the first row should be repeated on each page break
                        t.HeaderRows = 1;

                        BaseColor redtxtColor = new BaseColor(255, 144, 150);
                        BaseColor yellowtxtColor = new BaseColor(250, 220, 60);
                        BaseColor bluetxtColor = new BaseColor(140, 170, 255);
                        BaseColor opmtxtColor = new BaseColor(175, 230, 230);
                        BaseColor normaltxtColor = new BaseColor(0, 0, 0);

                        BaseFont bfTimes = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, false);

                        Font redHelvetica = new Font(bfTimes, 12, Font.BOLD, redtxtColor);
                        Font yellowHelvetica = new Font(bfTimes, 12, Font.BOLD, yellowtxtColor);
                        Font blueHelvetica = new Font(bfTimes, 12, Font.BOLD, bluetxtColor);
                        Font opmHelvetica = new Font(bfTimes, 12, Font.BOLD, opmtxtColor);
                        Font normalHelvetica = new Font(bfTimes, 12, Font.NORMAL, normaltxtColor);

                        t.AddCell(new Phrase("Belemmering", redHelvetica));
                        t.AddCell(new Phrase("Oplossing", yellowHelvetica));
                        t.AddCell(new Phrase("Wie kan mij daarbij helpen?", blueHelvetica));
                        t.AddCell(new Phrase("Opmerking", opmHelvetica));
                        t.CompleteRow();

                        //Loop through each CD row (this is so we can call complete later on)
                        foreach (XmlNode CD in xml.SelectSingleNode("Game").SelectNodes("Cards"))
                        {
                            var Cards = new Dictionary<string, string>
                                {
                                    { "RedCard", "" },
                                    { "YellowCard", "" },
                                    { "BlueCard", "" },
                                    { "Opmerking", "" }
                                };

                            //Loop through each child of the current CD. Limit the number of children to our initial count just in case there are extra nodes.
                            foreach (XmlNode node in CD.ChildNodes)
                            {
                                if (node.Name == "YellowCard" || node.Name == "BlueCard")
                                {
                                    Cards[node.Name] += " - " + node.InnerText + System.Environment.NewLine;
                                }
                                else
                                {
                                    Cards[node.Name] += node.InnerText + System.Environment.NewLine;
                                }
                            }

                            BaseColor redColor = new BaseColor(255, 195, 195);
                            BaseColor yellowColor = new BaseColor(255, 255, 195);
                            BaseColor blueColor = new BaseColor(195, 210, 255);
                            BaseColor opmColor = new BaseColor(195, 255, 255);

                            PdfPCell redCell = new PdfPCell();
                            PdfPCell yellowCell = new PdfPCell();
                            PdfPCell blueCell = new PdfPCell();
                            PdfPCell opmCell = new PdfPCell();

                            redCell.BackgroundColor = redColor;
                            yellowCell.BackgroundColor = yellowColor;
                            blueCell.BackgroundColor = blueColor;
                            opmCell.BackgroundColor = opmColor;

                            redCell.AddElement(new Phrase(Cards["RedCard"], normalHelvetica));
                            yellowCell.AddElement(new Phrase(Cards["YellowCard"], normalHelvetica));
                            blueCell.AddElement(new Phrase(Cards["BlueCard"], normalHelvetica));
                            opmCell.AddElement(new Phrase(Cards["Opmerking"], normalHelvetica));

                            t.AddCell(redCell);
                            t.AddCell(yellowCell);
                            t.AddCell(blueCell);
                            t.AddCell(opmCell);

                            //Just in case any rows have too few cells fill in any blanks
                            t.CompleteRow();
                        }

                        //Add the table to the document
                        doc.Add(t);

                        doc.Close();
                    }
                }
            }
            exported = 1;
            MessageBox.Show("Het PDF bestand is succesvol geëxporteerd naar uw bureaublad.");
        }
	}
}
