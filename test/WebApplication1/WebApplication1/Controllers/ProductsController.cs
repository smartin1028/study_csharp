using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using WebApplication1.Models;

namespace WebApplication1.Controllers
{
    public class ProductsController : ApiController
    {
        private static List<Product> products = new List<Product>();

        // GET api/products
        public IEnumerable<Product> Get()
        {
            return products;
        }

        // GET api/products/5
        public IHttpActionResult Get(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();
            return Ok(product);
        }

        // POST api/products
        public IHttpActionResult Post([FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
        
            products.Add(product);
            return CreatedAtRoute("DefaultApi", new { id = product.Id }, product);
        }

        // PUT api/products/5
        public IHttpActionResult Put(int id, [FromBody] Product product)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            var existingProduct = products.FirstOrDefault(p => p.Id == id);
            if (existingProduct == null)
                return NotFound();

            existingProduct.Name = product.Name;
            existingProduct.Price = product.Price;
        
            return Ok(existingProduct);
        }

        // DELETE api/products/5
        public IHttpActionResult Delete(int id)
        {
            var product = products.FirstOrDefault(p => p.Id == id);
            if (product == null)
                return NotFound();

            products.Remove(product);
            return Ok(product);
        }
    }

}