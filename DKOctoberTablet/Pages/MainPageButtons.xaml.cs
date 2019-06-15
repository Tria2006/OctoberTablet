using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace DKOctoberTablet.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPageButtons
    {
        private Frame _mainFrame;

        public MainPageButtons()
        {
            InitializeComponent();
        }

        private void InfoButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame?.Navigate(typeof(Info), _mainFrame);
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _mainFrame = e.Parameter as Frame;
            base.OnNavigatedTo(e);
        }

	    private void AdministrationButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame?.Navigate(typeof(Administration), _mainFrame);
        }

        private void ScheduleButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame?.Navigate(typeof(Schedule), _mainFrame);
        }

        private void PosterButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame?.Navigate(typeof(Poster), _mainFrame);
        }

        private void AuditoriumButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame?.Navigate(typeof(Auditorium), _mainFrame);
        }

        private void GalleryButtonTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame?.Navigate(typeof(Gallery), _mainFrame);
        }
    }
}
