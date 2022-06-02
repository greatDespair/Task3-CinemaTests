using AutoFixture;
using AutoMapper;
using InternShip.VideoArchive.Implementations.FilmCatalogServices;
using Moq;
using Xunit;

namespace InternShip.VideoArchive.Tests
{
	/// <summary>
	/// Тесты для <see cref="FilmsCatalogHandler">
	/// </summary>
	public class FilmCatalogHandlerTests
	{
		private readonly Fixture _fixture = new Fixture();
		private readonly FilmsCatalogHandler _filmCatalogHandler;
		private readonly Mock<IMapper> _mapperMock = new Mock<IMapper>();

		public FilmCatalogHandlerTests()
		{
			_filmCatalogHandler = new FilmsCatalogHandler();
		}

		/// <summary>
		/// Проверяем, что из внутреннего каталога возвращается не null
		/// </summary>
		/// <returns></returns>
		[Fact]
		public async Task FilmCatalogHandlerReturn_NotNullResult()
		{
			var result = await _filmCatalogHandler.GetFilms();

			Assert.NotNull(result);
		}
	}
}