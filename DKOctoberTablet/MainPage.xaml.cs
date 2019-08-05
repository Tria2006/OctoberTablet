using DKOctoberTablet.Pages;
using Windows.ApplicationModel.Core;
using Windows.UI;
using Windows.UI.Core.Preview;
using Windows.UI.ViewManagement;
using Windows.UI.Xaml;

namespace DKOctoberTablet
{
	/// <summary>
	/// An empty page that can be used on its own or navigated to within a Frame.
	/// </summary>
	public sealed partial class MainPage
	{
		public MainPage()
		{
			InitializeComponent();
			ApplicationViewTitleBar formattableTitleBar = ApplicationView.GetForCurrentView().TitleBar;
			formattableTitleBar.ButtonBackgroundColor = Colors.Transparent;
			formattableTitleBar.ButtonForegroundColor = Colors.Transparent;
			CoreApplicationViewTitleBar coreTitleBar = CoreApplication.GetCurrentView().TitleBar;
			coreTitleBar.ExtendViewIntoTitleBar = true;
			mainFrame.Navigate(typeof(MainPageButtons), mainFrame);
			mainFrame.Navigating += MainFrame_Navigating;
			SystemNavigationManagerPreview.GetForCurrentView().CloseRequested += this.OnCloseRequest;
			coreTitleBar.LayoutMetricsChanged += CoreTitleBar_LayoutMetricsChanged;
		}

		private void CoreTitleBar_LayoutMetricsChanged(CoreApplicationViewTitleBar sender, object args)
		{
			ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
		}

		private void OnCloseRequest(object sender, SystemNavigationCloseRequestedPreviewEventArgs e)
		{
			e.Handled = true;
		}

		private void MainFrame_Navigating(object sender, Windows.UI.Xaml.Navigation.NavigatingCancelEventArgs e)
		{
			//header.Visibility = e.SourcePageType == typeof(Gallery) ? Visibility.Collapsed : Visibility.Visible;
		}

		private void MainFrame_Navigated(object sender, Windows.UI.Xaml.Navigation.NavigationEventArgs e)
		{

		}

		private void MainPage_OnSizeChanged(object sender, SizeChangedEventArgs e)
		{
			var view = ApplicationView.GetForCurrentView();
			if (view.IsFullScreenMode)
				return;

			if (view.TryEnterFullScreenMode())
			{
				ApplicationView.PreferredLaunchWindowingMode = ApplicationViewWindowingMode.FullScreen;
			}
		}
	}
}
