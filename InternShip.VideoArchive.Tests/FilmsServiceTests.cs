using AutoFixture;
using AutoMapper;
using InternShip.VideoArchive.Contracts.Abstractions;
using InternShip.VideoArchive.Contracts.Models;
using InternShip.VideoArchive.Implementations.FilmServices;
using InternShip.VideoArchive.Implementations.Helpers;
using Moq;
using Xunit;

namespace InternShip.VideoArchive.Tests
{
	/// <summary>
	/// Тесты для <see cref="FilmsService">
	/// </summary>
	public class FilmsServiceTests
	{
		private readonly Fixture _fixture = new Fixture();
		private readonly FilmsService _filmService;
		private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();
		private readonly Mock<ISortFilters> _sortFilters = new Mock<ISortFilters>();
		private readonly List<Func<Film, bool>> _filters;
		private readonly List<Film> _films;

		public FilmsServiceTests()
		{
			_films = _fixture.CreateMany<Film>().ToList();

			_filters = _fixture.Create<List<Func<Film, bool>>>();

			_filmService = new FilmsService(_mapperMock.Object, _sortFilters.Object);
		}

		/// <summary>
		/// Проверяет, что метод GetFilters вызывается хотя бы один раз
		/// </summary>
		[Fact]
		public void GetSortedFilms_GetFiltersCalled()
		{
			var filmSortFlags = _fixture.Create<FilmSortFlags>();

			_filmService.GetSortedFilms(filmSortFlags, It.IsAny<List<Film>>());

			_sortFilters.Verify(
				filters =>
					filters.GetFilters<Film>(filmSortFlags),
					Times.Once);
		}

		/// <summary>
		/// Проверяем. что метод возвращает корректный результат
		/// </summary>
		[Fact]
		public void GetDirectorOfReleasedMostExpensiveFilm_ReturnsCorrectResult()
		{
			var result = _filmService.GetDirectorOfReleasedMostExpensiveFilm(It.IsAny<List<Film>>());

			Assert.NotNull(result);
		}

		/// <summary>
		/// Проверяет, что фильтры срабатывают корректно
		/// </summary>
		[Theory]
		[InlineData("01.01.2021", "01.01.2022", new string[] { "Комедия", "Триллер" }, new FilmTypes[] { FilmTypes.Serial, FilmTypes.Movie })]
		[InlineData("01.01.2020", "01.01.2021", new string[] { "Триллер" }, new FilmTypes[] { FilmTypes.Movie })]
		public void GetSortedFilms_ReturnsCorrectResult(DateTime dateFrom, DateTime dateTo, string[] genres, FilmTypes[] types)
		{
			Random rnd = new Random();

			DateTime correctRandomDate = dateFrom.AddDays(rnd.Next((dateTo - dateFrom).Days));

			var filmsAccordingFilters = _fixture
				.Build<Film>()
				.With(film => film.ReleaseDate, correctRandomDate)
				.With(film => film.FilmType, types[rnd.Next(types.Count())])
				.With(film => film.FilmGenre, genres[rnd.Next(genres.Count())])
				.CreateMany();

			var filmsNotAccordingFilters = _fixture
				.Build<Film>()
				.With(film => film.ReleaseDate, dateTo.AddDays(rnd.Next(100)))
				.Without(film => film.FilmGenre)
				.Without(film => film.FilmType)
				.CreateMany();

			var filmsAccordingFiltersCount = filmsAccordingFilters.Count();

			var filmsTotal = new List<Film>();
			filmsTotal.AddRange(filmsAccordingFilters);
			filmsTotal.AddRange(filmsNotAccordingFilters);

			var flags = new FilmSortFlags()
			{
				FilmGenres = genres,
				FilmTypes = types,
				ReleaseDateFrom = dateFrom,
				ReleaseDateTo = dateTo
			};

			_sortFilters
				.Setup(filters => filters.GetFilters<Film>(flags))
				.Returns(new SortFilters(_mapperMock.Object)
				.GetFilters<Film>(flags));

			var result = _filmService.GetSortedFilms(flags, filmsTotal);

			Assert.Equal(filmsAccordingFiltersCount, result.Count);
		}
	}
}