namespace InternShip.VideoArchive.Contracts.Models.Cinema
{
	/// <summary>
	/// Фильм для показа в кинотеатре
	/// </summary>
	public class CinemaFilm : Film
	{
		/// <summary>
		/// Возрастные ограничения по фильму
		/// </summary>
		public int AgeRestrictions { get; set; }
		public CinemaFilm()
        {
			AgeRestrictions = 0;
        }
	}
}