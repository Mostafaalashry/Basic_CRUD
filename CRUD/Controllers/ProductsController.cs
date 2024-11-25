using CRUD.Data;
using Microsoft.AspNetCore.Mvc;
namespace CRUD.Controllers
{

    [ApiController]
    [Route("[controller]")]
    public class ProductsController : ControllerBase
    {
        private readonly ApplicationDBcontext _dBcontext;

        public ProductsController(ApplicationDBcontext dBcontext)
        {
            _dBcontext = dBcontext;
        }

        [HttpPost]
        [Route("")]
        public async Task<ActionResult<int>> createProduct(Product product)
        {
            product.Id = 0;
            _dBcontext.Set<Product>().Add(product);
            await _dBcontext.SaveChangesAsync();
            return Ok(product.Id);
        }

        [HttpPut]
        [Route("")]
        public ActionResult UpdateProduct(Product product)
        {
            var existingProduct = _dBcontext.Set<Product>().Find(product.Id);
            if (existingProduct == null)
            {
                return NotFound(new { message = $"Product with id {product.Id} not found." });
            }
            existingProduct.Name = product.Name;
            existingProduct.Sku = product.Sku;
            _dBcontext.Set<Product>().Update(existingProduct);
            _dBcontext.SaveChanges();
            return Ok();

        }



        [HttpDelete]
        [Route("{id}")]
        public ActionResult DeleteProduct(int id)
        {
            var existingProduct = _dBcontext.Set<Product>().Find(id);
            if (existingProduct == null)
            {
                return NotFound(new { message = $"Product with id {id} not found." });
            }
            _dBcontext.Set<Product>().Remove(existingProduct);
            _dBcontext.SaveChanges();
            return Ok(new { message = $"Product with id {id} deleted successfully." });
        }



        [HttpGet]
        [Route("")]
        public ActionResult <IEnumerable<Product>>GetAllProduct()
        {
            var records = _dBcontext.Set<Product>().ToList();
            return Ok(records);

        }


        [HttpGet]
        [Route("{id}")]
        public ActionResult<Product> GetById(int id)
        {
            var record = _dBcontext.Set<Product>().Find(id);
            return record==null ? NotFound() :  Ok(record);

        }

    }

}