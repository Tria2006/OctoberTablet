using System;
using System.Collections.Generic;
using Windows.Data.Pdf;
using Windows.Storage;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;
using DKOctoberTablet.Helpers;
using DKOctoberTablet.Models;
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
		private FilesHelper _helper;
		public List<DirectoryData> Directories { get; set; } = new List<DirectoryData>();

        public Gallery()
        {
            InitializeComponent();
			_helper = new FilesHelper();
        }

        private void BackTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame.GoBack();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
	        Directories = await _helper.GetDirectoryData(KnownFolders.PicturesLibrary, "Gallery");
            // await GetFiles();
			// await OpenPdf();
            _mainFrame = e.Parameter as Frame;
            base.OnNavigatedTo(e);
        }

	 //   private async Task OpenPdf()
	 //   {
		//	var directoryData = await new FilesHelper().GetFiles(KnownFolders.PicturesLibrary, "Gallery");

		//    foreach (var item in directoryData)
		//    {
			    
		//    }
		//	var file = await folder.GetFileAsync("RemoteAccessTS.pdf");
		//    PdfDocument doc = await PdfDocument.LoadFromFileAsync(file);

		//    await Load(doc);
		//}

        private void ScrollViewer_ViewChanged(object sender, Windows.UI.Xaml.Controls.ScrollViewerViewChangedEventArgs e)
        {

        }
    }
}
