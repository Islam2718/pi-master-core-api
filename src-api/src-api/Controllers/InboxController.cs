using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace MyApiProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class InboxController : ControllerBase
    {
        private static readonly List<string> inbox = new List<string>
        {
            "Message 1",
            "Message 2",
            "Message 3"            
        };        

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get()
        {
            return Ok(inbox);
        }

        [HttpPost]
        public ActionResult Post(string message)
        {
            inbox.Add(message);
            return Ok();
        }

        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            if (id < 0 || id >= inbox.Count)
            {
                return NotFound();
            }
            return Ok(inbox[id]);
        }

        [HttpPut("{id}")]
        public ActionResult Put(int id, [FromBody] string message)
        {
            if (id < 0 || id >= inbox.Count)
            {
                return NotFound();
            }
            inbox[id] = message;
            return NoContent();
        } 

        [HttpDelete("{id}")]
        public ActionResult Delete(int id)
        {
            inbox.RemoveAt(id);
            return Ok();
        }       
    }
}