namespace InternShip.VideoArchive.Contracts.Models
{
	/// <summary>
	/// Полное имя режиссера с датой рождения
	/// </summary>
	public class DirectorFullNameInfo
	{
		/// <summary>
		/// Полное имя режиссера
		/// </summary>
		public string FullName { get; set; }

		/// <summary>
		/// Дата рождения
		/// </summary>
		public DateTime DirectorBirthDate { get; set; }
	}
}