using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DKOctoberTablet.Pages
{
	public sealed partial class Poster
	{
		private Frame _mainFrame;

		public Poster()
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
