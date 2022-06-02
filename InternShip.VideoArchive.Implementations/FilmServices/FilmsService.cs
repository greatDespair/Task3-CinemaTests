using AutoMapper;
using InternShip.VideoArchive.Contracts.Abstractions;
using InternShip.VideoArchive.Contracts.Abstractions.FilmServices;
using InternShip.VideoArchive.Contracts.Models;
using InternShip.VideoArchive.Implementations.Helpers;

namespace InternShip.VideoArchive.Implementations.FilmServices
{
	/// <summary>
	/// Сервис, обрабатывающий коллекцию фильмов, полученных извне
	/// </summary>
	public class FilmsService : IFilmsService
	{
		#region Конструкторы и DI

		private readonly IMapper _mapper;
		private readonly ISortFilters _sortFilters;

		/// <summary>
		/// Конструктор
		/// </summary>
		public FilmsService(IMapper mapper, ISortFilters sortFilters)
		{
			_mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
			_sortFilters = sortFilters ?? throw new ArgumentNullException(nameof(sortFilters));
		}

		#endregion

		/// <summary>
		/// Получаем фильмы, отсортированные по флагам
		/// </summary>
		/// <param name="flags">Флаги для сортировки</param>
		/// <returns></returns>
		public List<Film>? GetSortedFilms(FilmSortFlags flags, List<Film>? films)
		{
			var filters = _sortFilters.GetFilters<Film>(flags);
			if((films == null))
				return null;
			var result = films.Where(
				f => filters.All(
					filter => filter(f))).ToList();

			return result;
		}

		/// <summary>
		/// Получаем список директоров по заданному списку фильмов,
		/// отсортированные по дате рождения
		/// </summary>
		/// <param name="films">Список фильмов</param>
		/// <returns></returns>
		public List<DirectorFullNameInfo> GetListOfDirectors(List<Film> films)
		{
			List<DirectorFullNameInfo> directors = _mapper.Map<List<DirectorFullNameInfo>>(films);

			var result = directors.OrderBy(d => d.DirectorBirthDate).ToList();

			return directors;
		}

		/// <summary>
		/// Возвращаем имя режиссера фильма с наибольшими тратами на съемки,
		/// премьера которого уже состоялась
		/// </summary>
		/// <param name="films"></param>
		/// <returns></returns>
		public string GetDirectorOfReleasedMostExpensiveFilm(List<Film>? films)
		{
			if(films == null)
				return string.Empty;
			var result = films
				.Where(
					f => f.ReleaseDate < DateTime.Now)
					.OrderBy(f => f.BoxOffice.GetUsdBoxOfficeCash())
					.Select(f => f.Director.GetDirectorFullNameWithAppeal());

			return result.First();
		}
	}
}