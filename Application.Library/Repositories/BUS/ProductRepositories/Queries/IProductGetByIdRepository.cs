﻿using Application.Library.BaseModel.BaseDTO;
using Application.Library.Repositories.BUS.ProductRepositories.Models.Views;

namespace Application.Library.Repositories.BUS.ProductRepositories.Queries
{
    public interface IProductGetByIdRepository
    {
        Result<ProductView> Execute(Guid guid);
    }

}
