using Catalogo.Application.ViewModels;
using Catalogo.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Catalogo.Application.Interfaces
{
    public interface IBeerApplication : IApplicationBase<BeerViewModel, Beer>
    {
        IEnumerable<BeerViewModel> SearchByName(string name);
        public Beer GetIncludeIngredients(int id);
    }
}
