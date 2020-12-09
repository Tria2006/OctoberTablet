using DKOctoberTablet.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// Документацию по шаблону элемента "Пустая страница" см. по адресу https://go.microsoft.com/fwlink/?LinkId=234238

namespace DKOctoberTablet.Pages
{
    /// <summary>
    /// Пустая страница, которую можно использовать саму по себе или для перехода внутри фрейма.
    /// </summary>
    public sealed partial class MainPageButtons : Page
    {
        private Frame _mainFrame;
        public MainPageButtons()
        {
            this.InitializeComponent();
        }

        private void InfoButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame?.Navigate(typeof(Info), _mainFrame);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _mainFrame = e.Parameter as Frame;
            base.OnNavigatedTo(e);
        }

        private void AdministrationButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame?.Navigate(typeof(Administration), _mainFrame);
        }

        private void ScheduleButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame?.Navigate(typeof(Schedule), _mainFrame);
        }

        private void PosterButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            if (!(sender is Button btn)) return;
            if (string.IsNullOrEmpty(btn.Tag?.ToString())) return;

            _mainFrame.Navigate(typeof(ContentViewerPage), new ContentPageNavParameter
            (
                _mainFrame,
                new ContentPageNavData
                {
                    Folder = KnownFolders.PicturesLibrary,
                    // этот параметр выбирается на основе тэга Tag у Button'ов
                    // он указывает название корневой папки, т.е. откуда нужно начинать поиск
                    // например, для документов создана папка Docs в PicturesLibrary(это дефолтная папка винды "Изображения" или "Pictures")
                    // и после перехода на ContentViewerPage выполнится поиск документов по этой папке(включая подпапки)
                    // результаты поиска собираются в List<DirectoryData>, и его отображает ContentViewerPage
                    RootFolderName = btn.Tag.ToString()
                }
            ));
        }

        private void AuditoriumButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame?.Navigate(typeof(Auditorium), _mainFrame);
        }

        private void GalleryButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame?.Navigate(typeof(Gallery), _mainFrame);
        }
    }
}
