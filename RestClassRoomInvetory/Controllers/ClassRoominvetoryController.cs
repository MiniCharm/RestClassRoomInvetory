using ClassRoomInvetory;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace RestClassRoomInvetory.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClassRoominvetoryController : ControllerBase
    {
        private ClassRoominvetoryReposetory _repo;

        public ClassRoominvetoryController(ClassRoominvetoryReposetory rep)
        {
            _repo = rep;
        }

        // GET: api/<ClassRoominvetoryController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<ClassRoominvetoryController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ClassRoominvetoryController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ClassRoominvetoryController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ClassRoominvetoryController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
