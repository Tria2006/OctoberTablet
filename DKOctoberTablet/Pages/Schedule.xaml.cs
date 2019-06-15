﻿using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace DKOctoberTablet.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Schedule : Page
    {
        private Frame _mainFrame;

        public Schedule()
        {
            InitializeComponent();
        }

        private void BackTapped(object sender, TappedRoutedEventArgs e)
        {
            _mainFrame.GoBack();
        }

        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            _mainFrame = e.Parameter as Frame;
            base.OnNavigatedTo(e);
        }
    }
}
