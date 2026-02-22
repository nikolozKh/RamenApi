using Microsoft.AspNetCore.Mvc;
using RamenApi.Models;
using RamenApi.Services;

namespace RamenApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class RamenController : ControllerBase
    {
        private readonly RamenService _ramenService;

        public RamenController(RamenService ramenService)
        {
            _ramenService = ramenService;
        }

        // GET: api/ramen
        [HttpGet]
        public ActionResult<List<Ramen>> GetAll()
        {
            return Ok(_ramenService.GetAll());
        }

        // GET: api/ramen/5
        [HttpGet("{id}")]
        public ActionResult<Ramen> GetById(string id)
        {
            var ramen = _ramenService.GetById(id);
            if (ramen == null)
            {
                return NotFound(new { message = $"Ramen with id '{id}' not found" });
            }
            return Ok(ramen);
        }

        // GET: api/ramen/category/popular
        [HttpGet("category/{category}")]
        public ActionResult<List<Ramen>> GetByCategory(string category)
        {
            var ramens = _ramenService.GetByCategory(category);
            return Ok(ramens);
        }

        // POST: api/ramen
        [HttpPost]
        public ActionResult<Ramen> Create([FromBody] Ramen ramen)
        {
            if (ramen == null)
            {
                return BadRequest(new { message = "Invalid ramen data" });
            }

            var created = _ramenService.Add(ramen);
            return CreatedAtAction(nameof(GetById), new { id = created.Id }, created);
        }

        // PUT: api/ramen/5
        [HttpPut("{id}")]
        public ActionResult Update(string id, [FromBody] Ramen ramen)
        {
            if (ramen == null)
            {
                return BadRequest(new { message = "Invalid ramen data" });
            }

            var success = _ramenService.Update(id, ramen);
            if (!success)
            {
                return NotFound(new { message = $"Ramen with id '{id}' not found" });
            }

            return NoContent();
        }

        // DELETE: api/ramen/5
        [HttpDelete("{id}")]
        public ActionResult Delete(string id)
        {
            var success = _ramenService.Delete(id);
            if (!success)
            {
                return NotFound(new { message = $"Ramen with id '{id}' not found" });
            }

            return NoContent();
        }
    }
}