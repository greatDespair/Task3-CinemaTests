using AutoMapper;
using InternShip.VideoArchive.Implementations.Mappings;

namespace InternShip.VideoArchive.Tests.Builders
{
	/// <summary>
	/// Инициализация маппера 
	/// </summary>
	public class MapperProfileBuilder
	{
		private IMapper _mapper;

		/// <summary>
		/// Конструктор с конфигурацией маппера
		/// </summary>
		public MapperProfileBuilder()
		{
			var config = new MapperConfiguration(cfg =>
			{
				cfg.AddProfile(new CommonMappingProfile());
			});

			_mapper = new Mapper(config);
			_mapper.ConfigurationProvider.AssertConfigurationIsValid();
		}

		/// <summary>
		/// Метод получения готового маппера
		/// </summary>
		/// <returns></returns>
		public IMapper GetMapper()
		{
			return _mapper;
		}
	}
}