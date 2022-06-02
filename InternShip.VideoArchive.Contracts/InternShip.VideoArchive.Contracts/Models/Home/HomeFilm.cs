namespace InternShip.VideoArchive.Contracts.Models.Home
{
	/// <summary>
	/// Модель фильмов для просмотра дома
	/// </summary>
	public class HomeFilm : Film
	{
		/// <summary>
		/// Один из наших любимых фильмов
		/// </summary>
		public bool IsFavorite { get; set; }

		/// <summary>
		/// Сколько раз смотрели фильм
		/// </summary>
		public int TimesWatched { get; set; }
	}
}