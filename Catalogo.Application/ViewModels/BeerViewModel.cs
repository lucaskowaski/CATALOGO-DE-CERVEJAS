using System;
using System.Collections.Generic;
using System.Text;

namespace Catalogo.Application.ViewModels
{
    public class BeerViewModel: ViewModel
    {
        public string Name { get; set; }
        public string Brand { get; set; }
        public IEnumerable<BeerIngredientViewModel> BeerIngredient { get; set; }
        public string Family { get; set; }
        public string Style { get; set; }
        public double ABV { get; set; }
        public int IBU { get; set; }
    }
}
