using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace DKOctoberTablet.Pages
{
    public sealed partial class Administration
    {
        private Frame _mainFrame;

        public Administration()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _mainFrame = e.Parameter as Frame;
            base.OnNavigatedTo(e);
        }

	    private void DirectorOnTapped(object sender, TappedRoutedEventArgs e)
		{
			_mainFrame?.Navigate(typeof(Director), _mainFrame);
		}

	    private void CoDirectorsOnTapped(object sender, TappedRoutedEventArgs e)
		{
			_mainFrame?.Navigate(typeof(CoDirectors), _mainFrame);
		}

		private void SectorsTapped(object sender, TappedRoutedEventArgs e)
		{
			_mainFrame?.Navigate(typeof(SectorsEmployees), _mainFrame);
		}
	}
}
