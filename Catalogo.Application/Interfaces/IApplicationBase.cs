using Catalogo.Domain.Models;
using System.Collections.Generic;

namespace Catalogo.Application.Interfaces
{
    public interface IApplicationBase<TViewModel, TModel> where TModel : Entity
    {
        void Add(TViewModel entity);
        TViewModel Get(int id);
        IEnumerable<TViewModel> GetAll();
        void Update(TViewModel entity);
        void Remove(int id);
    }
}
