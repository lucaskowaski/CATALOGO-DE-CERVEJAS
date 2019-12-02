using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Application.ViewModels
{
    public class BeerIngredientViewModel
    {
        public int BeerId { get; set; }
        public BeerViewModel Beer { get; set; }
        public int IngredientId { get; set; }
        public IngredientViewModel Ingredient { get; set; }
    }
}
