using InternShip.VideoArchive.Contracts.Models;

namespace InternShip.VideoArchive.Contracts.Abstractions
{
	/// <summary>
	/// Модель фильма
	/// </summary>
	public interface IFilm
	{
		/// <summary>
		/// Название фильма/сериала
		/// </summary>
		public string FilmName { get; set; }

		/// <summary>
		/// Жанр фильма
		/// </summary>
		public string FilmGenre { get; set; }

		/// <summary>
		/// Количество серий
		/// </summary>
		public int NumberOfSeries { get; set; }

		/// <summary>
		/// Тип фильма (кино, сериал)
		/// </summary>
		public FilmTypes FilmType { get; set; }

		/// <summary>
		/// Кассовые сборы
		/// </summary>
		public Cash BoxOffice { get; set; }

		/// <summary>
		/// Дата выхода
		/// </summary>
		public DateTime ReleaseDate { get; set; }
	}
}