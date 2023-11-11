using Application.Library.Repositories.BUS.ProductRepositories.Models.DTOs;
using Application.Library.Repositories.BUS.ProductRepositories.Models.Views;
using Application.Library.Repositories.SEC.UserRepositories.Models.DTOs;
using Application.Library.Repositories.SEC.UserRepositories.Models.Views;
using AutoMapper;
using Domain.Library.Entities.BUS;
using Domain.Library.Entities.SEC;

namespace Infrastructure.Library.DatabaseContextApplication.ProfileMapper
{

    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {



            #region SEC
            CreateMap<User, UserDTO>();
            CreateMap<User, UserView>();
            #endregion


            #region RPT
            #endregion


            #region BUS
            CreateMap<Product, ProductDTO>();
            CreateMap<Product, ProductView>();

            #endregion


            #region CNT
            #endregion


            #region GEN
            #endregion


            #region LOG
            #endregion
        }

    }
}
