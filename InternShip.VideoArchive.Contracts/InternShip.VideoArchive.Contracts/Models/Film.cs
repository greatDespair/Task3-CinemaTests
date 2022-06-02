using InternShip.VideoArchive.Contracts.Abstractions;

namespace InternShip.VideoArchive.Contracts.Models
{
	/// <summary>
	/// Информация о фильме
	/// </summary>
	public class Film : IFilm
	{
		/// <summary>
		/// Идентификатор фильма в нашем каталоге
		/// </summary>
		public int Id { get; set; }

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
		/// Затраты на фильм
		/// </summary>
		public Cash FilmProductionPrice { get; set; }

		/// <summary>
		/// Дата выхода
		/// </summary>
		public DateTime ReleaseDate { get; set; }

		/// <summary>
		/// Информация о директоре
		/// </summary>
		public DirectorInfo Director { get; set; }
	}
}