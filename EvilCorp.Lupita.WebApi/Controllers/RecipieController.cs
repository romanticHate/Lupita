using AutoMapper;
using EvilCorp.Lupita.Core.Model;
using EvilCorp.Lupita.WebApi.Dtos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace EvilCorp.Lupita.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RecipieController : ControllerBase
    {
        // GET: api/<RecipieController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            // Create a source object
            var recipe = new Recipe
            {
                Id = 1,
                Name = "Spaghetti Bolognese",
                Description = "A classic Italian dish with meat sauce and pasta",
                Instructions = "Cook the pasta in boiling water. Brown the ground beef in a skillet. Add tomato sauce and seasonings. Simmer for 15 minutes. Serve the pasta topped with the sauce and cheese.",
                Cuisine = "Italian",
                Course = "Main",
                PrepTime = 10,
                CookTime = 25
            };

            // Create a mapping configuration
            var config = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Recipe, RecipeDTO>();
            });

            // Create an IMapper instance
            var mapper = config.CreateMapper();

            // Map the source object to the destination object
            var recipeDTO = mapper.Map<Recipe, RecipeDTO>(recipe);
            return null;
        }

        // GET api/<RecipieController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RecipieController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RecipieController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RecipieController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
