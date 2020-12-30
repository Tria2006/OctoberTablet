using DKOctoberTablet.Helpers;
using DKOctoberTablet.Models;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Media;

namespace DKOctoberTablet.UserControls
{
	public sealed partial class PersonData
	{
		public ImageSource PhotoData
		{
			get { return (ImageSource)GetValue(PhotoDataProperty); }
			set { SetValue(PhotoDataProperty, value); }
		}

		// Using a DependencyProperty as the backing store for PhotoData.  This enables animation, styling, binding, etc...
		public static readonly DependencyProperty PhotoDataProperty =
			DependencyProperty.Register("PhotoData", typeof(ImageSource), typeof(PersonData), new PropertyMetadata(null));

		private PersonDataModel _model;
		public PersonDataModel Data
		{
			get
			{
				return _model;
			}
			set
			{
				_model = value;
				if (PhotoData == null && !string.IsNullOrEmpty(Data.PhotoFileName))
				{
					Dispatcher.RunAsync(Windows.UI.Core.CoreDispatcherPriority.Normal, async () =>
					{
						photoImg.Source = await new FilesHelper().GetPhoto(KnownFolders.PicturesLibrary, "Photo", Data.PhotoFileName);
					});
				}
			}
		}

		public PersonData()
		{
			InitializeComponent();
		}
	}
}
