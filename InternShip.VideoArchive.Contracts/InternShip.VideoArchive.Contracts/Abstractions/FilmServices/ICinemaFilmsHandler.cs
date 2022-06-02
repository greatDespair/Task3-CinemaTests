using InternShip.VideoArchive.Contracts.Models.Cinema;

namespace InternShip.VideoArchive.Contracts.Abstractions.FilmServices
{
	/// <summary>
	/// Обработчик запросов по фильмам для кинотеатра
	/// </summary>
	public interface ICinemaFilmsHandler
	{
		/// <summary>
		/// Предположим, что для кинотеатров берем только фильмы из нашего внутреннего каталога
		/// Получаем фильмы, удовлетворяющие нашим условиям
		/// </summary>
		public Task<List<CinemaFilm>> GetCinemaFilms(CinemaFilmSortFlags flags);
	}
}