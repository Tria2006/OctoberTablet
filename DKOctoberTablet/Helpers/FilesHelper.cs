using DKOctoberTablet.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;

namespace DKOctoberTablet.Helpers
{
	public class FilesHelper
	{
		internal async Task<List<DirectoryData>> GetDirectoryData(StorageFolder localFolder, string rootFolderName)
		{
			var result = new List<DirectoryData>();
			var pdfHelper = new PdfHelper();

			if (!(await localFolder.TryGetItemAsync(rootFolderName) is StorageFolder rootFolder)) return result;
			var dirs = await rootFolder.GetFoldersAsync();

			foreach (var dir in dirs)
			{
				var files = await dir.GetFilesAsync();
				var dirData = new DirectoryData
				{
					DirectoryName = dir.DisplayName,
					Files = new List<BitmapImage>()
				};

				try
				{
					foreach (var file in files)
					{
						var props = await file.GetBasicPropertiesAsync();
						if (props.Size == 0) return result;

						switch (file.FileType.ToLower())
						{
							case ".jpg":
							case ".jpeg":
							case ".png":
								using (var randomAccessStream = await file.OpenAsync(FileAccessMode.Read))
								{
									var img = new BitmapImage();
									if (randomAccessStream.CanRead)
									{
										await img.SetSourceAsync(randomAccessStream);
										dirData.Files.Add(img);
									}
								}
								break;
							case ".pdf":
								var doc = await PdfDocument.LoadFromFileAsync(file);
								dirData.Files.AddRange(await pdfHelper.LoadPdf(doc));
								break;
							case ".doc":
							//case ".docx":
							//	await pdfHelper.ConvertToPdf(file.Path, dir);
							//	var pdf = await GetStorageFileByName($"{file.Name}.pdf", dir);
							//	var pdfDoc = await PdfDocument.LoadFromFileAsync(pdf);
							//	dirData.Files.AddRange(await pdfHelper.LoadPdf(pdfDoc));
							break;
						}
					}
					result.Add(dirData);
				}
				catch (Exception e)
				{
				}
			}
			return result;
		}

		private async Task<IStorageFile> GetStorageFileByName(string name, StorageFolder folder)
		{
			return await folder.GetFileAsync(name);
		}
	}
}
