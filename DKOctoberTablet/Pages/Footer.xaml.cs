using System.Linq;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace DKOctoberTablet.Pages
{
    public sealed partial class Footer
    {
	    public static readonly DependencyProperty MainFrameProperty = DependencyProperty.Register(
		    "MainFrame", typeof(Frame), typeof(Footer), new PropertyMetadata(default(Frame)));

	    public Frame MainFrame
	    {
		    get => (Frame) GetValue(MainFrameProperty);
		    set => SetValue(MainFrameProperty, value);
	    }

        public Footer()
        {
            InitializeComponent();
        }

        private void BackTapped(object sender, TappedRoutedEventArgs e)
        {
	        MainFrame.GoBack();
        }

	    private void ToMainPageTapped(object sender, TappedRoutedEventArgs e)
	    {
		    var main = MainFrame.BackStack.FirstOrDefault();
			if( main == null)
				MainFrame.GoBack();
			else
			{
				MainFrame.Navigate(main.SourcePageType, main.Parameter);
			}
	    }
    }
}
