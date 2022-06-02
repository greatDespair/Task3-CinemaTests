using AutoMapper;
using InternShip.VideoArchive.Contracts.Abstractions.Data;
using InternShip.VideoArchive.Contracts.Abstractions.FilmServices;
using InternShip.VideoArchive.Contracts.Abstractions.Integrations;
using InternShip.VideoArchive.Contracts.Models.Home;
using InternShip.VideoArchive.Implementations.FilmServices;
using Moq;
using Xunit;

namespace InternShip.VideoArchive.Tests
{
	/// <summary>
	/// Тесты для <see cref="HomeFilmHandler">
	/// </summary>
	public class HomeFilmHandlerTests
	{
		private readonly Mock<IFakeDatabaseService> _fakeDatabaseService = new Mock<IFakeDatabaseService>();
		private readonly Mock<IFakeInegrationService> _fakeIntegrationService = new Mock<IFakeInegrationService>();
		private readonly Mock<IHomeFilmHandler> _iHomeFilmHandler = new Mock<IHomeFilmHandler>();
		private readonly Mock<IMapper> _mapper = new Mock<IMapper>();

		private readonly HomeFilmHandler _homeFilmHandler;

		public HomeFilmHandlerTests()
		{
			_fakeDatabaseService
				.Setup(service => service
					.GetAllFilms())
				.ReturnsAsync(new List<HomeFilm>());

			_homeFilmHandler = new HomeFilmHandler(
				_fakeDatabaseService.Object,
				_fakeIntegrationService.Object,
				_mapper.Object);
		}

		/// <summary>
		/// Если из БД вернулся null, проверяем на исключение
		/// </summary>
		[Fact]
		public void NoFilmsInDatabase_ExceptionReturns()
		{
			Assert.ThrowsAsync<NullReferenceException>(async () => {await _homeFilmHandler.IndicateFavouritesOfOurFilms(); });
		}

		/// <summary>
		/// Проверяем корректность получения фильма по возрастному ограничению для детей
		/// </summary>
		[Fact]
		public async Task ChooseFilmToWatchWithChildsReturn_CorrectResult()
        {
			var result = await _homeFilmHandler.ChooseFilmToWatchWithChilds();

			Assert.True(_fakeIntegrationService.Object.GetAgeRestrictions(result) <= 6);
		}

		/// <summary>
		/// Проверяем установку пометок о любимых фильмах
		/// </summary>
		[Fact]
		public async Task IndicateFilms_IndicateFilmsCalls()
        {
			var prevResult = _fakeDatabaseService.Object.GetAllFilms();
			await _homeFilmHandler.IndicateFavouritesOfOurFilms();
			var newResult = _fakeDatabaseService.Object.GetAllFilms();
			
			Assert.NotEqual(prevResult, newResult);
		}

		/// <summary>
		/// Проверяем правильность пометок любимых фильмов
		/// </summary>
		[Fact]
		public async Task IndicateFilms_IndicateFilmsCorrectResult()
		{
			await _homeFilmHandler.IndicateFavouritesOfOurFilms();
			var result = _fakeDatabaseService.Object.GetAllFilms();

			int countWatched = 0;
			int countFavors = 0;
			foreach (var film in result.Result)
            {
				if(film.TimesWatched >= 5)
					countWatched++;
				if(film.IsFavorite == true)
					countFavors++;
            }

			Assert.Equal(countWatched, countFavors);
		}
	}
}