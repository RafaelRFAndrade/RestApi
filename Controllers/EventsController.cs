using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestApi.Entities;
using RestApi.Persistence;

namespace RestApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EventsController : ControllerBase
    {
        private readonly DbContext _context;

        public EventsController(DbContext context) 
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult GetAll()
        {
            var devEvents = _context.DevEvents.Where(d => !d.isDeleted).ToList();
            return Ok(devEvents);
        }
        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
          var devEvent = _context.DevEvents.SingleOrDefault(d => d.id == id);
          if (devEvent == null) 
            {
                return NotFound();
            }
            return Ok(devEvent);
        }
        [HttpPost]   
        public IActionResult Post(DevEvent devEvent) 
        {
            _context.DevEvents.Add(devEvent);
            return CreatedAtAction(nameof(GetById), new {id = devEvent.id}, devEvent);
        }
        [HttpPut("{id}")]
        public IActionResult Update(Guid id, DevEvent input) 
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.id == id);
            if (devEvent == null)
            {
                return NotFound();
            }
            devEvent.Update(input.Tittle, input.Description, input.StartDate, input.EndDate);
            
            return NoContent();   
        }
        [HttpDelete("{id}")]
        public IActionResult DeleteById(Guid id) 
        {
            var devEvent = _context.DevEvents.SingleOrDefault(d => d.id == id);
            if (devEvent == null)
            {
                return NotFound();
            }
            devEvent.Delete();
            return NoContent();
        }
    }
}
