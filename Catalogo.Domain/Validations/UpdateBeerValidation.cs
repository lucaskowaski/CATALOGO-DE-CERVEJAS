using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Validations
{
    public class UpdateBeerValidation: BeerValidation
    {
        public UpdateBeerValidation()
        {
            ValidateId();
            ValidateName();
            ValidateBrand();
            ValidateFamily();
            ValidateStyle();
            ValidateABV();
            ValidateIBU();
        }
    }
}
