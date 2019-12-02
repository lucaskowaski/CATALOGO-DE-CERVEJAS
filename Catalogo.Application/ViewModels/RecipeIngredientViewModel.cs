using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Application.ViewModels
{
    public class RecipeIngredientViewModel
    {
        public int IngredientId { get; set; }
        public IngredientViewModel Ingredient { get; set; }
        public int RecipeId { get; set; }
        public RecipeViewModel Recipe { get; set; }
        public double Quantity { get; set; }
    }
}
