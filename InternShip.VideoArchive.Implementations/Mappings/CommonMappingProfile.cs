using AutoMapper;
using InternShip.VideoArchive.Contracts.Models;
using InternShip.VideoArchive.Contracts.Models.Cinema;
using InternShip.VideoArchive.Implementations.Helpers;

namespace InternShip.VideoArchive.Implementations.Mappings
{
	/// <summary>
	/// Профиль маппера для всей библиотеки
	/// </summary>
	public class CommonMappingProfile : Profile
	{
		/// <summary>
		/// Конструктор, в котором задаются настройки маппинга
		/// </summary>
		public CommonMappingProfile()
		{
			CreateMap<Film, DirectorFullNameInfo>(MemberList.Destination)
				.ForMember(dst => dst.FullName, opt => opt.MapFrom(src => src.Director.GetDirectorFullNameWithAppeal()));

			CreateMap<Film, CinemaFilm>(MemberList.Destination)
				.ForMember(dst =>dst.AgeRestrictions, opt => opt.MapFrom(src => 0));
		}
	}
}