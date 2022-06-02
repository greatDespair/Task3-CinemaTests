using InternShip.VideoArchive.Contracts.Models.Home;

namespace InternShip.VideoArchive.Contracts.Abstractions.FilmServices
{
	/// <summary>
	/// Обработчик фильмов для просмотра дома
	/// </summary>
	public interface IHomeFilmHandler
	{
		/// <summary>
		/// Подобрать фильм на вечер
		/// </summary>
		public Task<HomeFilm?> ChooseFilmToWatchWithChilds();

		/// <summary>
		/// Проставляем признак фаворита на фильмах, просмотренных более 5 раз
		/// </summary>
		public Task IndicateFavouritesOfOurFilms();
	}
}