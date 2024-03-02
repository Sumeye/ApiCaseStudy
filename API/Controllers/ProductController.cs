using Application.Categories.Command;
using Application.Dto;
using Application.Products.Command;
using Application.Products.Queries;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ProductController : BaseController
    {
        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var products = new GetAllProducts();
            return Ok(await Mediator.Send(products));
        }

        [HttpGet("category/{categoryId}")]
        public async Task<IActionResult> GetByCategoryId(int categoryId)
        {
            var getProductByCategory = new GetProductByCategoryId() { CategoryId = categoryId };
            return Ok(await Mediator.Send(getProductByCategory));
        }

        [HttpPost]
        public async Task<IActionResult> Add([FromBody] CreateProduct createProduct)
        {
            CreatedProductDto result = await Mediator.Send(createProduct);
            return Created("", result);
        }

        [HttpPut]
        public async Task<IActionResult> Update(UpdateProduct updateProduct)
        {
            if (updateProduct.Id == 0)
            {
                return BadRequest();
            }
            await Mediator.Send(updateProduct);
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteProduct { Id = id });
            return NoContent();
        }
    }
}
