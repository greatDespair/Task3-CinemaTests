using AutoMapper;
using InternShip.VideoArchive.Contracts.Abstractions;
using InternShip.VideoArchive.Contracts.Models;
using InternShip.VideoArchive.Contracts.Models.Cinema;

namespace InternShip.VideoArchive.Implementations.Helpers
{
	/// <summary>
	/// Получение готовых фильтров
	/// </summary>
	public class SortFilters : ISortFilters
	{
		#region Конструкторы и DI

		private readonly IMapper _mapper;

		public SortFilters(IMapper mapper)
		{
			_mapper = mapper;
		}

		#endregion

		/// <summary>
		/// Получаем обычные фильтры
		/// </summary>
		public List<Func<T, bool>> GetFilters<T>(FilmSortFlags flags) where T : IFilm
		{
			var filters = new List<Func<T, bool>>();

			if (flags.FilmTypes != null && flags.FilmTypes.Any())
			{
				filters.Add(f => flags.FilmTypes.Contains(f.FilmType));
			}

			if (flags.FilmGenres != null && flags.FilmGenres.Any())
			{
				filters.Add(f => flags.FilmGenres.Contains(f.FilmGenre));
			}

			if (flags.ReleaseDateTo.HasValue)
			{
				filters.Add(f => f.ReleaseDate < flags.ReleaseDateTo);
			}

			if (flags.ReleaseDateFrom.HasValue)
			{
				filters.Add(f => f.ReleaseDate > flags.ReleaseDateFrom);
			}

			return filters;
		}

		/// <summary>
		/// Получаем фильтры для показа фильмов в кинотеатре
		/// </summary>
		public List<Func<CinemaFilm, bool>> GetCinemaFilters(CinemaFilmSortFlags flags)
		{
			var filters = new List<Func<CinemaFilm, bool>>();

			filters.AddRange(
				GetFilters<CinemaFilm>(
					_mapper.Map<FilmSortFlags>(flags)));

			if (!flags.AgeRestrictions.HasValue)
			{
				return filters; ;
			}

			filters.Add(f => f.AgeRestrictions < flags.AgeRestrictions.Value);

			return filters;
		}
	}
}