using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Validations
{
    public class UpdateRecipeValidation : RecipeValidation
    {
        public UpdateRecipeValidation()
        {
            ValidateId();
            ValidateBottleSize();
        }
    }
}
