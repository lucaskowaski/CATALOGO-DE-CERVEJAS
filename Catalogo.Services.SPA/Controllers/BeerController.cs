using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogo.Application.Interfaces;
using Catalogo.Application.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Services.SPA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class BeerController : ControllerBase
    {
        private readonly IBeerApplication _beerApplication;
        public BeerController(IBeerApplication beerApplication)
        {
            _beerApplication = beerApplication;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_beerApplication.GetAll());
        }

        [HttpGet, Route("GetIncludeIngredient")]
        public IActionResult GetIncludeIngredient(int id)
        {
            var beer = _beerApplication.GetIncludeIngredients(id);
            return Ok(beer);
        }
        [HttpGet]
        [Route("Search")]
        public IActionResult Search(string name)
        {
            return Ok(_beerApplication.SearchByName(name));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_beerApplication.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]BeerViewModel beer)
        {
            _beerApplication.Add(beer);
            return Ok(beer);
        }

        [HttpPut]
        public IActionResult Put([FromBody]BeerViewModel beer)
        {
            _beerApplication.Update(beer);
            return Ok(beer);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _beerApplication.Remove(id);
            return Ok(true);
        }

    }
}