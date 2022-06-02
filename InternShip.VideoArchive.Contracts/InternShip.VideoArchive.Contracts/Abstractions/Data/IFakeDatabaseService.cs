using InternShip.VideoArchive.Contracts.Models.Home;

namespace InternShip.VideoArchive.Contracts.Abstractions.Data
{
	/// <summary>
	/// Фейковый сервис имитирующий работу с БД
	/// </summary>
	public interface IFakeDatabaseService
	{
		/// <summary>
		/// Обновить информацию о фильме
		/// </summary>
		public Task UpdateFilm(HomeFilm film, int id);

		/// <summary>
		/// Получаем фильм по его Id
		/// </summary>
		public Task<HomeFilm> GetFilmById(int id);

		/// <summary>
		/// Получаем все фильмы издомашней коллекции
		/// </summary>
		public Task<List<HomeFilm>> GetAllFilms();
	}
}