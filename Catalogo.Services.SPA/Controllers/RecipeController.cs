using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Catalogo.Application.Interfaces;
using Catalogo.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Catalogo.Services.SPA.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class RecipeController : ControllerBase
    {
        private readonly IRecipeApplication _recipeApplication;
        public RecipeController(IRecipeApplication recipeApplication)
        {
            _recipeApplication = recipeApplication;
        }
        [HttpGet]
        [Route("GetAll")]
        public IActionResult GetAll()
        {
            return Ok(_recipeApplication.GetAll());
        }
        [HttpGet]
        [Route("GetByBeer")]
        public IActionResult GetByBeer(int beerId)
        {
            return Ok(_recipeApplication.GetByBeer(beerId));
        }

        [HttpGet]
        public IActionResult Get(int id)
        {
            return Ok(_recipeApplication.Get(id));
        }

        [HttpPost]
        public IActionResult Post([FromBody]RecipeViewModel recioe)
        {
            _recipeApplication.Add(recioe);
            return Ok(recioe);
        }

        [HttpPut]
        public IActionResult Put([FromBody]RecipeViewModel recioe)
        {
            _recipeApplication.Update(recioe);
            return Ok(recioe);
        }

        [HttpDelete]
        public IActionResult Delete(int id)
        {
            _recipeApplication.Remove(id);
            return Ok(true);
        }
    }
}