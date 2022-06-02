using InternShip.VideoArchive.Contracts.Abstractions.FilmCatalogServices;
using InternShip.VideoArchive.Contracts.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System.Globalization;
using System.Reflection;

namespace InternShip.VideoArchive.Implementations.FilmCatalogServices
{
	/// <summary>
	/// Обработчик запроса на получение всех фильмов из каталога
	/// </summary>
	public class FilmsCatalogHandler : IFilmsCatalogHandler
	{
		private const string JsonFileName = "FilmCatalog.json";

		/// <summary>
		/// Метод получения массива фильмов из каталога
		/// </summary>
		public async Task<List<Film>?> GetFilms()
		{
			var jsonFilePath = GetFilePackagePath();
			var format = "dd.mm.yyyy";
			try
			{
				var result = JsonConvert.DeserializeObject<FilmCatalog>((await File.ReadAllTextAsync(jsonFilePath)),
					new JsonSerializerSettings
					{
						DateFormatString = format,
						NullValueHandling = NullValueHandling.Ignore
				});

				DateTime dateCheck;
				foreach (var filmDate in result.VideoOptions.Select(date => date.ReleaseDate))
                {
					if(DateTime.TryParseExact(filmDate.ToString(), format, DateTimeFormatInfo.InvariantInfo,
						DateTimeStyles.None, out dateCheck))
					{
						throw new JsonSerializationException("Input date error.");
                    }
                }
				return result?.VideoOptions;
			}
			catch (Exception ex)
            {
				throw new JsonSerializationException("Input film type error." + ex);
            }

			
		}

		private string GetFilePackagePath()
		{
			string codeBase = Assembly.GetExecutingAssembly().CodeBase;
			UriBuilder uri = new UriBuilder(codeBase);
			string path = Uri.UnescapeDataString(uri.Path);
			var directory = Path.GetDirectoryName(path);
			return Path.Combine(directory, JsonFileName);
		}
	}
}