using Microsoft.AspNetCore.Mvc;
using MyApiProject.Services;
using System.Collections.Generic;


namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class PagesController : ControllerBase
    {
        // In-memory list of pages (for simplicity, no database)
        private static readonly List<string> pages = new List<string>
        {
            "Home page",
            "About Page", 
            "Contact Us", 
            "Privacy Policy", 
            "Terms & Condition",
            "FAQ"
        };

        private readonly PageService _pageService;

        public PagesController(PageService PageService)
        {
            _pageService = PageService;
        }

        // GET: api/pages
        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(_pageService.GetPages());
        }

        // GET: api/pages/2
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= pages.Count)
            {
                return NotFound();
            }
            return Ok(pages[id]);
        }

        // POST: api/pages
        [HttpPost]
        public ActionResult Post([FromBody] string product)
        {
            pages.Add(product);
            return CreatedAtAction(nameof(Get), new { id = pages.Count - 1 }, product);
        }

        // PUT: api/pages/2
        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string product)
        {
            if (id < 0 || id >= pages.Count)
            {
                return NotFound();
            }
            pages[id] = product;
            return NoContent();
        }

        // DELETE: api/pages/2
        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            if (id < 0 || id >= pages.Count)
            {
                return NotFound();
            }
            pages.RemoveAt(id);
            return NoContent();
        }
    }
}
