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
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        public ActionResult<IEnumerable<ClassRoom>> Get(
            [FromQuery] string? name,
            [FromQuery] int? minNumberOfBords,
            [FromQuery] int? minNumberOfsmartbords,
            [FromQuery] int? minNumberOfChairs,
            [FromQuery] string? sortBy
            )
        {
            List<ClassRoom> listOfClassRooms = _repo.Get(name, minNumberOfBords, minNumberOfsmartbords, minNumberOfChairs, sortBy);
            if (listOfClassRooms.Count == 0) 
            {
                return NoContent();
            }
            else 
            {
                return Ok(listOfClassRooms);
            }
        }

        // GET api/<ClassRoominvetoryController>/5
        [HttpGet("Id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClassRoom> Get(int id)
        {
            ClassRoom? room = _repo.GetClassRoomByID(id);
            if (room == null)
            { 
               return NotFound("No ClassRoom with the id"+id+"Was found");
            }
            else 
            { 
                return Ok(room); 
            }
        }

        // POST api/<ClassRoominvetoryController>
        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public ActionResult<ClassRoom> Post([FromBody] ClassRoom value)
        {
            try
            {
                ClassRoom room = _repo.AddClassRoom(value);
                string URI = Url.RouteUrl(RouteData.Values)+"/"+room.Id;
                return Created(URI,room);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

        // PUT api/<ClassRoominvetoryController>/5
        [HttpPut("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClassRoom> Put(int id, [FromBody] string value)
        {
            ClassRoom? room = _repo.GetClassRoomByID(id);
            if (room == null)
            {
                return NotFound("No ClassRoom with the id" + id + "Was found");
            }
            else
            {
                return Ok(room);
            }
        }

        // DELETE api/<ClassRoominvetoryController>/5
        [HttpDelete("{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<ClassRoom> Delete(int id)
        {
            ClassRoom? room = _repo.Delte(id);
            if(room == null) 
            {
                return NotFound("No ClassRoom with the id" + id + "Was found");
            }
            else 
            {
                return Ok(room);
            }
        }
    }
}
