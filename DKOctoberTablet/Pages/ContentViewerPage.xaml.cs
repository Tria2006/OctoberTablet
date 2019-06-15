using System;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;
using DKOctoberTablet.Models;

namespace DKOctoberTablet.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class ContentViewerPage
    {
        private Frame _mainFrame;
        private object data;

        public ContentViewerPage()
        {
            InitializeComponent();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            if (e.Parameter is ContentPageNavParameter args)
            {
                _mainFrame = args.MainFrame;
                data = args.Parameter;
            }

            base.OnNavigatedTo(e);
        }

        private void BackTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame.GoBack();
        }
    }
}
