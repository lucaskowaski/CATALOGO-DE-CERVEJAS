using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Validations
{
    public class NewIngredientValidation: IngredientValidation
    {
        public NewIngredientValidation()
        {
            ValidateDescription();
        }
    }
}
