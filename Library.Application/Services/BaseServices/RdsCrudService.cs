using AutoMapper;
using Library.Domain.Entity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Application
{
    public class RdsCrudService<IEntity, TEnttiy> : IRdsCrudService<IEntity, IViewModel, IListViewModel>
        where IEntity : class
        where TEnttiy : class
    {
        IBaseService<IEntity,IViewModel,IListViewModel> BaseService;
        IMapper mapper;
        public RdsCrudService(IBaseService<IEntity, IViewModel, IListViewModel> baseService)
        {
            BaseService = baseService;
        }
        public async Task<bool> Delete(IViewModel entity)
        {
            IEntity iEntity = mapper.Map<IEntity>(entity);
            return BaseService.Delete(iEntity);
        }

        public async Task<bool> Delete(int id)
        {
            return BaseService.Delete(id);

        }

        public async Task<bool> Insert(IViewModel entity)
        {
            IEntity iEntity = mapper.Map<IEntity>(entity);
            return BaseService.Insert(iEntity);
        }

        public Task<IViewModel> Read(int id)
        {
            IEntity entity =BaseService.Read(id);
            return (Task<IViewModel>)mapper.Map<IViewModel>(entity);
        }

        public async Task<IEnumerable<IViewModel>> Read()
        {
            var customers = BaseService.Read();
            var items= mapper.Map<IEnumerable<IViewModel>>(customers);
            return items;
        }

        public async Task<bool> Update(IViewModel entity)
        {
            IEntity iEntity = mapper.Map<IEntity>(entity);
            return BaseService.Update(iEntity);
        }
    }
}
