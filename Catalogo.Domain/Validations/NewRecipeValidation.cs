using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Validations
{
    class NewRecipeValidation: RecipeValidation
    {
        public NewRecipeValidation()
        {
            ValidateBottleSize();
        }
    }
}
