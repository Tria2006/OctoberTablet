using System.Collections.Generic;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;
using DKOctoberTablet.Models;

namespace DKOctoberTablet.Pages
{
	public sealed partial class CoDirectors
	{
		private Frame _mainFrame;
		private List<PersonDataModel> PersonList = new List<PersonDataModel>();

		public CoDirectors()
		{
			InitializeComponent();
			PersonList.Add(new PersonDataModel
			{
				Name = "Тест Тестович",
				Position = "Зам 1",
				Email = "111@aaa.ru",
				WorkHours = "9 - 18"
			});
			PersonList.Add(new PersonDataModel
			{
				Name = "Тест Тестович 2",
				Position = "Зам 2",
				Email = "222@aaa.ru",
				WorkHours = "10 - 18"
			});
			PersonList.Add(new PersonDataModel
			{
				Name = "Тест Тестович 3",
				Position = "Зам 3",
				Email = "333@aaa.ru",
				WorkHours = "11 - 18"
			});
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
			_mainFrame = e.Parameter as Frame;
			base.OnNavigatedTo(e);
		}
	}
}
