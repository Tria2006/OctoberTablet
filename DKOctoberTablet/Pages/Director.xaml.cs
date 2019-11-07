using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DKOctoberTablet.Models;

namespace DKOctoberTablet.Pages
{
	public sealed partial class Director
	{
		private Frame _mainFrame;
		public PersonDataModel directorData;

		public Director()
		{
			InitializeComponent();
			directorData = new PersonDataModel
			{
				Name = "Агеева Марина Анатольевна",
				Position = "Директор",
				WorkHours = "Ежедневно 9:00 - 18:00",
				Email = "123@mail.ru"
			};
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			_mainFrame = e.Parameter as Frame;
			base.OnNavigatedTo(e);
		}
	}
}
