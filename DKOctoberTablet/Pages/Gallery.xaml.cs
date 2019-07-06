using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Windows.Data.Pdf;
using Windows.Storage;
using Windows.Storage.Streams;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using Microsoft.Office.Interop.Word;
using Frame = Windows.UI.Xaml.Controls.Frame;
using Page = Windows.UI.Xaml.Controls.Page;
using Task = System.Threading.Tasks.Task;

namespace DKOctoberTablet.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Gallery : Page
    {
        private Frame _mainFrame;

        public Gallery()
        {
            InitializeComponent();
        }

        private void BackTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame.GoBack();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            //await GetFiles();
			await OpenPdf();
            _mainFrame = e.Parameter as Frame;
            base.OnNavigatedTo(e);
        }

        private async Task GetFiles()
        {
            var localFolder = KnownFolders.PicturesLibrary;
            var folder = await localFolder.GetFolderAsync("123");
            var files = await folder.GetFilesAsync();
            var images = new List<BitmapImage>();
            foreach (var file in files)
            {
                using (var randomAccessStream = await file.OpenAsync(FileAccessMode.Read))
                {
                    var result = new BitmapImage();
                    await result.SetSourceAsync(randomAccessStream);
                    images.Add(result);
                }
            }

            //mainFlipView.ItemsSource = images;
        }

	    private void ConvertToPdf()
	    {
		    Application appWord = new Application();
		    var wordDocument = appWord.Documents.Open(@"D:\desktop\xxxxxx.docx");
		    wordDocument.ExportAsFixedFormat(@"D:\desktop\DocTo.pdf", WdExportFormat.wdExportFormatPDF);
		}

	    private async Task OpenPdf()
	    {
		    var lib = KnownFolders.PicturesLibrary;
		    var folder = await lib.GetFolderAsync("123");
			var file = await folder.GetFileAsync("RemoteAccessTS.pdf");
		    PdfDocument doc = await PdfDocument.LoadFromFileAsync(file);

		    await Load(doc);
		}

	    async Task Load(PdfDocument pdfDoc)
	    {
		    PdfPages.Clear();

		    for (uint i = 0; i < pdfDoc.PageCount; i++)
		    {
			    BitmapImage image = new BitmapImage();

			    var page = pdfDoc.GetPage(i);

			    using (InMemoryRandomAccessStream stream = new InMemoryRandomAccessStream())
			    {
				    await page.RenderToStreamAsync(stream);
				    await image.SetSourceAsync(stream);
			    }

			    PdfPages.Add(image);
		    }
	    }

	    public ObservableCollection<BitmapImage> PdfPages
	    {
		    get;
		    set;
	    } = new ObservableCollection<BitmapImage>();

        private void ScrollViewer_ViewChanged(object sender, Windows.UI.Xaml.Controls.ScrollViewerViewChangedEventArgs e)
        {

        }
    }
}
