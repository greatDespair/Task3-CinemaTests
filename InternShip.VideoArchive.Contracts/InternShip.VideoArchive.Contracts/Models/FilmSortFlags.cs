namespace InternShip.VideoArchive.Contracts.Models
{
	/// <summary>
	/// Фильтры для сортировки фильмов
	/// </summary>
	public class FilmSortFlags
	{
		/// <summary>
		/// Дата релиза фильма с которой необходимо отсортировать 
		/// </summary>
		public DateTime? ReleaseDateFrom { get; set; }

		/// <summary>
		/// Дата релиза фильма до которой необходимо отсортировать 
		/// </summary>
		public DateTime? ReleaseDateTo { get; set; }

		/// <summary>
		/// Жанры фильмов
		/// </summary>
		public string[] FilmGenres { get; set; }

		/// <summary>
		/// Типы фильмов
		/// </summary>
		public FilmTypes[] FilmTypes { get; set; }
	}
}