using Microsoft.AspNetCore.Mvc;
using Recorder.DAL.Entities.Models;

namespace Recorder.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        // GET: api/<OrderController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<OrderController>/5
        [HttpGet("orders")] // api/order/orders
        public ActionResult<IEnumerable<Order>> GetAll()
        {
            var orders = new List<Order>()
            {
                new Order(1, 100, "deskrip", DateTime.Now, DateTime.Now),
                new Order(2, 50, "deskrip", DateTime.Now, DateTime.Now),
                new Order(3, 70, "deskrip", DateTime.Now, DateTime.Now)
            };

            

            return orders;
        }

        // POST api/<OrderController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<OrderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<OrderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
