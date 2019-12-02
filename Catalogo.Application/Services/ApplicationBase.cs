using AutoMapper;
using Catalogo.Application.Interfaces;
using Catalogo.Domain.Interfaces.Services;
using Catalogo.Domain.Models;
using System.Collections.Generic;
using AutoMapper.QueryableExtensions;
using System.Linq;

namespace Catalogo.Application.Services
{
    public class ApplicationBase<TViewModel, TModel> : IApplicationBase<TViewModel, TModel> where TModel : Entity
    {
        protected readonly IServiceBase<TModel> _serviceBase;
        protected readonly IMapper _mapper;
        public ApplicationBase(IServiceBase<TModel> serviceBase, IMapper mapper)
        {
            _serviceBase = serviceBase;
            _mapper = mapper;
        }
        public void Add(TViewModel entity)
        {
            _serviceBase.Add(_mapper.Map<TModel>(entity));
        }
        public virtual void Update(TViewModel entity)
        {
            _serviceBase.Update(_mapper.Map<TModel>(entity));
        }
        public void Remove(int id)
        {
            _serviceBase.Remove(id);
        }
        public TViewModel Get(int id)
        {
            return _mapper.Map<TViewModel>(_serviceBase.Get(id));
        }
        public IEnumerable<TViewModel> GetAll()
        {
            return _serviceBase.GetAll()
                .ProjectTo<TViewModel>(_mapper.ConfigurationProvider);
        }
    }
}
