using Windows.UI.Xaml.Controls;

namespace DKOctoberTablet.Models
{
    public class ContentPageNavParameter
    {
        public Frame MainFrame { get; set; }

        public object Parameter { get; set; }

        public ContentPageNavParameter(Frame mainFrame, object parameter)
        {
            MainFrame = mainFrame;
            Parameter = parameter;
        }
    }
}
