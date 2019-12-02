using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Domain.Interfaces.Services
{
    public interface IBeerService : IServiceBase<Beer>
    {
        IQueryable<Beer> SearchByName(string name);
        public Beer GetIncludeIngredients(int id);
    }
}
