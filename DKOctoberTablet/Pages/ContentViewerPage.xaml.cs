using DKOctoberTablet.Helpers;
using DKOctoberTablet.Models;
using System.Collections.Generic;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace DKOctoberTablet.Pages
{
	public sealed partial class ContentViewerPage
    {
        private Frame _mainFrame;

	    public static readonly DependencyProperty dataProperty = DependencyProperty.Register(
		    "data", typeof(List<DirectoryData>), typeof(ContentViewerPage), new PropertyMetadata(default(List<DirectoryData>)));

	    public List<DirectoryData> data
	    {
		    get => (List<DirectoryData>) GetValue(dataProperty);
		    set => SetValue(dataProperty, value);
	    }
	    private readonly FilesHelper _filesHelper;

        public ContentViewerPage()
        {
            InitializeComponent();
			_filesHelper = new FilesHelper();
        }

        protected override async void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ContentPageNavParameter args)
            {
                _mainFrame = args.MainFrame;
	            data = await _filesHelper.GetDirectoryData(args.Parameter.Folder, args.Parameter.RootFolderName);
            }

            base.OnNavigatedTo(e);
        }

        private void BackTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame.GoBack();
        }
    }
}
