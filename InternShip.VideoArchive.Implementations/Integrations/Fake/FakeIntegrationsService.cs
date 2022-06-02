using InternShip.VideoArchive.Contracts.Abstractions;
using InternShip.VideoArchive.Contracts.Abstractions.Integrations;

namespace InternShip.VideoArchive.Implementations.Integrations
{
	/// <summary>
	/// Фейковая интеграция с внешними сервисами
	/// </summary>
	public class FakeIntegrationsService : IFakeInegrationService
	{
		private readonly Random _random;

		public FakeIntegrationsService()
		{
			_random = new Random();
		}

		/// <summary>
		/// Получаем возрастные ограничения по фильму
		/// </summary>
		public int GetAgeRestrictions(IFilm film)
		{
			/*
				Супер навороченная интеграция с очередями, запросами и пр с другими сервисами 
				для получения информации о фильме (в данном случае - возрастные ограничения)
			*/
			return _random.Next(21);
		}
	}
}