using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Validations
{
    public class NewBeerValidation: BeerValidation
    {
        public NewBeerValidation()
        {
            ValidateName();
            ValidateBrand();
            ValidateFamily();
            ValidateStyle();
            ValidateABV();
            ValidateIBU();
        }
    }
}
