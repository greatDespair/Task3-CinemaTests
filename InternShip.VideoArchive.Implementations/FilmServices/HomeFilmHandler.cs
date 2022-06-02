using AutoMapper;
using InternShip.VideoArchive.Contracts.Abstractions.Data;
using InternShip.VideoArchive.Contracts.Abstractions.FilmServices;
using InternShip.VideoArchive.Contracts.Abstractions.Integrations;
using InternShip.VideoArchive.Contracts.Models;
using InternShip.VideoArchive.Contracts.Models.Home;

namespace InternShip.VideoArchive.Implementations.FilmServices
{
	/// <summary>
	/// Обработчик фильмов для просмотра дома
	/// Предположим, что эти фильмы у нас хранятся в локальной БД
	/// </summary>
	public class HomeFilmHandler : IHomeFilmHandler
	{
		#region Конструкторы и DI

		private readonly IFakeDatabaseService _fakeDatabaseService;
		private readonly IFakeInegrationService _fakeInegrationService;
		private readonly IMapper _mapper;

		public HomeFilmHandler(
			IFakeDatabaseService fakeDatabaseService,
			IFakeInegrationService fakeInegrationService,
			IMapper mapper)
		{
			_fakeDatabaseService = fakeDatabaseService;
			_fakeInegrationService = fakeInegrationService;
			_mapper = mapper;
		}

		#endregion

		/*-------Требуется дописать тесты-------*/

		/// <summary>
		/// Выбираем фильм для просмотра с детьми
		/// </summary>
		/// <returns></returns>
		public async Task<HomeFilm?> ChooseFilmToWatchWithChilds()
		{
			var allFilms = await _fakeDatabaseService.GetAllFilms();

			var filmToWatch = allFilms
				.Where(film => film.IsFavorite)
				.OrderByDescending(film => film.TimesWatched);

			foreach (var film in filmToWatch)
			{
				if (_fakeInegrationService.GetAgeRestrictions(_mapper.Map<Film>(film)) <= 6)
				{
					return film;
				}

				continue;
			}

			return null;
		}

        /// <summary>
        /// Помечаем любимые фильмы
        /// </summary>
        /// <exception cref="FileNotFoundException"></exception>
        public async Task IndicateFavouritesOfOurFilms()
        {
			var allFilms = await _fakeDatabaseService.GetAllFilms();

			if (allFilms.Any() || allFilms == null)
			{
				throw new NullReferenceException();
			}

			IndicateFilms(allFilms);
		}

		private async void IndicateFilms(List<HomeFilm> films)
		{
			foreach (var film in films)
			{
				if (film.TimesWatched >= 5)
				{
					film.IsFavorite = true;
					await _fakeDatabaseService.UpdateFilm(film, film.Id);
					continue;
				}

				film.IsFavorite = false;

				await _fakeDatabaseService.UpdateFilm(film, film.Id);
			}
		}
	}
}