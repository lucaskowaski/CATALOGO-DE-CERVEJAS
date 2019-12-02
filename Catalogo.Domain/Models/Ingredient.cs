using Catalogo.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Models
{
    public class Ingredient : Entity
    {
        public Ingredient(string description)
        {
            Description = description;
        }
        public Ingredient() { }

        public string Description { get; set; }
        public IEnumerable<BeerIngredient> BeerIngredient { get; set; }

        public override void ValidateAndThrowToAdd()
        {
            ValidateAndThrow<NewIngredientValidation, Ingredient>(this);
        }

        public override void ValidateAndThrowToUpdate()
        {
            ValidateAndThrow<UpdateIngredientValidation, Ingredient>(this);
        }
    }
}
