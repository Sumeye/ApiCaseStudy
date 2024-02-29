using Application.Categories.Command;
using Application.Dto;
using Application.Products.Command;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : BaseController
    {
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
            var result = await Mediator.Send(new DeleteProduct { Id = id });
            return NoContent();
        }
    }
}
