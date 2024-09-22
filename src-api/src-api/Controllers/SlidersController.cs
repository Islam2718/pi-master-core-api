using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SlidersController : ControllerBase
    {
        private static readonly List<string> sliders = new List<string>
        {
            "Home page",
            "About Page", 
            "Contact Us"
        };

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()        
        {
            return Ok(sliders);
        }

        [HttpPost]
        public ActionResult Post([FromBody] string slider)
        {
            sliders.Add(slider);
            return CreatedAtAction(nameof(Get), new { id = sliders.Count - 1 }, slider);
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= sliders.Count)
            {
                return NotFound();
            }
            return Ok(sliders[id]);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string slider)
        {
            if (id < 0 || id >= sliders.Count)
            {
                return NotFound();
            }
            sliders[id] = slider;
            return NoContent();
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= sliders.Count)
            {
                return NotFound();
            }
            sliders.RemoveAt(id);
            return NoContent();
        }
    }
}