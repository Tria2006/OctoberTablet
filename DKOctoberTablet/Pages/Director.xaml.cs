using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DKOctoberTablet.Helpers;
using DKOctoberTablet.Models;

namespace DKOctoberTablet.Pages
{
	public sealed partial class Director
	{
		private Frame _mainFrame;
		public PersonDataModel directorData { get; set; }

		public Director()
		{
			InitializeComponent();
			Task.Run(FillData).Wait();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			_mainFrame = e.Parameter as Frame;
			base.OnNavigatedTo(e);
		}

		private async Task FillData()
		{
			directorData = await new FilesHelper().GetDirectorData();
		}
	}
}
