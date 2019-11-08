using System.Collections.Generic;
using System.Linq;
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
	    private readonly FilesHelper _filesHelper;
		public List<ButtonData> buttons = new List<ButtonData>();
		private List<ScheduleItem> fullSchedule = new List<ScheduleItem>();

        public Schedule()
        {
            InitializeComponent();
	        _filesHelper = new FilesHelper();
	        Task.Run(GetButtons).Wait();
		}

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            _mainFrame = e.Parameter as Frame;
	        fullSchedule = await _filesHelper.GetFullSchedule();
			base.OnNavigatedTo(e);
        }

	    private async Task GetButtons()
	    {
		    var result = await _filesHelper.GetButtons("scheduleButtons.json");
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

		    _mainFrame.Navigate(typeof(ScheduleDetailPage), new ContentPageNavParameter
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
				    RootFolderName = btn.Tag.ToString(),
					OptionalParameter = fullSchedule.FirstOrDefault(x => x.Id == btn.Tag.ToString())
			    }
		    ));
	    }
	}
}
