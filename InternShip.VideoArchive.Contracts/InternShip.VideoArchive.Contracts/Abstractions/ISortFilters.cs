using InternShip.VideoArchive.Contracts.Models;
using InternShip.VideoArchive.Contracts.Models.Cinema;

namespace InternShip.VideoArchive.Contracts.Abstractions
{
	/// <summary>
	/// Получение готовых фильтров для сортировки
	/// </summary>
	public interface ISortFilters
	{
		/// <summary>
		/// Получаем обычные фильтры
		/// </summary>
		public List<Func<T, bool>> GetFilters<T>(FilmSortFlags flags) where T : IFilm;

		/// <summary>
		/// Получаем фильтры для показа фильмов в кинотеатре
		/// </summary>
		public List<Func<CinemaFilm, bool>> GetCinemaFilters(CinemaFilmSortFlags flags);
	}
}