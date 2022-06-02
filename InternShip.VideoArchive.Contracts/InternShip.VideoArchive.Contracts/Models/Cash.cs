namespace InternShip.VideoArchive.Contracts.Models
{
	/// <summary>
	/// Деньги
	/// </summary>
	public class Cash
	{
		/// <summary>
		/// Сумма
		/// </summary>
		public short Sum { get; set; }

		/// <summary>
		/// Валюта
		/// </summary>
		public Currency Currency { get; set; }
	}
}
