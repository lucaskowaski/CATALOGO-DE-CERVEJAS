using Catalogo.Domain.Validations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Domain.Models
{
    public class Beer : Entity
    {
        public Beer(string name, string brand, IEnumerable<BeerIngredient> beerIngredient, string family, string style, double aBV, int iBU)
        {
            Name = name;
            Brand = brand;
            BeerIngredient = beerIngredient;
            Family = family;
            Style = style;
            ABV = aBV;
            IBU = iBU;
        }
        public Beer() { }
        public string Name { get; set; }
        public string Brand { get; set; }
        public IEnumerable<BeerIngredient> BeerIngredient { get; set; }
        public string Family { get; set; }
        public string Style { get; set; }
        public double ABV { get; set; }
        public int IBU { get; set; }
        public override void ValidateAndThrowToAdd()
        {
            ValidateAndThrow<NewBeerValidation, Beer>(this);
        }

        public override void ValidateAndThrowToUpdate()
        {
            ValidateAndThrow<UpdateBeerValidation, Beer>(this);
        }
    }
}
