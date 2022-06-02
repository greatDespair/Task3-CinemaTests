using AutoFixture;
using AutoFixture.Dsl;
using AutoMapper;
using InternShip.VideoArchive.Contracts.Abstractions;
using InternShip.VideoArchive.Contracts.Abstractions.FilmCatalogServices;
using InternShip.VideoArchive.Contracts.Abstractions.Integrations;
using InternShip.VideoArchive.Contracts.Models;
using InternShip.VideoArchive.Contracts.Models.Cinema;
using InternShip.VideoArchive.Implementations.FilmServices;
using InternShip.VideoArchive.Tests.Builders;
using Moq;
using Xunit;

namespace InternShip.VideoArchive.Tests
{
	/// <summary>
	/// Тесты для <see cref="CinemaFilmsHandler">
	/// </summary>
	public class CinemaFilmsHandlerTests
	{
		private readonly Fixture _fixture = new Fixture();

		private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
		private readonly Mock<ISortFilters> _sortFiltersMock = new Mock<ISortFilters>();
		private readonly Mock<IFilmsCatalogHandler> _filmsCatalogHandlerMock = new Mock<IFilmsCatalogHandler>();
		private readonly Mock<IFakeInegrationService> _fakeInegrationService = new Mock<IFakeInegrationService>();

		private readonly IPostprocessComposer<CinemaFilmSortFlags> _cinemaFilmSortFlagsComposer;
		private readonly List<CinemaFilm> _cinemaFilms;
		private readonly List<Film> _films;
		private readonly List<Func<CinemaFilm, bool>> _filters;
		private readonly int _filmCount;
		private readonly CinemaFilmSortFlags _flags;

		private readonly CinemaFilmsHandler _cinemaFilmsHandler;

		public CinemaFilmsHandlerTests()
		{
			_cinemaFilms = _fixture.CreateMany<CinemaFilm>().ToList();
			_films = _fixture.CreateMany<Film>().ToList();
			_filters = _fixture.CreateMany<Func<CinemaFilm, bool>>().ToList();
			_filmCount = _films.Count;

			_mapperMock.Setup(
				mock => mock.Map<List<CinemaFilm>>(It.IsAny<List<Film>>())).Returns(_cinemaFilms);

			_cinemaFilmSortFlagsComposer = _fixture.Build<CinemaFilmSortFlags>();

			_sortFiltersMock.Setup(
				filters => filters.GetCinemaFilters(
					It.IsAny<CinemaFilmSortFlags>())).Returns(_filters);

			_filmsCatalogHandlerMock.Setup(
				handler => handler.GetFilms()).ReturnsAsync(_films);

			_cinemaFilmsHandler = new CinemaFilmsHandler(
				_sortFiltersMock.Object,
				_filmsCatalogHandlerMock.Object,
				new MapperProfileBuilder().GetMapper(),
				_fakeInegrationService.Object);
		}

		/// <summary>
		/// Проверяет что запрос на полученеи ограничений по фильму 
		/// был выполнен необходимое количество раз
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task GetCinemaFilms_GetAgeRestrictions_CalledRightTimes()
		{
			var flags = _cinemaFilmSortFlagsComposer.Create();

			await _cinemaFilmsHandler.GetCinemaFilms(flags);

			_fakeInegrationService.Verify(
				service => service.GetAgeRestrictions(
					It.IsAny<Film>()), Times.Exactly(_filmCount));
		}

		/// <summary>
		/// Проверяет что обработчик возвращает корректный результат
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task GetCinemaFilms_NotShowFilteredFilms_Correct()
		{
			var result = await _cinemaFilmsHandler.GetCinemaFilms(_flags);
			
			Assert.Equal(_filmCount, result.Count);
		}
	}
}