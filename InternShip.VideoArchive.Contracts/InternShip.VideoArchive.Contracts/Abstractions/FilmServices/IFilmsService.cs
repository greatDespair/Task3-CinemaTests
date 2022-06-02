using InternShip.VideoArchive.Contracts.Models;

namespace InternShip.VideoArchive.Contracts.Abstractions.FilmServices
{
	/// <summary>
	/// Сервис, обрабатывающий коллекцию фильмов
	/// </summary>
	public interface IFilmsService
	{
		/// <summary>
		/// Получаем фильмы, отсортированные по флагам
		/// </summary>
		public List<Film>? GetSortedFilms(FilmSortFlags flags, List<Film> films);

		/// <summary>
		/// Получаем список директоров по заданному списку фильмов,
		/// отсортированные по дате рождения
		/// </summary>
		public List<DirectorFullNameInfo> GetListOfDirectors(List<Film> films);


		/// <summary>
		/// Возвращаем имя режиссера фильма с наибольшими тратами на съемки,
		/// премьера которого уже состоялась
		/// </summary>
		public string GetDirectorOfReleasedMostExpensiveFilm(List<Film> films);
	}
}