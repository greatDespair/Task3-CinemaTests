using FluentValidation;
using InternShip.VideoArchive.Contracts.Models;

namespace InternShip.VideoArchive.Implementations.Validation
{
	/// <summary>
	/// Валидатор для модели Фильма
	/// </summary>
	public class FilmValidationProfile
		: AbstractValidator<Film>
	{
		public FilmValidationProfile()
		{
			RuleFor(film => film.FilmName).NotEmpty();

			When(film => film.FilmType == FilmTypes.Movie, () =>
			{
				RuleFor(film => film.NumberOfSeries).Must(num => num == 1);
			}).Otherwise(() =>
			{
				RuleFor(film => film.NumberOfSeries).GreaterThan(1);
			});

			When(film => film.ReleaseDate > DateTime.Now, () =>
			{
				RuleFor(film => film.BoxOffice).Must(bo => bo.Sum == 0);
			});
		}
	}
}