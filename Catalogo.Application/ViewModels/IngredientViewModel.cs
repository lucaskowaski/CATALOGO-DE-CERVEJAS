using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Application.ViewModels
{
    public class IngredientViewModel: ViewModel
    {
        public IEnumerable<BeerIngredientViewModel> BeerIngredient { get; set; }
        public string Description { get; set; }
    }
}