using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media.Imaging;
using Windows.UI.Xaml.Navigation;

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
            // await GetFiles();
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

            mainFlipView.ItemsSource = images;
        }
    }
}
