using System.Collections.Generic;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace DKOctoberTablet.Models
{
	public class DirectoryData
    {
	    public string DirectoryName { get; set; }

	    public List<BitmapImage> Files { get; set; }
    }
}
