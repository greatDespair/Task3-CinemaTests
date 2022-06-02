using InternShip.VideoArchive.Contracts.Models;

namespace InternShip.VideoArchive.Implementations.Helpers
{
	/// <summary>
	/// Методы расширения для <see cref="Film"/>
	/// </summary>
	public static class CommonFilmExtensions
	{
		/// <summary>
		/// Возвращает сумму кассовых сборов в USD
		/// </summary>
		public static decimal GetUsdBoxOfficeCash(this Cash cash)
		{
			if(cash == null)
            {
				throw new ArgumentNullException(nameof(cash));
            }
			switch (cash.Currency)
			{
				case Currency.USD: return Convert.ToDecimal(cash.Sum);
				case Currency.EURO: return Convert.ToDecimal(cash.Sum * 1.2);
				case Currency.RUB: return Convert.ToDecimal(cash.Sum / 75.5);
				default: return 0;
			}
		}

		/// <summary>
		/// Возвращает полное имя режиссера, с обращением
		/// </summary>
		/// <param name="film"></param>
		/// <returns></returns>
		public static string GetDirectorFullNameWithAppeal(this DirectorInfo director)
		{
			string appeal = director.Gener == Gender.Female ? "Mrs." : "Mr.";
			return $"{appeal} {director.FirstName} {director.Surname}";
		}

		/// <summary>
		/// Возвращает значение - выпущен ли фильм или нет
		/// </summary>
		/// <param name="film"></param>
		/// <returns></returns>
		public static bool IsRealeasedFilm(this Film film)
		{
			if (film.ReleaseDate <= DateTime.Now)
			{
				return true;
			}

			return false;
		}

		/// <summary>
		/// Возвращает полное имя режиссера
		/// </summary>
		/// <param name="film"></param>
		/// <returns></returns>
		public static string GetDirectorFullName(this Film film)
		{
			return $"{film.Director.FirstName} {film.Director.Surname}";
		}
	}
}