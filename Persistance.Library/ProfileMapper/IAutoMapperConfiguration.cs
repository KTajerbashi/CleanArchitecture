using AutoMapper;

namespace Persistance.Library.ProfileMapper
{
    public interface IAutoMapperConfiguration
    {
    }
    public class AutoMapperConfiguration : Profile, IAutoMapperConfiguration
    {
        private readonly IAutoMapperConfiguration _mapper;
        public AutoMapperConfiguration(IAutoMapperConfiguration mapper)
        {
            _mapper = mapper;
        }

    }
}
