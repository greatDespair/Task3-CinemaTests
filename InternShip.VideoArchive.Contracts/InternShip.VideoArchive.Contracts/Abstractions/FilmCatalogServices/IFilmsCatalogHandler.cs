using InternShip.VideoArchive.Contracts.Models;

namespace InternShip.VideoArchive.Contracts.Abstractions.FilmCatalogServices
{
	/// <summary>
	/// Обработчик запроса на получение всех фильмов из каталога
	/// </summary>
	public interface IFilmsCatalogHandler
	{
		/// <summary>
		/// Метод получения массива фильмов из каталога
		/// </summary>
		public Task<List<Film>?> GetFilms();
	}
}
