using Catalogo.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Models
{
    public class Recipe : Entity
    {
        public Recipe() { }
        public int BeerId { get; set; }
        public Beer Beer { get; set; }
        public double BottleSize { get; set; }
        public IEnumerable<RecipeIngredient> RecipeIngredients { get; set; }
        public override void ValidateAndThrowToAdd()
        {
            ValidateAndThrow<NewRecipeValidation, Recipe>(this);
        }
        public override void ValidateAndThrowToUpdate()
        {
            ValidateAndThrow<UpdateRecipeValidation, Recipe>(this);
        }
    }
}
