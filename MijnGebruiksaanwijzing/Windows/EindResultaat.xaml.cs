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

		//public void SaveCurrentViewToXPS()
		//{
		//    // Configure save file dialog box
		//    Microsoft.Win32.SaveFileDialog dlg = new Microsoft.Win32.SaveFileDialog();
		//    dlg.FileName = String.Format("MyFile{0:ddMMyyyyHHmmss}", DateTime.Now); // Default file name
		//    dlg.DefaultExt = ".xps"; // Default file extension
		//    dlg.Filter = "XPS Documents (.xps)|*.xps"; // Filter files by extension

		//    // Show save file dialog box
		//    Nullable<bool> result = dlg.ShowDialog();

		//    // Process save file dialog box results
		//    if (result == true)
		//    {
		//        // Save document
		//        string filename = dlg.FileName;

		//        // Initialize the xps document structure
		//        FixedDocument fixedDoc = new FixedDocument();
		//        PageContent pageContent = new PageContent();
		//        FixedPage fixedPage = new FixedPage();

		//        // Create the document and set the datacontext
		//        EindResultaat view = new EindResultaat();
		//        view.DataContext = theControlDataContext;
		//        view.UpdateLayout();

		//        // Get the page size of an A4 document
		//        var pageSize = new Size(8.5 * 96.0, 11.0 * 96.0);

		//        // We just fit it horizontally, so only the width is set here
		//        //view.Height = pageSize.Height;
		//        view.Width = pageSize.Width;
		//        view.UpdateLayout();

		//        //Create first page of document
		//        fixedPage.Children.Add(view);
		//        ((System.Windows.Markup.IAddChild)pageContent).AddChild(fixedPage);
		//        fixedDoc.Pages.Add(pageContent);

		//        // Create the xps file and write it
		//        XpsDocument xpsd = new XpsDocument(filename, FileAccess.ReadWrite);
		//        XpsDocumentWriter xw = XpsDocument.CreateXpsDocumentWriter(xpsd);
		//        xw.Write(fixedDoc);
		//        xpsd.Close();
		//    }
		//}


	}
}
