using Microsoft.AspNetCore.Mvc;

namespace webApiCrud.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        private readonly List<Product> _products = new List<Product>(); // Örnek veri depolama

        // GET: api/products
        [HttpGet]
        public ActionResult<IEnumerable<Product>> Get()
        {
            return _products;
        }

        // GET api/products/5
        [HttpGet("{id}")]
        public ActionResult<Product> Get(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            return product;
        }

        // POST api/products
        [HttpPost]
        public ActionResult<Product> Post([FromBody] Product product)
        {
            _products.Add(product);
            return CreatedAtAction(nameof(Get), new { id = product.Id }, product);
        }

        // PUT api/products/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Product updatedProduct)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            product.Name = updatedProduct.Name;
            product.Price = updatedProduct.Price;
            // Diðer özellikleri güncelle
            return NoContent();
        }

        // DELETE api/products/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var product = _products.FirstOrDefault(p => p.Id == id);
            if (product == null)
            {
                return NotFound();
            }
            _products.Remove(product);
            return NoContent();
        }
    }

}
