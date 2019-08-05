using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Media.Imaging;
using Microsoft.Office.Interop.Word;

namespace DKOctoberTablet.Helpers
{
	internal class PdfHelper
	{
		public async Task<string> ConvertToPdf(string fileName, StorageFolder folder)
		{
			var appWord = new Application();
			var wordDocument = appWord.Documents.Open($"{folder.Path}{fileName}");
			var nameArr = fileName.Split('.');

			var file = await folder.TryGetItemAsync($"{nameArr.First()}.pdf");

			if (file != null) return $"{folder.Path}{nameArr.First()}.pdf";

			wordDocument.ExportAsFixedFormat($"{folder.Path}{nameArr.First()}.pdf", WdExportFormat.wdExportFormatPDF);
			return $"{folder.Path}{nameArr.First()}.pdf";
		}

		public async Task<List<BitmapImage>> LoadPdf(PdfDocument pdfDoc)
		{
			var result = new List<BitmapImage>();

			for (uint i = 0; i < pdfDoc.PageCount; i++)
			{
				BitmapImage image = new BitmapImage();

				var page = pdfDoc.GetPage(i);

				using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
				{
					await page.RenderToStreamAsync(stream);
					await image.SetSourceAsync(stream);
				}

				result.Add(image);
			}

			return result;
		}
	}
}
