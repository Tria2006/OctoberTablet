using Windows.UI.Xaml.Controls;
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

        private void TextBlock_SelectionChanged(object sender, Windows.UI.Xaml.RoutedEventArgs e)
        {

        }
    }
}
