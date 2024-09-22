using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SliderItemsController : ControllerBase
    {
        private static readonly List<string> sliderItems = new List<string>
        {
            "item 1",
            "item 2",
            "item 3"
        };
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(sliderItems);
        }

        [HttpPost]
        public ActionResult Add(string item)
        {
            sliderItems.Add(item);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string item)
        {
            if (id < 0 || id >= sliderItems.Count)
            {
                return NotFound();
            }
            sliderItems[id] = item;
            return NoContent();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= sliderItems.Count)
            {
                return NotFound();
            }
            return Ok(sliderItems[id]);
        }

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= sliderItems.Count)
            {
                return NotFound();
            }
            sliderItems.RemoveAt(id);
            return NoContent();
        }        
    }
}