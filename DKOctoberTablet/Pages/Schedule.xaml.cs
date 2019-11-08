using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Storage;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DKOctoberTablet.Helpers;
using DKOctoberTablet.Models;

namespace DKOctoberTablet.Pages
{
    public sealed partial class Schedule
    {
        private Frame _mainFrame;
		public List<ButtonData> buttons = new List<ButtonData>();

        public Schedule()
        {
            InitializeComponent();
	        Task.Run(GetButtons).Wait();
		}

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _mainFrame = e.Parameter as Frame;
            base.OnNavigatedTo(e);
        }

	    private async Task GetButtons()
	    {
		    var result = await new FilesHelper().GetButtons("scheduleButtons.json");
		    buttons = result.Buttons;
	    }
	    /// <summary>
	    /// Переход на страницу отображения содержимого папки
	    /// </summary>
	    /// <param name="sender">Нажатая кнопка</param>
	    /// <param name="e">Аргументы роутинга</param>
	    private void Button_Click(object sender, Windows.UI.Xaml.RoutedEventArgs e)
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
	}
}
