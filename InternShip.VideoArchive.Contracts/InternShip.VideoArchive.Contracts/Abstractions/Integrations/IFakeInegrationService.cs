namespace InternShip.VideoArchive.Contracts.Abstractions.Integrations
{
	/// <summary>
	/// Фейковая интеграция с внешними сервисами
	/// </summary>
	public interface IFakeInegrationService
	{
		/// <summary>
		/// Получаем возрастные ограничения по фильму
		/// </summary>
		public int GetAgeRestrictions(IFilm film);
	}
}