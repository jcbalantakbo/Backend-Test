using Backend_Test.Application.Interfaces;
using Backend_Test.Domain.Exceptions;
using Backend_Test.Domain.Models;
using Backend_Test.Utilities.Constants;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Backend_Test.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;

        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Product>>> GetAll()
        {
            var products = await _productService.GetAllAsync();
            return Ok(products);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Product>> GetById(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException(ErrorMessage.PersonNotFoundById(id));
            }
            return Ok(product);
        }

        [HttpPost]
        public async Task<IActionResult> Add(Product product)
        {
            if (product == null)
            {
                throw new BadRequestException(ErrorMessage.ProductInvalid);
            }

            await _productService.AddAsync(product);
            return CreatedAtAction(nameof(GetById), new { id = product.Id }, product);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, Product product)
        {
            if (id != product.Id)
            {
                throw new BadRequestException(ErrorMessage.IdNotMatch);
            }

            await _productService.UpdateAsync(product);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productService.GetByIdAsync(id);
            if (product == null)
            {
                throw new NotFoundException(ErrorMessage.PersonNotFoundById(id));
            }

            await _productService.DeleteAsync(id);
            return NoContent();
        }
    }
}
