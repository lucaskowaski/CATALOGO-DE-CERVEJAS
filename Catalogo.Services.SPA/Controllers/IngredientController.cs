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
    public class IngredientController : ControllerBase
    {
        private readonly IIngredientApplication _ingredientApplication;
        public IngredientController(IIngredientApplication ingredientApplication)
        {
            _ingredientApplication = ingredientApplication;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_ingredientApplication.GetAll());
        }
        [HttpGet]
        [Route("GetByBeer")]
        public IActionResult GetByBeer(int IdBeer)
        {
            return Ok(_ingredientApplication.GetAll());
        }

        [HttpGet]
        [Route("Search")]
        public IActionResult Search(string description)
        {
            return Ok(_ingredientApplication.SearchByDescription(description));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_ingredientApplication.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]IngredientViewModel ingredient)
        {
            _ingredientApplication.Add(ingredient);
            return Ok(ingredient);
        }

        [HttpPut]
        public IActionResult Put([FromBody]IngredientViewModel ingredient)
        {
            _ingredientApplication.Update(ingredient);
            return Ok(ingredient);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _ingredientApplication.Remove(id);
            return Ok(id);
        }
    }
}