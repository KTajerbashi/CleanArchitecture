using Application.Library.Interfaces.SEC.Person.DTOs;
using AutoMapper;
using Domain.Library.Entities.SEC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistance.Library.MapperProfile
{
    public interface IAutoMapperConfiguration
    {
    }
    public class AutoMapperConfiguration : Profile, IAutoMapperConfiguration
    {
        public static Mapper InitializeAutomapper()
        {
            //Provide all the Mapping Configuration
            var config = new MapperConfiguration(cfg =>
            {
                //Configuring Employee and EmployeeDTO
                cfg.CreateMap<Person, PersonDTO>().ReverseMap();
                //Any Other Mapping Configuration ....
            });
            //Create an Instance of Mapper and return that Instance
            var mapper = new Mapper(config);
            return mapper;
        }

    }
}
