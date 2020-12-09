using DKOctoberTablet.Helpers;
using DKOctoberTablet.Models;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

namespace DKOctoberTablet.Pages
{
	public sealed partial class AdmPp : Page
	{
		private Frame _mainFrame;
		private List<PersonDataModel> PersonList = new List<PersonDataModel>();

		public AdmPp()
		{
			this.InitializeComponent();
			Task.Run(FillData).Wait();
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			_mainFrame = e.Parameter as Frame;
			base.OnNavigatedTo(e);
		}

		private async Task FillData()
		{
			var data = await new FilesHelper().GetAdmPpData();
			PersonList = data.Persons;
		}
	}
}
