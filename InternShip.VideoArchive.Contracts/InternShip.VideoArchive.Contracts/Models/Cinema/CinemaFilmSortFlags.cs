namespace InternShip.VideoArchive.Contracts.Models.Cinema
{
	/// <summary>
	/// Флаги для сортировки фильмов для показа в кинотеатре
	/// </summary>
	public class CinemaFilmSortFlags : FilmSortFlags
	{
		/// <summary>
		/// Возрастные ограничения по фильму
		/// </summary>
		public int? AgeRestrictions { get; set; }
	}
}
