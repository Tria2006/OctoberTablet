using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DKOctoberTablet.Models;

namespace DKOctoberTablet.Pages
{
	public sealed partial class ScheduleDetailPage
	{
		private Frame _mainFrame;
		private ScheduleItem data;

		public ScheduleDetailPage()
		{
			InitializeComponent();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			if (e.Parameter is ContentPageNavParameter args)
			{
				_mainFrame = args.MainFrame;

				if (args.Parameter.OptionalParameter is ScheduleItem)
					data = args.Parameter.OptionalParameter as ScheduleItem;
			}
			base.OnNavigatedTo(e);
		}
	}
}
