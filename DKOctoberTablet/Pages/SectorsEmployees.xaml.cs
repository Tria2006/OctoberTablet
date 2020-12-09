using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DKOctoberTablet.Helpers;
using DKOctoberTablet.Models;

namespace DKOctoberTablet.Pages
{
	public sealed partial class SectorsEmployees : Page
	{
		private Frame _mainFrame;
		private List<PersonDataModel> PersonList = new List<PersonDataModel>();

		public SectorsEmployees()
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
			var data = await new FilesHelper().GetSectorsEmployeesData();
			PersonList = data.Persons;
		}
	}
}
