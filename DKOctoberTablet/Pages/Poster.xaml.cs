using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Navigation;

namespace DKOctoberTablet.Pages
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class Poster : Page
    {
	    public static readonly DependencyProperty MainFrameProperty = DependencyProperty.Register(
		    "MainFrame", typeof(Frame), typeof(Poster), new PropertyMetadata(default(Frame)));

	    public Frame MainFrame
	    {
		    get => (Frame) GetValue(MainFrameProperty);
		    set => SetValue(MainFrameProperty, value);
	    }

        public Poster()
        {
            InitializeComponent();
        }

        private void BackTapped(object sender, TappedRoutedEventArgs e)
        {
	        MainFrame.GoBack();
        }
    }
}
