using DKOctoberTablet.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Windows.Data.Pdf;
using Windows.Storage;
using Windows.UI.Xaml.Media.Imaging;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;

namespace DKOctoberTablet.Helpers
{
	public class FilesHelper
	{
		internal async Task<List<DirectoryData>> GetDirectoryData(StorageFolder localFolder, string rootFolderName)
		{
			var result = new List<DirectoryData>();
			var pdfHelper = new PdfHelper();

			var dirs = await GetFolders(localFolder, rootFolderName);
			if (dirs == null) return result;

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

		private async Task<IReadOnlyList<StorageFolder>> GetFolders(StorageFolder localFolder, string root)
		{
			if (!(await localFolder.TryGetItemAsync("Terminal") is StorageFolder terminalFolder)) return null;
			if (!(await terminalFolder.TryGetItemAsync(root) is StorageFolder rootFolder)) return null;
			return await rootFolder.GetFoldersAsync();
		}

		internal async Task<BitmapImage> GetPhoto(StorageFolder localFolder, string rootFolderName, string fileName)
		{
			var dirs = await GetFolders(localFolder, rootFolderName);
			if (dirs == null) return null;

			foreach (var dir in dirs)
			{
				var files = await dir.GetFilesAsync();
				if (files == null || files.Count == 0) continue;

				var photoFile = files.FirstOrDefault(x => x.Name == fileName);
				if (photoFile == null) continue;

				using (var randomAccessStream = await photoFile.OpenAsync(FileAccessMode.Read))
				{
					var img = new BitmapImage();
					if (randomAccessStream.CanRead)
					{
						await img.SetSourceAsync(randomAccessStream);
						return img;
					}
				}
			}

			return null;
		}

		internal async Task<PersonDataModel> GetDirectorData()
		{
			var result = new PersonDataModel();
			var folder = KnownFolders.PicturesLibrary;
			if (!(await folder.TryGetItemAsync("Terminal") is StorageFolder terminalFolder)) return result;

			var dirFile = await terminalFolder.GetFileAsync("director.json");

			if (dirFile == null) return result;

			var json = await FileIO.ReadTextAsync(dirFile);

			return JsonConvert.DeserializeObject<PersonDataModel>(json);
		}

		internal async Task<CoDirectors> GetCoDirectorsData()
		{
			var result = new CoDirectors();
			var folder = KnownFolders.PicturesLibrary;
			if (!(await folder.TryGetItemAsync("Terminal") is StorageFolder terminalFolder)) return result;

			var dirFile = await terminalFolder.GetFileAsync("codirectors.json");

			if (dirFile == null) return result;

			var json = await FileIO.ReadTextAsync(dirFile);

			return JsonConvert.DeserializeObject<CoDirectors>(json);
		}

		internal async Task<CoDirectors> GetAdmPpData()
		{
			var result = new CoDirectors();
			var folder = KnownFolders.PicturesLibrary;
			if (!(await folder.TryGetItemAsync("Terminal") is StorageFolder terminalFolder)) return result;

			var dirFile = await terminalFolder.GetFileAsync("adm_pp.json");

			if (dirFile == null) return result;

			var json = await FileIO.ReadTextAsync(dirFile);

			return JsonConvert.DeserializeObject<CoDirectors>(json);
		}

		internal async Task<SectorsEmployees> GetSectorsEmployeesData()
		{
			var result = new SectorsEmployees();
			var folder = KnownFolders.PicturesLibrary;
			if (!(await folder.TryGetItemAsync("Terminal") is StorageFolder terminalFolder)) return result;

			var dirFile = await terminalFolder.GetFileAsync("sectors.json");

			if (dirFile == null) return result;

			var json = await FileIO.ReadTextAsync(dirFile);

			return JsonConvert.DeserializeObject<SectorsEmployees>(json);
		}

		internal async Task<ButtonsList> GetButtons(string fileName)
		{
			var result = new ButtonsList();
			var folder = KnownFolders.PicturesLibrary;
			if (!(await folder.TryGetItemAsync("Terminal") is StorageFolder terminalFolder)) return result;

			var dirFile = await terminalFolder.GetFileAsync(fileName);

			if (dirFile == null) return result;

			var json = await FileIO.ReadTextAsync(dirFile);

			return JsonConvert.DeserializeObject<ButtonsList>(json);
		}

		internal async Task<List<ScheduleItem>> GetFullSchedule()
		{
			var result = new List<ScheduleItem>();
			var folder = KnownFolders.PicturesLibrary;
			if (!(await folder.TryGetItemAsync("Terminal") is StorageFolder terminalFolder)) return result;

			var dirFile = await terminalFolder.GetFileAsync("schedule.json");

			if (dirFile == null) return result;

			var json = await FileIO.ReadTextAsync(dirFile);

			var obj = JsonConvert.DeserializeObject<JObject>(json);

			if (!obj.TryGetValue("items", out var items))
				return result;

			return JsonConvert.DeserializeObject<List<ScheduleItem>>(items.ToString());
		}
	}
}
