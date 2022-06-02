using InternShip.VideoArchive.Contracts.Models;
using InternShip.VideoArchive.Implementations.Helpers;
using Xunit;

namespace InternShip.VideoArchive.Tests.Helpers
{
	/// <summary>
	/// Тесты для <see cref="CommonFilmExtensions">
	/// </summary>
	public class CommonFilmExtensionsTests
	{
		/// <summary>
		/// Если Film = null, получаем исключение
		/// </summary>
		[Fact]
		public void GetUsdBoxOfficeCash_WrongCurrency_GetException()
		{
			Film film = new Film();

			Assert.Throws<ArgumentNullException>(() => { film.BoxOffice.GetUsdBoxOfficeCash(); });
		}
	}
}
