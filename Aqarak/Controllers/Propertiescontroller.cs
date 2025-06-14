using AqarakCore.Entities;
using AqarakCore.IRepository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Aqarak.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Propertiescontroller : ControllerBase
    {
        private readonly IGenericRepoitory<MyProperty> _propertyRepoitory;

        public Propertiescontroller(IGenericRepoitory<MyProperty> PropertyRepoitory)
        {
            _propertyRepoitory = PropertyRepoitory;
        }

       

        [HttpGet]
        public async Task< ActionResult<IEnumerable<MyProperty>>> GetAllProperties() { 

             var prop= await _propertyRepoitory.GetAllpropertyAsync();
           return  Ok(prop);


        }
        [HttpGet("{id}")]
        public async Task<ActionResult<MyProperty>> GetById(int id)
        {
            var prop = await _propertyRepoitory.GetpropertyAsync(id);
            if (prop == null)
            {
                return NotFound();
            }
            return Ok(prop);

        }
        [HttpGet("search")]
        public async Task<ActionResult<IEnumerable<MyProperty>>> SearchProperties([FromQuery] string query)
        {
            if (string.IsNullOrWhiteSpace(query))
                return BadRequest("Search query is required.");

            var results = await _propertyRepoitory.SearchAsync(query);

            if (!results.Any())
                return NotFound("No properties match your search.");

            return Ok(results);
        }


    }

}
