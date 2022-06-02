namespace InternShip.VideoArchive.Contracts.Models
{
	/// <summary>
	/// Информция о режиссере
	/// </summary>
	public class DirectorInfo
	{
		/// <summary>
		/// Имя режиссера
		/// </summary>
		public string FirstName { get; set; }

		/// <summary>
		/// Фамилия режиссера
		/// </summary>
		public string Surname { get; set; }

		/// <summary>
		/// Пол
		/// </summary>
		public Gender Gener { get; set; }

		/// <summary>
		/// Дата рождения
		/// </summary>
		public DateTime BirthDate { get; set; }
	}
}