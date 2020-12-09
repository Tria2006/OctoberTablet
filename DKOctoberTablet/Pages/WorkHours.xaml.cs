using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DKOctoberTablet.Pages
{
	public sealed partial class WorkHours : Page
	{
		private Frame _mainFrame;

		public WorkHours()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			_mainFrame = e.Parameter as Frame;
			base.OnNavigatedTo(e);
		}
	}
}
