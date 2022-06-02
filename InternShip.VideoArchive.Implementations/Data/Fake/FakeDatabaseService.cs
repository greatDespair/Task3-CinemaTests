using AutoFixture;
using InternShip.VideoArchive.Contracts.Abstractions.Data;
using InternShip.VideoArchive.Contracts.Models.Home;

namespace InternShip.VideoArchive.Implementations.Data.Fake
{
	/// <summary>
	/// Фейковый сервис имитирующий работу с БД
	/// </summary>
	public class FakeDatabaseService : IFakeDatabaseService
	{
		private readonly Fixture Fixture = new Fixture();

		/// <summary>
		/// Получаем все фильмы издомашней коллекции
		/// </summary>
		public async Task<List<HomeFilm>> GetAllFilms()
		{
			// Логика асинхронной выборки всех записей из БД
			return Fixture.CreateMany<HomeFilm>().ToList();
		}

		/// <summary>
		/// Обновить информацию о фильме
		/// </summary>
		public async Task<HomeFilm> GetFilmById(int id)
		{
			// Логика асинхронной выборки записи из БД
			return Fixture.Build<HomeFilm>().With(film => film.Id, id).Create();
		}

		/// <summary>
		/// Получаем фильм по его Id
		/// </summary>
		public async Task UpdateFilm(HomeFilm film, int id)
		{
			// Логика обновления фильма в БД
		}
	}
}