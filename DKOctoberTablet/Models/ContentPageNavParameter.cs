using Windows.UI.Xaml.Controls;

namespace DKOctoberTablet.Models
{
    public class ContentPageNavParameter
    {
        public Frame MainFrame { get; set; }

        public ContentPageNavData Parameter { get; set; }

        public ContentPageNavParameter(Frame mainFrame, ContentPageNavData parameter)
        {
            MainFrame = mainFrame;
            Parameter = parameter;
        }
    }
}
