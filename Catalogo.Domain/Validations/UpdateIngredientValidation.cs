using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Validations
{
    public class UpdateIngredientValidation: IngredientValidation
    {
        public UpdateIngredientValidation()
        {
            ValidateId();
            ValidateDescription();
        }
    }
}
