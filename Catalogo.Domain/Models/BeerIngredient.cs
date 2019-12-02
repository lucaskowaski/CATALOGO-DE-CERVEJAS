using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Models
{
    public class BeerIngredient
    {
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
        public int IngredientId { get; set; }
        public Ingredient Ingredient { get; set; }
    }
}
