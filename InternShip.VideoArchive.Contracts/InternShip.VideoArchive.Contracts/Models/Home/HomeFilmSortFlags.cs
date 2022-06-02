namespace InternShip.VideoArchive.Contracts.Models.Home
{
	/// <summary>
	/// Флаги для сортировок фильмов для просмотра из дома
	/// </summary>
	public class HomeFilmSortFlags : FilmSortFlags
	{
		/// <summary>
		/// Один из наших любимых фильмов
		/// </summary>
		public bool IsFavorite { get; set; }
	}
}