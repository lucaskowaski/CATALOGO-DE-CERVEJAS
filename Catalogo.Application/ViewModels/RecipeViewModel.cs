using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Application.ViewModels
{
    public class RecipeViewModel: ViewModel
    {
        public int BeerId { get; set; }
        public BeerViewModel Beer { get; set; }
        public double BottleSize { get; set; }
        public IEnumerable<RecipeIngredientViewModel> RecipeIngredients { get; set; }
    }
}
